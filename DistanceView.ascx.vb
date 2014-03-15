Imports Albatros.DNN.Modules.Concours.Entities.Distances
Imports Albatros.DNN.Modules.Concours.Common.Globals

Public Class DistanceView
 Inherits ModuleBase

 Public Property DistanceId As Integer = -1
 Public Property DistanceTask As DistanceInfo

 Public Structure Point
  Public Property Name As String
  Public Property Description As String
  Public Property Time As DateTime
  Public Property Coords As String
 End Structure

 Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
  Request.Params.ReadValue("DistanceId", DistanceId)
  LocalResourceFile = "DesktopModules/Albatros/Concours/App_LocalResources/DistanceEdit"
  AddJavascriptFile("jquery.colorbox.js", 70)
  AddCssFile("colorbox.css")
 End Sub

 Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  DistanceTask = DistancesController.GetDistance(DistanceId, ModuleId)
  If DistanceTask Is Nothing Then Response.Redirect(DotNetNuke.Common.NavigateURL(), True)

  If Security.CanValidate Then
   cmdEdit.Visible = True
  Else
   cmdEdit.Visible = (Security.CanAdd Or Security.CanEdit) And DistanceTask.UserId = UserId And Not DistanceTask.Validated
  End If
  cmdDelete.Visible = (Security.CanAdd Or Security.CanEdit) And (DistanceTask.UserId = UserId Or Security.CanValidate)
  ctlUploadContainer.Visible = (Security.CanAdd Or Security.CanEdit) And (DistanceTask.UserId = UserId Or Security.CanValidate)
  cmdValidate.Visible = Security.CanValidate And DistanceTask.Validated = False

  DotNetNuke.UI.Utilities.ClientAPI.AddButtonConfirm(cmdDelete, LocalizeString("Delete.Confirm"))
  DotNetNuke.UI.Utilities.ClientAPI.AddButtonConfirm(cmdValidate, LocalizeString("Validate.Confirm"))

  If Not Me.IsPostBack Then
   Dim points As New List(Of Point)
   Select Case DistanceTask.FlightType
    Case FlightType.FreeDistance
     imgFlightType.ImageUrl = ResolveUrl(ModuleRelPath & "images/open_oneway.png")
     points.Add(New Point With {.Name = LocalizeString("Start"), .Description = DistanceTask.StartDescription, .Time = DistanceTask.FlightStart, .Coords = DistanceTask.StartCoords})
     If Not String.IsNullOrEmpty(DistanceTask.ACoords) Then
      points.Add(New Point With {.Name = "A", .Description = DistanceTask.ADescription, .Time = DistanceTask.ATime, .Coords = DistanceTask.ACoords})
     End If
     If Not String.IsNullOrEmpty(DistanceTask.BCoords) Then
      points.Add(New Point With {.Name = "B", .Description = DistanceTask.BDescription, .Time = DistanceTask.BTime, .Coords = DistanceTask.BCoords})
     End If
     points.Add(New Point With {.Name = LocalizeString("Landing"), .Description = DistanceTask.LandingDescription, .Time = DistanceTask.LandingTime, .Coords = DistanceTask.LandingCoords})
    Case FlightType.OpenTriangle
     imgFlightType.ImageUrl = ResolveUrl(ModuleRelPath & "images/open_broken.png")
     points.Add(New Point With {.Name = LocalizeString("Start"), .Description = DistanceTask.StartDescription, .Time = DistanceTask.FlightStart, .Coords = DistanceTask.StartCoords})
     If Not String.IsNullOrEmpty(DistanceTask.ACoords) Then
      points.Add(New Point With {.Name = "A", .Description = DistanceTask.ADescription, .Time = DistanceTask.ATime, .Coords = DistanceTask.ACoords})
     End If
     points.Add(New Point With {.Name = "C", .Description = DistanceTask.C1Description, .Time = DateTime.MinValue, .Coords = DistanceTask.C1Coords})
     If Not String.IsNullOrEmpty(DistanceTask.BCoords) Then
      points.Add(New Point With {.Name = "B", .Description = DistanceTask.BDescription, .Time = DistanceTask.BTime, .Coords = DistanceTask.BCoords})
     End If
     points.Add(New Point With {.Name = LocalizeString("Landing"), .Description = DistanceTask.LandingDescription, .Time = DistanceTask.LandingTime, .Coords = DistanceTask.LandingCoords})
    Case FlightType.ReturnFlight
     imgFlightType.ImageUrl = ResolveUrl(ModuleRelPath & "images/open_broken.png")
     points.Add(New Point With {.Name = LocalizeString("Start"), .Description = DistanceTask.StartDescription, .Time = DistanceTask.FlightStart, .Coords = DistanceTask.StartCoords})
     If Not String.IsNullOrEmpty(DistanceTask.ACoords) Then
      points.Add(New Point With {.Name = "A", .Description = DistanceTask.ADescription, .Time = DistanceTask.ATime, .Coords = DistanceTask.ACoords})
     End If
     points.Add(New Point With {.Name = "C", .Description = DistanceTask.C1Description, .Time = DateTime.MinValue, .Coords = DistanceTask.C1Coords})
     If Not String.IsNullOrEmpty(DistanceTask.BCoords) Then
      points.Add(New Point With {.Name = "B", .Description = DistanceTask.BDescription, .Time = DistanceTask.BTime, .Coords = DistanceTask.BCoords})
     End If
     points.Add(New Point With {.Name = LocalizeString("Landing"), .Description = DistanceTask.LandingDescription, .Time = DistanceTask.LandingTime, .Coords = DistanceTask.LandingCoords})
     imgFlightType.ImageUrl = ResolveUrl(ModuleRelPath & "images/closed_back.png")
    Case FlightType.Triangle
     imgFlightType.ImageUrl = ResolveUrl(ModuleRelPath & "images/open_broken.png")
     points.Add(New Point With {.Name = LocalizeString("Start"), .Description = DistanceTask.StartDescription, .Time = DistanceTask.FlightStart, .Coords = DistanceTask.StartCoords})
     If Not String.IsNullOrEmpty(DistanceTask.ACoords) Then
      points.Add(New Point With {.Name = "A", .Description = DistanceTask.ADescription, .Time = DistanceTask.ATime, .Coords = DistanceTask.ACoords})
     End If
     points.Add(New Point With {.Name = "C1", .Description = DistanceTask.C1Description, .Time = DateTime.MinValue, .Coords = DistanceTask.C1Coords})
     points.Add(New Point With {.Name = "C2", .Description = DistanceTask.C2Description, .Time = DateTime.MinValue, .Coords = DistanceTask.C2Coords})
     If Not String.IsNullOrEmpty(DistanceTask.BCoords) Then
      points.Add(New Point With {.Name = "B", .Description = DistanceTask.BDescription, .Time = DistanceTask.BTime, .Coords = DistanceTask.BCoords})
     End If
     points.Add(New Point With {.Name = LocalizeString("Landing"), .Description = DistanceTask.LandingDescription, .Time = DistanceTask.LandingTime, .Coords = DistanceTask.LandingCoords})
     imgFlightType.ImageUrl = ResolveUrl(ModuleRelPath & "images/closed_triangle.png")
   End Select

   rpPoints.DataSource = points
   rpPoints.DataBind()

   ShowFiles()
  End If

 End Sub

 Private Sub cmdUpload_Click(sender As Object, e As System.EventArgs) Handles cmdUpload.Click

  If ctlFileUpload.HasFile Then

   Dim saveDir As String = Common.Globals.GetDistanceDirectoryMapPath(DistanceId)
   Dim fileName As String = ctlFileUpload.FileName
   Select Case IO.Path.GetExtension(fileName).ToLower
    Case ".jpg"
     ctlFileUpload.SaveAs(saveDir & IO.Path.GetFileNameWithoutExtension(fileName).Replace(".", "").Replace(";", "") & ".original.jpg")
    Case ".igc", ".gpx", ".txt"
     ctlFileUpload.SaveAs(saveDir & IO.Path.GetFileNameWithoutExtension(fileName).Replace(".", "").Replace(";", "") & IO.Path.GetExtension(fileName).ToLower)
   End Select

  End If

  ShowFiles()

 End Sub

 Private Sub ShowFiles()

  Dim fileDir As New IO.DirectoryInfo(Common.Globals.GetDistanceDirectoryMapPath(DistanceId))
  If Not fileDir.Exists Then fileDir.Create()

  Dim files As New List(Of IO.FileInfo)
  Dim images As New List(Of IO.FileInfo)

  For Each file As IO.FileInfo In fileDir.GetFiles
   If file.Name.EndsWith(".original.jpg") Then
    images.Add(file)
   ElseIf file.Name.EndsWith(".jpg") Then
    ' ignore
   Else
    files.Add(file)
   End If
  Next

  rpFiles.DataSource = files
  rpFiles.DataBind()
  rpImages.DataSource = images
  rpImages.DataBind()

 End Sub

 Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
  Me.Response.Redirect(DotNetNuke.Common.NavigateURL(), False)
 End Sub

 Private Sub cmdEdit_Click(sender As Object, e As System.EventArgs) Handles cmdEdit.Click
  Response.Redirect(EditUrl("DistanceId", DistanceId.ToString, "DistanceEdit"), False)
 End Sub

 Private Sub cmdDelete_Click(sender As Object, e As System.EventArgs) Handles cmdDelete.Click
  Dim saveDir As String = Common.Globals.GetDistanceDirectoryMapPath(DistanceId)
  Dim files() As String = IO.Directory.GetFiles(saveDir)
  For Each file As String In files
   Try
    IO.File.Delete(file)
   Catch ex As Exception
   End Try
  Next
  Try
   IO.Directory.Delete(saveDir, True)
  Catch ex As Exception
  End Try
  DistancesController.DeleteDistance(DistanceId)
  Me.Response.Redirect(DotNetNuke.Common.NavigateURL(), False)
 End Sub

 Private Sub cmdValidate_Click(sender As Object, e As System.EventArgs) Handles cmdValidate.Click
  DistanceTask.Validated = True
  DistanceTask.ValidatedByUserID = UserId
  DistanceTask.ValidatedOnDate = Now
  DistancesController.UpdateDistance(DistanceTask, UserId)
  cmdValidate.Visible = False
 End Sub

End Class