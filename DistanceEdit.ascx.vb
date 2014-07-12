Imports Albatros.DNN.Modules.Concours.Entities.Distances

Public Class DistanceEdit
 Inherits ModuleBase

 Public Property DistanceId As Integer = -1
 Public Property DistanceTask As DistanceInfo

 Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
  Request.Params.ReadValue("DistanceId", DistanceId)
  If Not Security.CanValidate Then
   If Not (Security.CanAdd Or Security.CanEdit) Then
    Throw New Exception("You do not have permission to access this page")
   ElseIf DistanceTask IsNot Nothing AndAlso Not DistanceTask.UserId = UserId Then
    Throw New Exception("You do not have permission to access this page")
   ElseIf DistanceTask IsNot Nothing AndAlso DistanceTask.Validated Then
    Throw New Exception("You do not have permission to access this page")
   End If
  End If
  DotNetNuke.Framework.jQuery.RequestUIRegistration()
  AddCssFile("autocomplete.css")
  msgBoxError.Visible = False
 End Sub

 Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
  If DistanceId > -1 Then DistanceTask = DistancesController.GetDistance(DistanceId, ModuleId)

  If Not Me.IsPostBack Then
   If DistanceTask IsNot Nothing Then
    dpFlightDate.SelectedDate = DistanceTask.FlightStart
    tpTimeStart.SelectedTime = DistanceTask.FlightStart.TimeOfDay
    ddCategory.Items.FindByValue(DistanceTask.Category.ToString).Selected = True
    ddFlightType.Items.FindByValue(DistanceTask.FlightType.ToString).Selected = True
    txtComments.Text = DistanceTask.Comments
    txtDescriptionStart.Text = DistanceTask.StartDescription
    txtCoordinatesStart.Text = DistanceTask.StartCoords
    txtDescriptionA.Text = DistanceTask.ADescription
    If DistanceTask.ATime <> Date.MinValue Then tpTimeA.SelectedTime = DistanceTask.ATime.TimeOfDay
    txtCoordinatesA.Text = DistanceTask.ACoords
    txtDescriptionC1.Text = DistanceTask.C1Description
    txtCoordinatesC1.Text = DistanceTask.C1Coords
    txtDescriptionC2.Text = DistanceTask.C2Description
    txtCoordinatesC2.Text = DistanceTask.C2Coords
    txtDescriptionB.Text = DistanceTask.BDescription
    If DistanceTask.BTime <> Date.MinValue Then tpTimeB.SelectedTime = DistanceTask.BTime.TimeOfDay
    txtCoordinatesB.Text = DistanceTask.BCoords
    txtDescriptionLanding.Text = DistanceTask.LandingDescription
    If DistanceTask.LandingTime <> Date.MinValue Then tpTimeLanding.SelectedTime = DistanceTask.LandingTime.TimeOfDay
    txtCoordinatesLanding.Text = DistanceTask.LandingCoords
    If Security.CanValidate Then
     txtTotalDistance.Text = DistanceTask.TotalDistance.ToString("0.0")
     txtTotalPoints.Text = DistanceTask.TotalPoints.ToString("0.0")
     txtSummary.Text = DistanceTask.Summary
    End If
   End If
  End If

  If Not Security.CanValidate Or DistanceTask Is Nothing Then
   trSummary.Visible = False
   trTotalDistance.Visible = False
   trTotalPoints.Visible = False
  End If

 End Sub

 Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
  Me.Response.Redirect(DotNetNuke.Common.NavigateURL(), False)
 End Sub

 Private Sub cmdSubmit_Click(sender As Object, e As System.EventArgs) Handles cmdSubmit.Click

  Dim startTime As DateTime = CDate(CDate(dpFlightDate.SelectedDate) + tpTimeStart.SelectedTime)

  If DistanceTask Is Nothing Then DistanceTask = New DistanceInfo
  With DistanceTask
   .ModuleId = ModuleId
   If .DistanceId = -1 Then
    .UserId = UserId
    .PilotDisplayName = UserInfo.DisplayName
   End If
   .FlightStart = startTime
   .Category = Integer.Parse(ddCategory.SelectedValue)
   .FlightType = Integer.Parse(ddFlightType.SelectedValue)
   .Comments = txtComments.Text.Trim
   .StartDescription = txtDescriptionStart.Text.Trim
   .StartCoords = txtCoordinatesStart.Text.Trim
   FillCoordinates(.StartCoords, .StartLatitude, .StartLongitude)
   .ADescription = txtDescriptionA.Text.Trim
   If tpTimeA.SelectedTime IsNot Nothing Then
    .ATime = CDate(CDate(dpFlightDate.SelectedDate) + tpTimeA.SelectedTime)
   End If
   .ACoords = txtCoordinatesA.Text.Trim
   FillCoordinates(.ACoords, .ALatitude, .ALongitude)
   .C1Description = txtDescriptionC1.Text.Trim
   .C1Coords = txtCoordinatesC1.Text.Trim
   FillCoordinates(.C1Coords, .C1Latitude, .C1Longitude)
   .C2Description = txtDescriptionC2.Text.Trim
   .C2Coords = txtCoordinatesC2.Text.Trim
   FillCoordinates(.C2Coords, .C2Latitude, .C2Longitude)
   .BDescription = txtDescriptionB.Text.Trim
   If tpTimeB.SelectedTime IsNot Nothing Then
    .BTime = CDate(CDate(dpFlightDate.SelectedDate) + tpTimeB.SelectedTime)
   End If
   .BCoords = txtCoordinatesB.Text.Trim
   FillCoordinates(.BCoords, .BLatitude, .BLongitude)
   .LandingDescription = txtDescriptionLanding.Text.Trim
   .LandingTime = CDate(CDate(dpFlightDate.SelectedDate) + tpTimeLanding.SelectedTime)
   .LandingCoords = txtCoordinatesLanding.Text.Trim
   FillCoordinates(.LandingCoords, .LandingLatitude, .LandingLongitude)
   If txtTotalDistance.Text.Trim = "" Or txtTotalPoints.Text.Trim = "" Then
    .CalculateTotals()
   End If
   If txtTotalDistance.Text.Trim <> "" Then .TotalDistance = Double.Parse(txtTotalDistance.Text)
   If txtTotalPoints.Text.Trim <> "" Then .TotalPoints = Double.Parse(txtTotalPoints.Text)
   If txtSummary.Text.Trim <> "" Then .Summary = txtSummary.Text.Trim
  End With

  ' Check competition criteria
  If DistanceTask.TotalDistance < 10 Then
   LeaveWithError("ShortDistance")
   Exit Sub
  End If


  If DistanceTask.DistanceId = -1 Then
   DistanceTask.DistanceId = DistancesController.AddDistance(DistanceTask, UserId)
   Integration.NotificationController.FlightAdded(ModuleConfiguration, DistanceTask, EditUrl("DistanceId", DistanceTask.DistanceId.ToString, "DistanceView"))
  Else
   DistancesController.UpdateDistance(DistanceTask, UserId)
  End If

  Me.Response.Redirect(EditUrl("DistanceId", DistanceTask.DistanceId.ToString, "DistanceView"), False)

 End Sub

