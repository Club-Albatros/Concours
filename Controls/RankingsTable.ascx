<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RankingsTable.ascx.vb" Inherits="Albatros.DNN.Modules.Concours.Controls.RankingsTable" %>

<h2><%= Albatros.DNN.Modules.Concours.Common.Globals.ConvertToCategoryName(CategoryId) %></h2>
<table class="concours concours_rankings">
 <thead>
  <tr>
   <th><%=LocalizeString("Rank")%></th>
   <th><%=LocalizeString("Pilot")%></th>
   <th style="text-align:right;"><%=LocalizeString("TotalPoints")%></th>
   <th><%=LocalizeString("Date")%></th>
   <th><%=LocalizeString("Path")%></th>
   <th style="text-align:right;"><%=LocalizeString("Distance")%></th>
   <th style="text-align:right;"><%=LocalizeString("Points")%></th>
   <th><%=LocalizeString("FlightType")%></th>
  </tr>
 </thead>
<asp:Repeater runat="server" ID="rpRankingsPara">
 <ItemTemplate>
  <tr class="<%#IIf(CInt(Container.DataItem.Item("FlightRank"))=1, "concours_ranking_firstrow","")%>">
   <td style="font-weight:bold;"><%#IIf(CInt(Container.DataItem.Item("FlightRank"))=1, Container.DataItem.Item("PilotRanking"),"")%></td>
   <td><%#IIf(CInt(Container.DataItem.Item("FlightRank"))=1, Container.DataItem.Item("PilotDisplayName"),"")%></td>
   <td style="text-align:right;font-weight:bold;"><%#IIf(CInt(Container.DataItem.Item("FlightRank"))=1, CDbl(Container.DataItem.Item("AggregatePoints")).ToString("0.0"),"")%></td>
   <td>
    <a href="<%# EditUrl("DistanceId", CStr(Container.DataItem.Item("DistanceId")), "DistanceView")%>">
    <%#CDate(Container.DataItem.Item("FlightStart")).ToString("dd.MM")%>
    </a>
   </td>
   <td>
    <a href="<%# EditUrl("DistanceId", CStr(Container.DataItem.Item("DistanceId")), "DistanceView")%>"><%#Container.DataItem.Item("Summary")%></a>
    </td>
   <td style="text-align:right;"><%#CDbl(Container.DataItem.Item("TotalDistance")).ToString("0.0")%></td>
   <td style="text-align:right;"><%#CDbl(Container.DataItem.Item("TotalPoints")).ToString("0.0")%></td>
   <td><%#Albatros.DNN.Modules.Concours.Common.Globals.ConvertToFlightTypeName(CInt(Container.DataItem.Item("FlightType")))%></td>
  </tr>
 </ItemTemplate>
</asp:Repeater>
</table>
