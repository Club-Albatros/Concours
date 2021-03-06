Imports System
Imports System.Data
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Tokens

Namespace Entities.Distances

  <Serializable(), XmlRoot("Distance"), DataContract()>
  Partial Public Class DistanceInfo
   Implements IHydratable
   Implements IPropertyAccess
   Implements IXmlSerializable

#Region " IHydratable Implementation "
 ''' -----------------------------------------------------------------------------
 ''' <summary>
 ''' Fill hydrates the object from a Datareader
 ''' </summary>
 ''' <remarks>The Fill method is used by the CBO method to hydrtae the object
 ''' rather than using the more expensive Refection  methods.</remarks>
 ''' <history>
 ''' 	[pdonker]	03/11/2014  Created
 ''' </history>
 ''' -----------------------------------------------------------------------------
 Public Sub Fill(dr As IDataReader) Implements IHydratable.Fill
  DistanceId = Convert.ToInt32(Null.SetNull(dr.Item("DistanceId"), DistanceId))
  ModuleId = Convert.ToInt32(Null.SetNull(dr.Item("ModuleId"), ModuleId))
  UserId = Convert.ToInt32(Null.SetNull(dr.Item("UserId"), UserId))
  FlightStart = CDate(Null.SetNull(dr.Item("FlightStart"), FlightStart))
  Category = Convert.ToInt32(Null.SetNull(dr.Item("Category"), Category))
  FlightType = Convert.ToInt32(Null.SetNull(dr.Item("FlightType"), FlightType))
  Comments = Convert.ToString(Null.SetNull(dr.Item("Comments"), Comments))
  StartDescription = Convert.ToString(Null.SetNull(dr.Item("StartDescription"), StartDescription))
  StartCoords = Convert.ToString(Null.SetNull(dr.Item("StartCoords"), StartCoords))
  StartLatitude = Convert.ToDouble(Null.SetNull(dr.Item("StartLatitude"), StartLatitude))
  StartLongitude = Convert.ToDouble(Null.SetNull(dr.Item("StartLongitude"), StartLongitude))
  ADescription = Convert.ToString(Null.SetNull(dr.Item("ADescription"), ADescription))
  ATime = CDate(Null.SetNull(dr.Item("ATime"), ATime))
  ACoords = Convert.ToString(Null.SetNull(dr.Item("ACoords"), ACoords))
  ALatitude = Convert.ToDouble(Null.SetNull(dr.Item("ALatitude"), ALatitude))
  ALongitude = Convert.ToDouble(Null.SetNull(dr.Item("ALongitude"), ALongitude))
  C1Description = Convert.ToString(Null.SetNull(dr.Item("C1Description"), C1Description))
  C1Coords = Convert.ToString(Null.SetNull(dr.Item("C1Coords"), C1Coords))
  C1Latitude = Convert.ToDouble(Null.SetNull(dr.Item("C1Latitude"), C1Latitude))
  C1Longitude = Convert.ToDouble(Null.SetNull(dr.Item("C1Longitude"), C1Longitude))
  C2Description = Convert.ToString(Null.SetNull(dr.Item("C2Description"), C2Description))
  C2Coords = Convert.ToString(Null.SetNull(dr.Item("C2Coords"), C2Coords))
  C2Latitude = Convert.ToDouble(Null.SetNull(dr.Item("C2Latitude"), C2Latitude))
  C2Longitude = Convert.ToDouble(Null.SetNull(dr.Item("C2Longitude"), C2Longitude))
  BDescription = Convert.ToString(Null.SetNull(dr.Item("BDescription"), BDescription))
  BTime = CDate(Null.SetNull(dr.Item("BTime"), BTime))
  BCoords = Convert.ToString(Null.SetNull(dr.Item("BCoords"), BCoords))
  BLatitude = Convert.ToDouble(Null.SetNull(dr.Item("BLatitude"), BLatitude))
  BLongitude = Convert.ToDouble(Null.SetNull(dr.Item("BLongitude"), BLongitude))
  LandingDescription = Convert.ToString(Null.SetNull(dr.Item("LandingDescription"), LandingDescription))
  LandingTime = CDate(Null.SetNull(dr.Item("LandingTime"), LandingTime))
  LandingCoords = Convert.ToString(Null.SetNull(dr.Item("LandingCoords"), LandingCoords))
  LandingLatitude = Convert.ToDouble(Null.SetNull(dr.Item("LandingLatitude"), LandingLatitude))
  LandingLongitude = Convert.ToDouble(Null.SetNull(dr.Item("LandingLongitude"), LandingLongitude))
  TotalDistance = Convert.ToDouble(Null.SetNull(dr.Item("TotalDistance"), TotalDistance))
  TotalPoints = Convert.ToDouble(Null.SetNull(dr.Item("TotalPoints"), TotalPoints))
  Summary = Convert.ToString(Null.SetNull(dr.Item("Summary"), Summary))
  Validated = Convert.ToBoolean(Null.SetNull(dr.Item("Validated"), Validated))
  Rejected = Convert.ToBoolean(Null.SetNull(dr.Item("Rejected"), Rejected))
  CreatedByUserID = Convert.ToInt32(Null.SetNull(dr.Item("CreatedByUserID"), CreatedByUserID))
  CreatedOnDate = CDate(Null.SetNull(dr.Item("CreatedOnDate"), CreatedOnDate))
  LastModifiedByUserID = Convert.ToInt32(Null.SetNull(dr.Item("LastModifiedByUserID"), LastModifiedByUserID))
  LastModifiedOnDate = CDate(Null.SetNull(dr.Item("LastModifiedOnDate"), LastModifiedOnDate))
  ValidatedByUserID = Convert.ToInt32(Null.SetNull(dr.Item("ValidatedByUserID"), ValidatedByUserID))
  ValidatedOnDate = CDate(Null.SetNull(dr.Item("ValidatedOnDate"), ValidatedOnDate))
  PilotDisplayName = Convert.ToString(Null.SetNull(dr.Item("PilotDisplayName"), PilotDisplayName))
  CreatedByDisplayName = Convert.ToString(Null.SetNull(dr.Item("CreatedByDisplayName"), CreatedByDisplayName))
  LastModifiedByDisplayName = Convert.ToString(Null.SetNull(dr.Item("LastModifiedByDisplayName"), LastModifiedByDisplayName))
  ValidatedByDisplayName = Convert.ToString(Null.SetNull(dr.Item("ValidatedByDisplayName"), ValidatedByDisplayName))

 End Sub
 ''' -----------------------------------------------------------------------------
 ''' <summary>
 ''' Gets and sets the Key ID
 ''' </summary>
 ''' <remarks>The KeyID property is part of the IHydratble interface.  It is used
 ''' as the key property when creating a Dictionary</remarks>
 ''' <history>
 ''' 	[pdonker]	03/11/2014  Created
 ''' </history>
 ''' -----------------------------------------------------------------------------
 Public Property KeyID() As Integer Implements IHydratable.KeyID
  Get
   Return DistanceId
  End Get
  Set(value As Integer)
   DistanceId = value
  End Set
 End Property
