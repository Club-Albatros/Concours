Imports System.Xml
Imports DotNetNuke.Common.Globals
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports Albatros.DNN.Modules.Concours.Entities.Distances

Namespace Rss
 Public Class RssFeed

#Region " Structures "
  Private Structure DistanceTask
   Public Rank As Integer
   Public AggregatePoints As Double
   Public Flight As DistanceInfo
  End Structure
#End Region

#Region " Constants "
  Private Const nsBlogPre As String = "concours"
  Private Const nsBlogFull As String = "http://www.clubalbatros.ch/concours/"
  Private Const nsSlashPre As String = "slash"
  Private Const nsSlashFull As String = "http://purl.org/rss/1.0/modules/slash/"
  Private Const nsAtomPre As String = "atom"
  Private Const nsAtomFull As String = "http://www.w3.org/2005/Atom"
  Private Const nsMediaPre As String = "media"
  Private Const nsMediaFull As String = "http://search.yahoo.com/mrss/"
  Private Const nsDublinPre As String = "dc"
  Private Const nsDublinFull As String = "http://purl.org/dc/elements/1.1/"
  Private Const nsContentPre As String = "content"
  Private Const nsContentFull As String = "http://purl.org/rss/1.0/modules/content/"
  Private Const nsOpenSearchPre As String = "os"
  Private Const nsOpenSearchFull As String = "http://opensearch.a9.com/spec/opensearchrss/1.0/"
#End Region

#Region " Properties "
  Public Property PortalSettings As DotNetNuke.Entities.Portals.PortalSettings = Nothing
  Private Property DistanceTasks As New List(Of DistanceTask)
  Public Property CacheFile As String = ""
  Public Property IsCached As Boolean = False
  Public Property TotalRecords As Integer = -1

  ' Requested Properties
  Public Property ModuleId As Integer = -1
  Public Property TabId As Integer = -1
  Public Property FeedType As Integer = 0
  Public Property Category As Integer = -1 ' 0 - para, 1 - delta, 2 - rigid

  ' Feed Properties
  Public Property Title As String = ""
  Public Property Description As String = ""
  Public Property Link As String = ""
  Public Property FeedEmail As String = ""
  Public Property Locale As String = Threading.Thread.CurrentThread.CurrentCulture.Name
  Public Property Copyright As String = ""
#End Region

