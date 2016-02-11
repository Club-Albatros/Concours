<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FlightList.ascx.vb" Inherits="Albatros.DNN.Modules.Concours.Controls.FlightList" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web.Deprecated" Namespace="DotNetNuke.Web.UI.WebControls" %>

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
     <dnn:DnnGridBoundColumn datafield="TotalDistance" headertext="Distance" DataFormatString="{0:0.0}" />
     <dnn:DnnGridBoundColumn datafield="TotalPoints" headertext="Points" DataFormatString="{0:0.0}" />
     <dnn:DnnGridTemplateColumn HeaderText="Actions">
      <ItemStyle Width="30px"></ItemStyle>
      <ItemTemplate>
       <a href="<%# EditUrl("DistanceId", Eval("DistanceId"), "DistanceView") %>" 
          class="" 
          title="<%= LocalizeString("View") %>"
          ><img width="16" height="16" src="<%= ResolveUrl("~/DesktopModules/Albatros/Concours/images/view.png") %>" /></a>
      </ItemTemplate>
     </dnn:DnnGridTemplateColumn>
     <dnn:DnnGridTemplateColumn HeaderText="">
      <ItemStyle Width="30px"></ItemStyle>
      <ItemTemplate>
       <img width="16" height="16" src="<%= ResolveUrl("~/DesktopModules/Albatros/Concours/images/") %><%# IIF(CBool(Eval("Validated")), "validated.png", IIF(CBool(Eval("Rejected")), "rejected.png", "unvalidated.png")) %>" alt="<%# IIF(CBool(Eval("Validated")), LocalizeString("Validated"), IIF(CBool(Eval("Rejected")), LocalizeString("Rejected"), LocalizeString("Unvalidated"))) %>" />
      </ItemTemplate>
     </dnn:DnnGridTemplateColumn>
    </Columns>
   </MasterTableView>
  </dnn:DNNGrid>
