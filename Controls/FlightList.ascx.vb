Imports Albatros.DNN.Modules.Concours.Entities.Distances

Namespace Controls
 Public Class FlightList
  Inherits ModuleBase

  Public Property UserOnly As Boolean = False
  Public Property Validated As Boolean = True
  Public Property Paginate As Boolean = True

  Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
   LocalResourceFile = "DesktopModules/Albatros/Concours/App_LocalResources/SharedResources"
  End Sub

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

   If Not Me.IsPostBack Then
    grdFlights.AllowPaging = Paginate
   End If

  End Sub

  Public Sub GetFlights()

   Dim sortorder As String = "FLIGHTSTART DESC"
   If grdFlights.MasterTableView.SortExpressions.Count > 0 Then
    If grdFlights.MasterTableView.SortExpressions(0).SortOrder = Telerik.Web.UI.GridSortOrder.Descending Then
     sortorder = String.Format("{0} DESC", grdFlights.MasterTableView.SortExpressions(0).FieldName).ToUpper
    Else
     sortorder = String.Format("{0}", grdFlights.MasterTableView.SortExpressions(0).FieldName).ToUpper
    End If
   End If
   Dim total As Integer = 0
   Dim pageIndex As Integer = -1
   Dim pageSize As Integer = 10
   If Paginate Then
    pageIndex = grdFlights.CurrentPageIndex
    pageSize = grdFlights.PageSize
   End If
   If UserOnly Then
    grdFlights.DataSource = DistancesController.GetDistancesByUser(UserId, ModuleId, pageIndex, pageSize, sortorder, total)
   Else
    grdFlights.DataSource = DistancesController.GetDistancesByModule(ModuleId, Validated, pageIndex, pageSize, sortorder, total)
   End If
   grdFlights.VirtualItemCount = total

  End Sub

  Public Sub RebindPosts()
   GetFlights()
   grdFlights.Rebind()
  End Sub

 End Class
End Namespace
