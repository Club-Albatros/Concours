Namespace Controls
 Public Class RankingsTable
  Inherits ModuleBase

  Public Property CategoryId As Integer = -1
  Public Property NrRecords As Integer = 0

  Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
   LocalResourceFile = Common.Globals.glbSharedResources
  End Sub

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

   If Not Me.IsPostBack Then

    Using ir As IDataReader = Data.DataProvider.Instance.GetDistancesStandings(ModuleId, Now.Year, CategoryId)
     rpRankingsPara.DataSource = ir
     rpRankingsPara.DataBind()
    End Using
    NrRecords = rpRankingsPara.Items.Count

   End If

  End Sub

 End Class
End Namespace