﻿Imports Albatros.DNN.Modules.Concours.Entities.Distances
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
  Public Property WGSLat As Double
  Public Property WGSLong As Double
  Public Property SWLat As Double
  Public Property SWLong As Double
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
   cmdEdit.Visible = (Security.CanAdd Or Security.CanEdit) And DistanceTask.UserId = UserId And Not (DistanceTask.Validated Or DistanceTask.Rejected)
  End If

  cmdDelete.Visible = (Security.CanAdd Or Security.CanEdit) And (DistanceTask.UserId = UserId Or Security.CanValidate)
  DotNetNuke.UI.Utilities.ClientAPI.AddButtonConfirm(cmdDelete, LocalizeString("Delete.Confirm"))

  ctlUploadContainer.Visible = (Security.CanAdd Or Security.CanEdit) And (DistanceTask.UserId = UserId Or Security.CanValidate)

  SetValidationButton()

  If Not Me.IsPostBack Then

   Dim points As New List(Of Point)

   ' Start
   Dim p As New Point With {.Name = LocalizeString("Start"), .Description = DistanceTask.StartDescription, .Time = DistanceTask.FlightStart, .Coords = DistanceTask.StartCoords, .WGSLat = DistanceTask.StartLatitude, .WGSLong = DistanceTask.StartLongitude}
   CalcSwissgrid(p)
   points.Add(p)

   ' A
   If Not String.IsNullOrEmpty(DistanceTask.ACoords) Then
    p = New Point With {.Name = "A", .Description = DistanceTask.ADescription, .Time = DistanceTask.ATime, .Coords = DistanceTask.ACoords, .WGSLat = DistanceTask.ALatitude, .WGSLong = DistanceTask.ALongitude}
    CalcSwissgrid(p)
    points.Add(p)
   End If

   ' C, C1, C2
   Select Case DistanceTask.FlightType
    Case FlightType.FreeDistance
     imgFlightType.ImageUrl = ResolveUrl(glbModuleRelPath & "images/open_oneway.png")
    Case FlightType.OpenTriangle
     imgFlightType.ImageUrl = ResolveUrl(glbModuleRelPath & "images/open_broken.png")
     p = New Point With {.Name = "C", .Description = DistanceTask.C1Description, .Time = DateTime.MinValue, .Coords = DistanceTask.C1Coords, .WGSLat = DistanceTask.C1Latitude, .WGSLong = DistanceTask.C1Longitude}
     CalcSwissgrid(p)
     points.Add(p)
    Case FlightType.ReturnFlight
     imgFlightType.ImageUrl = ResolveUrl(glbModuleRelPath & "images/closed_back.png")
     p = New Point With {.Name = "C", .Description = DistanceTask.C1Description, .Time = DateTime.MinValue, .Coords = DistanceTask.C1Coords, .WGSLat = DistanceTask.C1Latitude, .WGSLong = DistanceTask.C1Longitude}
     CalcSwissgrid(p)
     points.Add(p)
    Case FlightType.Triangle
     imgFlightType.ImageUrl = ResolveUrl(glbModuleRelPath & "images/closed_triangle.png")
     p = New Point With {.Name = "C1", .Description = DistanceTask.C1Description, .Time = DateTime.MinValue, .Coords = DistanceTask.C1Coords, .WGSLat = DistanceTask.C1Latitude, .WGSLong = DistanceTask.C1Longitude}
     CalcSwissgrid(p)
     points.Add(p)
     p = New Point With {.Name = "C2", .Description = DistanceTask.C2Description, .Time = DateTime.MinValue, .Coords = DistanceTask.C2Coords, .WGSLat = DistanceTask.C2Latitude, .WGSLong = DistanceTask.C2Longitude}
     CalcSwissgrid(p)
     points.Add(p)
   End Select

   ' B
   If Not String.IsNullOrEmpty(DistanceTask.BCoords) Then
    p = New Point With {.Name = "B", .Description = DistanceTask.BDescription, .Time = DateTime.MinValue, .Coords = DistanceTask.BCoords, .WGSLat = DistanceTask.BLatitude, .WGSLong = DistanceTask.BLongitude}
    CalcSwissgrid(p)
    points.Add(p)
   End If

   ' Landing
   p = New Point With {.Name = LocalizeString("Landing"), .Description = DistanceTask.LandingDescription, .Time = DateTime.MinValue, .Coords = DistanceTask.LandingCoords, .WGSLat = DistanceTask.LandingLatitude, .WGSLong = DistanceTask.LandingLongitude}
   CalcSwissgrid(p)
   points.Add(p)

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
  DistanceTask.Validated = Not DistanceTask.Validated
  If DistanceTask.Validated Then DistanceTask.Rejected = False
  DistanceTask.ValidatedByUserID = UserId
  DistanceTask.ValidatedOnDate = Now
  DistancesController.UpdateDistance(DistanceTask, UserId)
  SetValidationButton()
  Integration.NotificationController.FlightValidated(ModuleConfiguration, DistanceTask, EditUrl("DistanceId", DistanceTask.DistanceId.ToString, "DistanceView"))
  If DistanceTask.Validated Then Integration.JournalController.AddFlightToJournal(ModuleConfiguration, DistanceTask, EditUrl("DistanceId", DistanceTask.DistanceId.ToString, "DistanceView"))
 End Sub

 Private Sub cmdReject_Click(sender As Object, e As System.EventArgs) Handles cmdReject.Click
  DistanceTask.Rejected = Not DistanceTask.Rejected
  If DistanceTask.Rejected Then DistanceTask.Validated = False
  DistanceTask.ValidatedByUserID = UserId
  DistanceTask.ValidatedOnDate = Now
  DistancesController.UpdateDistance(DistanceTask, UserId)
  SetValidationButton()
  Integration.NotificationController.FlightValidated(ModuleConfiguration, DistanceTask, EditUrl("DistanceId", DistanceTask.DistanceId.ToString, "DistanceView"))
 End Sub

 Private Sub SetValidationButton()
  cmdValidate.Visible = Security.CanValidate
  cmdReject.Visible = Security.CanValidate
  If DistanceTask.Validated Then
   DotNetNuke.UI.Utilities.ClientAPI.AddButtonConfirm(cmdValidate, LocalizeString("RemoveValidation.Confirm"))
   cmdValidate.Text = LocalizeString("cmdRemoveValidation")
   cmdReject.Visible = False
  ElseIf DistanceTask.Rejected Then
   cmdValidate.Visible = False
   DotNetNuke.UI.Utilities.ClientAPI.AddButtonConfirm(cmdReject, LocalizeString("RemoveRejection.Confirm"))
   cmdReject.Text = LocalizeString("cmdRemoveRejection")
  Else
   DotNetNuke.UI.Utilities.ClientAPI.AddButtonConfirm(cmdValidate, LocalizeString("Validate.Confirm"))
   cmdValidate.Text = LocalizeString("cmdValidate")
   cmdReject.Text = LocalizeString("cmdReject")
   DotNetNuke.UI.Utilities.ClientAPI.AddButtonConfirm(cmdReject, LocalizeString("Reject.Confirm"))
  End If
 End Sub

 Private Sub CalcSwissgrid(ByRef p As Point)
  Dim altSG As Double = 0
  Conversions.SwissProjection.WGS84toLV03(p.WGSLat, p.WGSLong, 0, p.SWLat, p.SWLong, altSG)
 End Sub
End Class