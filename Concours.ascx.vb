Public Class Concours
 Inherits ModuleBase

#Region " Unrecognized Controls "
 Protected WithEvents ctlParaRankings As Controls.RankingsTable
 Protected WithEvents ctlDeltaRankings As Controls.RankingsTable
 Protected WithEvents ctlRigidRankings As Controls.RankingsTable
 Protected WithEvents ctlMyFlightList As Controls.FlightList
 Protected WithEvents ctlLatestFlightsList As Controls.FlightList
 Protected WithEvents ctlUnvalidatedFlightsList As Controls.FlightList
#End Region

 Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
  ctlParaRankings.ModuleConfiguration = Me.ModuleConfiguration
  ctlDeltaRankings.ModuleConfiguration = Me.ModuleConfiguration
  ctlRigidRankings.ModuleConfiguration = Me.ModuleConfiguration
  ctlMyFlightList.ModuleConfiguration = Me.ModuleConfiguration
  ctlLatestFlightsList.ModuleConfiguration = Me.ModuleConfiguration
  ctlUnvalidatedFlightsList.ModuleConfiguration = Me.ModuleConfiguration
 End Sub

 Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  cmdAddDistance.Visible = Security.CanAdd

  tabUnvalidatedFlights.Visible = Security.CanValidate
  ctlUnvalidatedFlightsList.Visible = Security.CanValidate
  tabMyFlights.Visible = CBool(UserId > -1)
  ctlMyFlightList.Visible = CBool(UserId > -1)

  If Not Me.IsPostBack Then

  End If

 End Sub

 Private Sub cmdAddDistance_Click(sender As Object, e As System.EventArgs) Handles cmdAddDistance.Click
  Response.Redirect(EditUrl("DistanceEdit"), False)
 End Sub

 Private Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender

  If ctlParaRankings.NrRecords = 0 Then ctlParaRankings.Visible = False
  If ctlDeltaRankings.NrRecords = 0 Then ctlDeltaRankings.Visible = False
  If ctlRigidRankings.NrRecords = 0 Then ctlRigidRankings.Visible = False

 End Sub
End Class