#Region " Constructors "
  Public Sub New(reqParams As NameValueCollection)

   ' Initialize Settings
   PortalSettings = DotNetNuke.Entities.Portals.PortalSettings.Current
   Dim port As String = String.Empty
   If HttpContext.Current.Request.Url.Port <> 80 Then
    port = ":" & HttpContext.Current.Request.Url.Port.ToString()
   End If

   ' Read Request Values
   reqParams.ReadValue("type", FeedType)
   reqParams.ReadValue("mid", ModuleId)
   reqParams.ReadValue("cat", Category)

   ' Start Filling In Feed Properties
   Dim m As ModuleInfo = (New DotNetNuke.Entities.Modules.ModuleController).GetModule(ModuleId)
   If m IsNot Nothing Then
    Title = m.ModuleTitle
    TabId = m.TabID
   End If
   FeedEmail = PortalSettings.Email
   'Copyright = PortalSettings.
   Link = HttpContext.Current.Request.Url.PathAndQuery
   CacheFile = Link.Substring(Link.IndexOf("?"c) + 1).Replace("&", "+").Replace("=", "-")
   CacheFile = String.Format("{0}\Albatros\Concours\RssCache\{1}.resources", PortalSettings.HomeDirectoryMapPath.TrimEnd("\"c), CacheFile)
   Link = FriendlyUrl(PortalSettings.ActiveTab, Link, Common.Globals.GetSafePageName(Title))

   ' Check Cache
   If IO.File.Exists(CacheFile) Then
    Dim f As New IO.FileInfo(CacheFile)
    If f.LastWriteTime.AddMinutes(30) > Now Then IsCached = True
   Else
    Dim pth As String = IO.Path.GetDirectoryName(CacheFile)
    If Not IO.Directory.Exists(pth) Then IO.Directory.CreateDirectory(pth)
   End If

   If Not IsCached Then

    If FeedType = 0 Then ' latest flights

     If Category = -1 Then
      For catId As Integer = 0 To 2
       AddRankings(catId)
      Next
     Else
      AddRankings(Category)
     End If

    Else ' rankings

     For Each d As DistanceInfo In DistancesController.GetDistancesByModule(ModuleId, True, 0, 10, "FLIGHTSTART DESC", TotalRecords)
      DistanceTasks.Add(New DistanceTask With {.Flight = d, .Rank = -1, .AggregatePoints = 0})
     Next

    End If

    WriteRss(CacheFile)
   End If
  End Sub
#End Region

#Region " Public Methods "
  Public Function WriteRssToString() As String
   Dim sb As New StringBuilder
   WriteRss(sb)
   Return sb.ToString
  End Function

  Public Sub WriteRss(ByRef output As IO.Stream)
   Using xtw As New XmlTextWriter(output, Encoding.UTF8)
    WriteRss(xtw)
    xtw.Flush()
   End Using
  End Sub

  Public Sub WriteRss(fileName As String)
   Using fs As New IO.FileStream(fileName, IO.FileMode.Create, IO.FileAccess.Write)
    Using xtw As New XmlTextWriter(fs, Encoding.UTF8)
     WriteRss(xtw)
     xtw.Flush()
    End Using
   End Using
  End Sub

  Public Sub WriteRss(ByRef output As StringBuilder)
   Using sw As New StringWriterWithEncoding(output, Encoding.UTF8)
    Using xtw As New XmlTextWriter(sw)
     WriteRss(xtw)
     xtw.Flush()
    End Using
    sw.Flush()
   End Using
  End Sub

  Public Sub WriteRss(ByRef output As XmlTextWriter)

   output.Formatting = Formatting.Indented
   output.WriteStartDocument()
   output.WriteStartElement("rss")
   output.WriteAttributeString("version", "2.0")
   output.WriteAttributeString("xmlns", nsBlogPre, Nothing, nsBlogFull)
   'output.WriteAttributeString("xmlns", nsSlashPre, Nothing, nsSlashFull)
   output.WriteAttributeString("xmlns", nsAtomPre, Nothing, nsAtomFull)
   output.WriteAttributeString("xmlns", nsMediaPre, Nothing, nsMediaFull)
   output.WriteStartElement("channel")

   ' Write the channel header block
   output.WriteElementString("title", Title)
   output.WriteElementString("link", Link)
   output.WriteElementString("description", Description)
   ' optional elements
   If Copyright <> "" Then output.WriteElementString("copyright", Copyright)
   If FeedEmail <> "" Then output.WriteElementString("managingEditor", FeedEmail)
   output.WriteElementString("pubDate", Now.ToString("r"))
   output.WriteElementString("lastBuildDate", Now.ToString("r"))
   output.WriteElementString("generator", "DotNetNuke Blog RSS Generator Version " & CType(System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString, String))
   output.WriteElementString("ttl", "30")
   ' extended elements
   output.WriteStartElement(nsAtomPre, "link", nsAtomFull)
   output.WriteAttributeString("href", HttpContext.Current.Request.Url.AbsoluteUri)
   output.WriteAttributeString("rel", "self")
   output.WriteAttributeString("type", "application/rss+xml")
   output.WriteEndElement() ' atom:link

   For Each dt As DistanceTask In DistanceTasks
    WriteItem(output, dt)
   Next

   output.WriteEndElement() ' channel
   output.WriteEndElement() ' rss
   output.Flush()

  End Sub
#End Region

#Region " Private Methods "
  Private Sub AddRankings(categoryId As Integer)

   Dim lastPilotId As Integer = -1
   Dim maxPilots As Integer = 3
   Using ir As IDataReader = Data.DataProvider.Instance.GetDistancesStandings(ModuleId, Now.Year, categoryId)
    Do While ir.Read
     Dim f As New DistanceInfo
     f.Fill(ir)
     If f.UserId <> lastPilotId Then
      Dim r As New DistanceTask
      r.Flight = f
      r.Rank = Convert.ToInt32(Null.SetNull(ir.Item("PilotRanking"), r.Rank))
      r.AggregatePoints = Convert.ToDouble(Null.SetNull(ir.Item("AggregatePoints"), r.AggregatePoints))
      lastPilotId = f.UserId
      DistanceTasks.Add(r)
      If maxPilots = 0 Then Exit Do
      maxPilots -= 1
     End If
    Loop
   End Using

  End Sub

  Private Sub WriteItem(ByRef writer As XmlTextWriter, item As DistanceTask)

   writer.WriteStartElement("item")

   Dim itemLink As String = DotNetNuke.Common.NavigateURL(TabId, PortalSettings, "DistanceView", "DistanceId=" & item.Flight.DistanceId.ToString, "mid=" & ModuleId.ToString)

   ' core data
   writer.WriteElementString("title", String.Format("{0} {1:d}", item.Flight.PilotDisplayName, item.Flight.FlightStart))
   writer.WriteElementString("link", itemLink)
   writer.WriteElementString("description", item.Flight.Summary)

   ' guid needs to have the isPermaLink=false attribute for some rss readers
   writer.WriteStartElement("guid")
   writer.WriteAttributeString("isPermaLink", "true")
   writer.WriteRaw(String.Format("{0}", itemLink))
   writer.WriteEndElement()
   writer.WriteElementString("pubDate", item.Flight.FlightStart.ToString("r"))

   ' extensions
   writer.WriteElementString(nsBlogPre, "pilot", nsBlogFull, item.Flight.PilotDisplayName)
   writer.WriteElementString(nsBlogPre, "startTime", nsBlogFull, item.Flight.FlightStart.ToString("u"))
   writer.WriteElementString(nsBlogPre, "start", nsBlogFull, item.Flight.StartDescription)
   writer.WriteElementString(nsBlogPre, "landing", nsBlogFull, item.Flight.LandingDescription)
   writer.WriteElementString(nsBlogPre, "flightType", nsBlogFull, item.Flight.FlightType.ToString)
   writer.WriteElementString(nsBlogPre, "category", nsBlogFull, item.Flight.Category.ToString)
   writer.WriteElementString(nsBlogPre, "distance", nsBlogFull, item.Flight.TotalDistance.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture))
   writer.WriteElementString(nsBlogPre, "points", nsBlogFull, item.Flight.TotalPoints.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture))
   If item.Rank > -1 Then
    writer.WriteElementString(nsBlogPre, "rank", nsBlogFull, item.Rank.ToString)
    writer.WriteElementString(nsBlogPre, "aggPoints", nsBlogFull, item.AggregatePoints.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture))
   End If

   writer.WriteEndElement() ' item

  End Sub
#End Region

 End Class
End Namespace