#End Region

#Region " IPropertyAccess Implementation "
 Public Function GetProperty(strPropertyName As String, strFormat As String, formatProvider As System.Globalization.CultureInfo, AccessingUser As DotNetNuke.Entities.Users.UserInfo, AccessLevel As DotNetNuke.Services.Tokens.Scope, ByRef PropertyNotFound As Boolean) As String Implements DotNetNuke.Services.Tokens.IPropertyAccess.GetProperty
  Dim OutputFormat As String = String.Empty
  Dim portalSettings As DotNetNuke.Entities.Portals.PortalSettings = DotNetNuke.Entities.Portals.PortalController.GetCurrentPortalSettings()
  If strFormat = String.Empty Then
   OutputFormat = "D"
  Else
   OutputFormat = strFormat
  End If
  Select Case strPropertyName.ToLower
   Case "distanceid"
    Return (Me.DistanceId.ToString(OutputFormat, formatProvider))
   Case "moduleid"
    Return (Me.ModuleId.ToString(OutputFormat, formatProvider))
   Case "userid"
    Return (Me.UserId.ToString(OutputFormat, formatProvider))
   Case "flightstart"
    Return (Me.FlightStart.ToString(OutputFormat, formatProvider))
   Case "category"
    Return (Me.Category.ToString(OutputFormat, formatProvider))
   Case "flighttype"
    Return (Me.FlightType.ToString(OutputFormat, formatProvider))
   Case "comments"
    Return PropertyAccess.FormatString(Me.Comments, strFormat)
   Case "startdescription"
    Return PropertyAccess.FormatString(Me.StartDescription, strFormat)
   Case "startcoords"
    Return PropertyAccess.FormatString(Me.StartCoords, strFormat)
   Case "startlatitude"
    Return (Me.StartLatitude.ToString(OutputFormat, formatProvider))
   Case "startlongitude"
    Return (Me.StartLongitude.ToString(OutputFormat, formatProvider))
   Case "adescription"
    Return PropertyAccess.FormatString(Me.ADescription, strFormat)
   Case "atime"
    Return (Me.ATime.ToString(OutputFormat, formatProvider))
   Case "acoords"
    Return PropertyAccess.FormatString(Me.ACoords, strFormat)
   Case "alatitude"
    Return (Me.ALatitude.ToString(OutputFormat, formatProvider))
   Case "alongitude"
    Return (Me.ALongitude.ToString(OutputFormat, formatProvider))
   Case "c1description"
    Return PropertyAccess.FormatString(Me.C1Description, strFormat)
   Case "c1coords"
    Return PropertyAccess.FormatString(Me.C1Coords, strFormat)
   Case "c1latitude"
    Return (Me.C1Latitude.ToString(OutputFormat, formatProvider))
   Case "c1longitude"
    Return (Me.C1Longitude.ToString(OutputFormat, formatProvider))
   Case "c2description"
    Return PropertyAccess.FormatString(Me.C2Description, strFormat)
   Case "c2coords"
    Return PropertyAccess.FormatString(Me.C2Coords, strFormat)
   Case "c2latitude"
    Return (Me.C2Latitude.ToString(OutputFormat, formatProvider))
   Case "c2longitude"
    Return (Me.C2Longitude.ToString(OutputFormat, formatProvider))
   Case "bdescription"
    Return PropertyAccess.FormatString(Me.BDescription, strFormat)
   Case "btime"
    Return (Me.BTime.ToString(OutputFormat, formatProvider))
   Case "bcoords"
    Return PropertyAccess.FormatString(Me.BCoords, strFormat)
   Case "blatitude"
    Return (Me.BLatitude.ToString(OutputFormat, formatProvider))
   Case "blongitude"
    Return (Me.BLongitude.ToString(OutputFormat, formatProvider))
   Case "landingdescription"
    Return PropertyAccess.FormatString(Me.LandingDescription, strFormat)
   Case "landingtime"
    Return (Me.LandingTime.ToString(OutputFormat, formatProvider))
   Case "landingcoords"
    Return PropertyAccess.FormatString(Me.LandingCoords, strFormat)
   Case "landinglatitude"
    Return (Me.LandingLatitude.ToString(OutputFormat, formatProvider))
   Case "landinglongitude"
    Return (Me.LandingLongitude.ToString(OutputFormat, formatProvider))
   Case "totaldistance"
    Return (Me.TotalDistance.ToString(OutputFormat, formatProvider))
   Case "totalpoints"
    Return (Me.TotalPoints.ToString(OutputFormat, formatProvider))
   Case "summary"
    Return PropertyAccess.FormatString(Me.Summary, strFormat)
   Case "validated"
    Return Me.Validated.ToString
   Case "validatedyesno"
    Return PropertyAccess.Boolean2LocalizedYesNo(Me.Validated, formatProvider)
   Case "rejected"
    Return Me.Rejected.ToString
   Case "rejectedyesno"
    Return PropertyAccess.Boolean2LocalizedYesNo(Me.Rejected, formatProvider)
   Case "createdbyuserid"
    Return (Me.CreatedByUserID.ToString(OutputFormat, formatProvider))
   Case "createdondate"
    Return (Me.CreatedOnDate.ToString(OutputFormat, formatProvider))
   Case "lastmodifiedbyuserid"
    Return (Me.LastModifiedByUserID.ToString(OutputFormat, formatProvider))
   Case "lastmodifiedondate"
    Return (Me.LastModifiedOnDate.ToString(OutputFormat, formatProvider))
   Case "validatedbyuserid"
    Return (Me.ValidatedByUserID.ToString(OutputFormat, formatProvider))
   Case "validatedondate"
    Return (Me.ValidatedOnDate.ToString(OutputFormat, formatProvider))
   Case "pilotdisplayname"
    Return PropertyAccess.FormatString(Me.PilotDisplayName, strFormat)
   Case "createdbydisplayname"
    Return PropertyAccess.FormatString(Me.CreatedByDisplayName, strFormat)
   Case "lastmodifiedbydisplayname"
    Return PropertyAccess.FormatString(Me.LastModifiedByDisplayName, strFormat)
   Case "validatedbydisplayname"
    Return PropertyAccess.FormatString(Me.ValidatedByDisplayName, strFormat)
   Case Else
    PropertyNotFound = True
  End Select

  Return Null.NullString
 End Function

 Public ReadOnly Property Cacheability() As DotNetNuke.Services.Tokens.CacheLevel Implements DotNetNuke.Services.Tokens.IPropertyAccess.Cacheability
  Get
   Return CacheLevel.fullyCacheable
  End Get
 End Property
