<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FlightList.ascx.vb" Inherits="Albatros.DNN.Modules.Concours.Controls.FlightList" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>

  <dnn:DNNGrid id="grdFlights" autogeneratecolumns="false" cssclass="dnnGrid dnnSecurityRolesGrid"
   runat="server" allowcustompaging="True" enableviewstate="True" allowsorting="true"
   onneeddatasource="GetFlights">
   <MasterTableView>
    <Columns>
     <dnn:DnnGridBoundColumn datafield="PilotDisplayName" headertext="Pilot" />
     <dnn:DnnGridBoundColumn datafield="FlightStart" headertext="Date" DataFormatString="{0:d}" />
     <dnn:DnnGridBoundColumn datafield="Summary" headertext="Path" />
     <dnn:DnnGridTemplateColumn HeaderText="FlightType">
      <ItemTemplate>
       <%#Albatros.DNN.Modules.Concours.Common.Globals.ConvertToFlightTypeName(CInt(Eval("FlightType")))%>
      </ItemTemplate>
     </dnn:DnnGridTemplateColumn>
     <dnn:DnnGridBoundColumn datafield="TotalDistance" headertext="Distance" />
     <dnn:DnnGridBoundColumn datafield="TotalPoints" headertext="Points" />
     <dnn:DnnGridTemplateColumn HeaderText="Actions">
      <ItemStyle Width="90px"></ItemStyle>
      <ItemTemplate>
       <a href="<%# EditUrl("DistanceId", Eval("DistanceId"), "DistanceView") %>" 
          class="" 
          title="View"
          >View</a>
      </ItemTemplate>
     </dnn:DnnGridTemplateColumn>
    </Columns>
   </MasterTableView>
  </dnn:DNNGrid>
