<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Concours.ascx.vb" Inherits="Albatros.DNN.Modules.Concours.Concours" %>
<%@ Register TagPrefix="concours" TagName="RankingsTable" Src="~/DesktopModules/Albatros/Concours/Controls/RankingsTable.ascx" %>
<%@ Register TagPrefix="concours" TagName="FlightList" Src="~/DesktopModules/Albatros/Concours/Controls/FlightList.ascx" %>

<asp:LinkButton runat="server" ID="cmdAddDistance" resourcekey="cmdAddDistance" Visible="false" CssClass="dnnSecondaryAction" />


<div class="dnnForm" id="concoursTabs">
<ul class="dnnAdminTabNav">
  <li><a href="#Rankings"><%=LocalizeString("Rankings")%></a></li>
  <li><a href="#LatestFlights"><%=LocalizeString("LatestFlights")%></a></li>
  <li runat="server" id="tabMyFlights"><a href="#MyFlights"><%=LocalizeString("MyFlights")%></a></li>
  <li runat="server" id="tabUnvalidatedFlights"><a href="#UnvalidatedFlights"><%=LocalizeString("UnvalidatedFlights")%></a></li>
</ul>
<div id="Rankings" class="dnnClear">
<concours:RankingsTable runat="server" id="ctlParaRankings" CategoryId="0" />
<concours:RankingsTable runat="server" id="ctlDeltaRankings" CategoryId="1" />
<concours:RankingsTable runat="server" id="ctlRigidRankings" CategoryId="2" />
</div>
<div id="MyFlights" class="dnnClear">
 <concours:FlightList runat="server" id="ctlMyFlightList" UserOnly="True" />
</div>
<div id="LatestFlights" class="dnnClear">
 <concours:FlightList runat="server" id="ctlLatestFlightsList" UserOnly="False" Validated="True" Paginate="False" />
</div>
<div id="UnvalidatedFlights" class="dnnClear">
 <concours:FlightList runat="server" id="ctlUnvalidatedFlightsList" UserOnly="False" Validated="False" />
</div>
</div>

<script type="text/javascript">
 jQuery(function ($) {
  $('#concoursTabs').dnnTabs();
 });
</script>