#End Region

#Region " IXmlSerializable Implementation "
  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' GetSchema returns the XmlSchema for this class
  ''' </summary>
  ''' <remarks>GetSchema is implemented as a stub method as it is not required</remarks>
  ''' <history>
  ''' 	[pdonker]	03/11/2014  Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
   Return Nothing
  End Function

  Private Function readElement(reader As XmlReader, ElementName As String) As String
   If (Not reader.NodeType = XmlNodeType.Element) OrElse reader.Name <> ElementName Then
    reader.ReadToFollowing(ElementName)
   End If
   If reader.NodeType = XmlNodeType.Element Then
    Return reader.ReadElementContentAsString
   Else
    Return ""
   End If
  End Function

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' ReadXml fills the object (de-serializes it) from the XmlReader passed
  ''' </summary>
  ''' <remarks></remarks>
  ''' <param name="reader">The XmlReader that contains the xml for the object</param>
  ''' <history>
  ''' 	[pdonker]	03/11/2014  Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
   Try

    If Not Int32.TryParse(readElement(reader, "DistanceId"), DistanceId) Then
     DistanceId = Null.NullInteger
    End If
    If Not Int32.TryParse(readElement(reader, "ModuleId"), ModuleId) Then
     ModuleId = Null.NullInteger
    End If
    If Not Int32.TryParse(readElement(reader, "UserId"), UserId) Then
     UserId = Null.NullInteger
    End If
   Date.TryParse(readElement(reader, "FlightStart"), FlightStart)
    If Not Int32.TryParse(readElement(reader, "Category"), Category) Then
     Category = Null.NullInteger
    End If
    If Not Int32.TryParse(readElement(reader, "FlightType"), FlightType) Then
     FlightType = Null.NullInteger
    End If
    Comments = readElement(reader, "Comments")
    StartDescription = readElement(reader, "StartDescription")
    StartCoords = readElement(reader, "StartCoords")
   Double.TryParse(readElement(reader, "StartLatitude"), StartLatitude)
   Double.TryParse(readElement(reader, "StartLongitude"), StartLongitude)
    ADescription = readElement(reader, "ADescription")
   Date.TryParse(readElement(reader, "ATime"), ATime)
    ACoords = readElement(reader, "ACoords")
   Double.TryParse(readElement(reader, "ALatitude"), ALatitude)
   Double.TryParse(readElement(reader, "ALongitude"), ALongitude)
    C1Description = readElement(reader, "C1Description")
    C1Coords = readElement(reader, "C1Coords")
   Double.TryParse(readElement(reader, "C1Latitude"), C1Latitude)
   Double.TryParse(readElement(reader, "C1Longitude"), C1Longitude)
    C2Description = readElement(reader, "C2Description")
    C2Coords = readElement(reader, "C2Coords")
   Double.TryParse(readElement(reader, "C2Latitude"), C2Latitude)
   Double.TryParse(readElement(reader, "C2Longitude"), C2Longitude)
    BDescription = readElement(reader, "BDescription")
   Date.TryParse(readElement(reader, "BTime"), BTime)
    BCoords = readElement(reader, "BCoords")
   Double.TryParse(readElement(reader, "BLatitude"), BLatitude)
   Double.TryParse(readElement(reader, "BLongitude"), BLongitude)
    LandingDescription = readElement(reader, "LandingDescription")
   Date.TryParse(readElement(reader, "LandingTime"), LandingTime)
    LandingCoords = readElement(reader, "LandingCoords")
   Double.TryParse(readElement(reader, "LandingLatitude"), LandingLatitude)
   Double.TryParse(readElement(reader, "LandingLongitude"), LandingLongitude)
   Double.TryParse(readElement(reader, "TotalDistance"), TotalDistance)
   Double.TryParse(readElement(reader, "TotalPoints"), TotalPoints)
    Summary = readElement(reader, "Summary")
   Boolean.TryParse(readElement(reader, "Validated"), Validated)
   Boolean.TryParse(readElement(reader, "Rejected"), Rejected)
    If Not Int32.TryParse(readElement(reader, "CreatedByUserID"), CreatedByUserID) Then
     CreatedByUserID = Null.NullInteger
    End If
   Date.TryParse(readElement(reader, "CreatedOnDate"), CreatedOnDate)
    If Not Int32.TryParse(readElement(reader, "LastModifiedByUserID"), LastModifiedByUserID) Then
     LastModifiedByUserID = Null.NullInteger
    End If
   Date.TryParse(readElement(reader, "LastModifiedOnDate"), LastModifiedOnDate)
    If Not Int32.TryParse(readElement(reader, "ValidatedByUserID"), ValidatedByUserID) Then
     ValidatedByUserID = Null.NullInteger
    End If
   Date.TryParse(readElement(reader, "ValidatedOnDate"), ValidatedOnDate)
    PilotDisplayName = readElement(reader, "PilotDisplayName")
    CreatedByDisplayName = readElement(reader, "CreatedByDisplayName")
    LastModifiedByDisplayName = readElement(reader, "LastModifiedByDisplayName")
    ValidatedByDisplayName = readElement(reader, "ValidatedByDisplayName")
   Catch ex As Exception
    ' log exception as DNN import routine does not do that
    DotNetNuke.Services.Exceptions.LogException(ex)
    ' re-raise exception to make sure import routine displays a visible error to the user
    Throw New Exception("An error occured during import of an Distance", ex)
   End Try

  End Sub

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' WriteXml converts the object to Xml (serializes it) and writes it using the XmlWriter passed
  ''' </summary>
  ''' <remarks></remarks>
  ''' <param name="writer">The XmlWriter that contains the xml for the object</param>
  ''' <history>
  ''' 	[pdonker]	03/11/2014  Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
   writer.WriteStartElement("Distance")
   writer.WriteElementString("DistanceId",  DistanceId.ToString())
   writer.WriteElementString("ModuleId",  ModuleId.ToString())
   writer.WriteElementString("UserId",  UserId.ToString())
   writer.WriteElementString("FlightStart",  FlightStart.ToString())
   writer.WriteElementString("Category",  Category.ToString())
   writer.WriteElementString("FlightType",  FlightType.ToString())
   writer.WriteElementString("Comments",  Comments)
   writer.WriteElementString("StartDescription",  StartDescription)
   writer.WriteElementString("StartCoords",  StartCoords)
   writer.WriteElementString("StartLatitude",  StartLatitude.ToString())
   writer.WriteElementString("StartLongitude",  StartLongitude.ToString())
   writer.WriteElementString("ADescription",  ADescription)
   writer.WriteElementString("ATime",  ATime.ToString())
   writer.WriteElementString("ACoords",  ACoords)
   writer.WriteElementString("ALatitude",  ALatitude.ToString())
   writer.WriteElementString("ALongitude",  ALongitude.ToString())
   writer.WriteElementString("C1Description",  C1Description)
   writer.WriteElementString("C1Coords",  C1Coords)
   writer.WriteElementString("C1Latitude",  C1Latitude.ToString())
   writer.WriteElementString("C1Longitude",  C1Longitude.ToString())
   writer.WriteElementString("C2Description",  C2Description)
   writer.WriteElementString("C2Coords",  C2Coords)
   writer.WriteElementString("C2Latitude",  C2Latitude.ToString())
   writer.WriteElementString("C2Longitude",  C2Longitude.ToString())
   writer.WriteElementString("BDescription",  BDescription)
   writer.WriteElementString("BTime",  BTime.ToString())
   writer.WriteElementString("BCoords",  BCoords)
   writer.WriteElementString("BLatitude",  BLatitude.ToString())
   writer.WriteElementString("BLongitude",  BLongitude.ToString())
   writer.WriteElementString("LandingDescription",  LandingDescription)
   writer.WriteElementString("LandingTime",  LandingTime.ToString())
   writer.WriteElementString("LandingCoords",  LandingCoords)
   writer.WriteElementString("LandingLatitude",  LandingLatitude.ToString())
   writer.WriteElementString("LandingLongitude",  LandingLongitude.ToString())
   writer.WriteElementString("TotalDistance",  TotalDistance.ToString())
   writer.WriteElementString("TotalPoints",  TotalPoints.ToString())
   writer.WriteElementString("Summary",  Summary)
   writer.WriteElementString("Validated",  Validated.ToString())
   writer.WriteElementString("Rejected",  Rejected.ToString())
   writer.WriteElementString("CreatedByUserID",  CreatedByUserID.ToString())
   writer.WriteElementString("CreatedOnDate",  CreatedOnDate.ToString())
   writer.WriteElementString("LastModifiedByUserID",  LastModifiedByUserID.ToString())
   writer.WriteElementString("LastModifiedOnDate",  LastModifiedOnDate.ToString())
   writer.WriteElementString("ValidatedByUserID",  ValidatedByUserID.ToString())
   writer.WriteElementString("ValidatedOnDate",  ValidatedOnDate.ToString())
   writer.WriteElementString("PilotDisplayName",  PilotDisplayName)
   writer.WriteElementString("CreatedByDisplayName",  CreatedByDisplayName)
   writer.WriteElementString("LastModifiedByDisplayName",  LastModifiedByDisplayName)
   writer.WriteElementString("ValidatedByDisplayName",  ValidatedByDisplayName)
   writer.WriteEndElement()
  End Sub