#Region " Private Methods "
 Private Sub LeaveWithError(errorKey As String)
  msgError.Text = LocalizeString(errorKey)
  msgBoxError.Visible = True
 End Sub

 Private Sub FillCoordinates(ByRef coordinates As String, ByRef latitude As Double, ByRef longitude As Double)

  Dim m As Match = Regex.Match(coordinates, "(\d{6})[^\d]+(\d{6})")
  If m.Success Then
   Dim val1 As Integer = Integer.Parse(m.Groups(1).Value)
   Dim val2 As Integer = Integer.Parse(m.Groups(2).Value)
   Dim latCh As Integer = 0
   Dim longCh As Integer = 0
   If val1 > val2 Then
    longCh = val1
    latCh = val2
   Else
    longCh = val2
    latCh = val1
   End If
   Dim newHeight As Double = 0
   coordinates = longCh.ToString & "/" & latCh.ToString
   Conversions.SwissProjection.LV03toWGS84(longCh, latCh, 0, latitude, longitude, newHeight)
   Exit Sub
  End If

  m = Regex.Match(coordinates, "(\d+\.\d+)/(\d+\.\d+)")
  If m.Success Then
   Dim val1 As Double = Double.Parse(m.Groups(1).Value, Globalization.NumberStyles.AllowDecimalPoint, Globalization.CultureInfo.InvariantCulture)
   Dim val2 As Double = Double.Parse(m.Groups(2).Value, Globalization.NumberStyles.AllowDecimalPoint, Globalization.CultureInfo.InvariantCulture)
   Dim longWgs As Double = 0
   Dim latWgs As Double = 0
   If val1 > val2 Then ' in CH lat is about 46 and long about 6
    latWgs = val1
    longWgs = val2
   Else
    longWgs = val1
    latWgs = val2
   End If
   longitude = longWgs
   latitude = latWgs
   Exit Sub
  End If

 End Sub
#End Region

End Class