#End Region

#Region " ToXml Methods "
  Public Function ToXml() As String
   Return ToXml("Distance")
  End Function

  Public Function ToXml(elementName As String) As String
   Dim xml As New StringBuilder
   xml.Append("<")
   xml.Append(elementName)
   AddAttribute(xml, "DistanceId", DistanceId.ToString())
   AddAttribute(xml, "ModuleId", ModuleId.ToString())
   AddAttribute(xml, "UserId", UserId.ToString())
   AddAttribute(xml, "FlightStart", FlightStart.ToUniversalTime.ToString("u"))
   AddAttribute(xml, "Category", Category.ToString())
   AddAttribute(xml, "FlightType", FlightType.ToString())
   AddAttribute(xml, "Comments", Comments)
   AddAttribute(xml, "StartDescription", StartDescription)
   AddAttribute(xml, "StartCoords", StartCoords)
   AddAttribute(xml, "StartLatitude", StartLatitude.ToString())
   AddAttribute(xml, "StartLongitude", StartLongitude.ToString())
   AddAttribute(xml, "ADescription", ADescription)
   AddAttribute(xml, "ATime", ATime.ToUniversalTime.ToString("u"))
   AddAttribute(xml, "ACoords", ACoords)
   AddAttribute(xml, "ALatitude", ALatitude.ToString())
   AddAttribute(xml, "ALongitude", ALongitude.ToString())
   AddAttribute(xml, "C1Description", C1Description)
   AddAttribute(xml, "C1Coords", C1Coords)
   AddAttribute(xml, "C1Latitude", C1Latitude.ToString())
   AddAttribute(xml, "C1Longitude", C1Longitude.ToString())
   AddAttribute(xml, "C2Description", C2Description)
   AddAttribute(xml, "C2Coords", C2Coords)
   AddAttribute(xml, "C2Latitude", C2Latitude.ToString())
   AddAttribute(xml, "C2Longitude", C2Longitude.ToString())
   AddAttribute(xml, "BDescription", BDescription)
   AddAttribute(xml, "BTime", BTime.ToUniversalTime.ToString("u"))
   AddAttribute(xml, "BCoords", BCoords)
   AddAttribute(xml, "BLatitude", BLatitude.ToString())
   AddAttribute(xml, "BLongitude", BLongitude.ToString())
   AddAttribute(xml, "LandingDescription", LandingDescription)
   AddAttribute(xml, "LandingTime", LandingTime.ToUniversalTime.ToString("u"))
   AddAttribute(xml, "LandingCoords", LandingCoords)
   AddAttribute(xml, "LandingLatitude", LandingLatitude.ToString())
   AddAttribute(xml, "LandingLongitude", LandingLongitude.ToString())
   AddAttribute(xml, "TotalDistance", TotalDistance.ToString())
   AddAttribute(xml, "TotalPoints", TotalPoints.ToString())
   AddAttribute(xml, "Summary", Summary)
   AddAttribute(xml, "Validated", Validated.ToString())
   AddAttribute(xml, "Rejected", Rejected.ToString())
   AddAttribute(xml, "CreatedByUserID", CreatedByUserID.ToString())
   AddAttribute(xml, "CreatedOnDate", CreatedOnDate.ToUniversalTime.ToString("u"))
   AddAttribute(xml, "LastModifiedByUserID", LastModifiedByUserID.ToString())
   AddAttribute(xml, "LastModifiedOnDate", LastModifiedOnDate.ToUniversalTime.ToString("u"))
   AddAttribute(xml, "ValidatedByUserID", ValidatedByUserID.ToString())
   AddAttribute(xml, "ValidatedOnDate", ValidatedOnDate.ToUniversalTime.ToString("u"))
   AddAttribute(xml, "PilotDisplayName", PilotDisplayName)
   AddAttribute(xml, "CreatedByDisplayName", CreatedByDisplayName)
   AddAttribute(xml, "LastModifiedByDisplayName", LastModifiedByDisplayName)
   AddAttribute(xml, "ValidatedByDisplayName", ValidatedByDisplayName)
   xml.Append(" />")
   Return xml.ToString
  End Function

  Private Sub AddAttribute(ByRef xml As StringBuilder, attributeName As String, attributeValue As String)
   xml.Append(" " & attributeName)
   xml.Append("=""" & attributeValue & """")
  End Sub
#End Region

#Region " JSON Serialization "
  Public Sub WriteJSON(ByRef s As Stream)
   Dim ser As New DataContractJsonSerializer(GetType(DistanceInfo))
   ser.WriteObject(s, Me)
  End Sub
#End Region

 End Class
End Namespace


