<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DistanceEdit.ascx.vb" Inherits="Albatros.DNN.Modules.Concours.DistanceEdit" %>
<%@ Register TagPrefix="dnnweb" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<fieldset>
	<div class="dnnFormItem">
  <dnn:label id="lblFlightDate" runat="server" controlname="dpFlightDate" suffix=":" />
		<dnnweb:DnnDatePicker ID="dpFlightDate" runat="server" />
  <asp:requiredfieldvalidator id="reqFlightDate" resourcekey="Required.ErrorMessage" CssClass="dnnFormMessage dnnFormError" runat="server" controltovalidate="dpFlightDate" display="Dynamic" />
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblCategory" runat="server" controlname="ddCategory" suffix=":" />
  <asp:DropDownList runat="server" ID="ddCategory">
   <asp:ListItem Value="0" ResourceKey="Paraglider" />
   <asp:ListItem Value="1" ResourceKey="Delta" />
   <asp:ListItem Value="2" ResourceKey="Rigid" />
  </asp:DropDownList>
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblFlightType" runat="server" controlname="ddFlightType" suffix=":" />
  <asp:DropDownList runat="server" ID="ddFlightType">
   <asp:ListItem Value="0" ResourceKey="FreeDistance" />
   <asp:ListItem Value="1" ResourceKey="OpenTriangle" />
   <asp:ListItem Value="2" ResourceKey="ReturnFlight" />
   <asp:ListItem Value="3" ResourceKey="Triangle" />
  </asp:DropDownList>
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblComments" runat="server" controlname="txtComments" suffix=":" />
  <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" Height="100" />
	</div>
	<div class="dnnFormItem" id="trSummary" runat="server">
  <dnn:label id="lblSummary" runat="server" controlname="txtSummary" suffix=":" />
  <asp:TextBox runat="server" ID="txtSummary" TextMode="MultiLine" Height="100" />
	</div>
	<div class="dnnFormItem" id="trTotalDistance" runat="server">
  <dnn:label id="lblTotalDistance" runat="server" controlname="txtTotalDistance" suffix=":" />
  <asp:TextBox runat="server" ID="txtTotalDistance" Width="30" />
  <asp:RegularExpressionValidator runat="server" ID="regTotalDistance" resourcekey="InvalidNumber.ErrorMessage" CssClass="dnnFormMessage dnnFormError" controltovalidate="txtTotalDistance" display="Dynamic" ValidationExpression="\d+([\.,]?)\d?" />
	</div>
	<div class="dnnFormItem" id="trTotalPoints" runat="server">
  <dnn:label id="lblTotalPoints" runat="server" controlname="txtTotalPoints" suffix=":" />
  <asp:TextBox runat="server" ID="txtTotalPoints" Width="30" />
  <asp:RegularExpressionValidator runat="server" ID="regTotalPoints" resourcekey="InvalidInteger.ErrorMessage" CssClass="dnnFormMessage dnnFormError" controltovalidate="txtTotalPoints" display="Dynamic" ValidationExpression="\d+" />
	</div>
</fieldset>

<div class="dnnFormMessage">
 <%=LocalizeString("helpPoints")%>
</div>

<table class="concours concours_input dnnFormItem">
 <thead>
  <tr>
   <th><%=LocalizeString("Point")%></th>
   <th><%=LocalizeString("Description")%></th>
   <th><%=LocalizeString("Time")%></th>
   <th><%=LocalizeString("Coordinates")%></th>
  </tr>
 </thead>
 <tbody>
  <tr>
   <td><%=LocalizeString("Start")%></td>
   <td>
    <asp:TextBox runat="server" ID="txtDescriptionStart" Width="200" />
    <asp:requiredfieldvalidator id="reqDescriptionStart" resourcekey="Required.ErrorMessage" CssClass="dnnFormMessage dnnFormError" runat="server" controltovalidate="txtDescriptionStart" display="Dynamic" />
   </td>
   <td>
    <dnnweb:DnnTimePicker ID="tpTimeStart" runat="server" TimeView-Columns="4" ShowPopupOnFocus="true" CssClass="dateFix" />
    <asp:requiredfieldvalidator id="reqTimeStart" resourcekey="Required.ErrorMessage" CssClass="dnnFormMessage dnnFormError" runat="server" controltovalidate="tpTimeStart" display="Dynamic" />
   </td>
   <td>
    <asp:TextBox runat="server" ID="txtCoordinatesStart" Width="200" />
    <asp:requiredfieldvalidator id="reqCoordinatesStart" resourcekey="Required.ErrorMessage" CssClass="dnnFormMessage dnnFormError" runat="server" controltovalidate="txtCoordinatesStart" display="Dynamic" />
    <asp:RegularExpressionValidator runat="server" ID="regCoordinatesStart" resourcekey="InvalidCoordinates.ErrorMessage" CssClass="dnnFormMessage dnnFormError" controltovalidate="txtCoordinatesStart" display="Dynamic" ValidationExpression="\d{6}\s*/\s*\d{6}" />
   </td>
  </tr>
  <tr>
   <td><dnn:label id="lblA" runat="server" controlname="txtDescriptionA" suffix="" /></td>
   <td>
    <asp:TextBox runat="server" ID="txtDescriptionA" Width="200" />
   </td>
   <td>
    <dnnweb:DnnTimePicker ID="tpTimeA" runat="server" TimeView-Columns="4" ShowPopupOnFocus="true" CssClass="dateFix" />
   </td>
   <td>
    <asp:TextBox runat="server" ID="txtCoordinatesA" Width="200" />
    <asp:RegularExpressionValidator runat="server" ID="regCoordinatesA" resourcekey="InvalidCoordinates.ErrorMessage" CssClass="dnnFormMessage dnnFormError" controltovalidate="txtCoordinatesA" display="Dynamic" ValidationExpression="\d{6}\s*/\s*\d{6}" />
   </td>
  </tr>
  <tr id="trC1">
   <td><dnn:label id="lblC1" runat="server" controlname="txtDescriptionC1" suffix="" /></td>
   <td>
    <asp:TextBox runat="server" ID="txtDescriptionC1" Width="200" />
   </td>
   <td>
   </td>
   <td>
    <asp:TextBox runat="server" ID="txtCoordinatesC1" Width="200" />
   </td>
  </tr>
  <tr id="trC2">
   <td><dnn:label id="lblC2" runat="server" controlname="txtDescriptionC2" suffix="" /></td>
   <td>
    <asp:TextBox runat="server" ID="txtDescriptionC2" Width="200" />
   </td>
   <td>
   </td>
   <td>
    <asp:TextBox runat="server" ID="txtCoordinatesC2" Width="200" />
   </td>
  </tr>
  <tr>
   <td><dnn:label id="lblB" runat="server" controlname="txtDescriptionB" suffix="" /></td>
   <td>
    <asp:TextBox runat="server" ID="txtDescriptionB" Width="200" />
   </td>
   <td>
    <dnnweb:DnnTimePicker ID="tpTimeB" runat="server" TimeView-Columns="4" ShowPopupOnFocus="true" CssClass="dateFix" />
   </td>
   <td>
    <asp:TextBox runat="server" ID="txtCoordinatesB" Width="200" />
   </td>
  </tr>
  <tr>
   <td><%=LocalizeString("Landing")%></td>
   <td>
    <asp:TextBox runat="server" ID="txtDescriptionLanding" Width="200" />
    <asp:requiredfieldvalidator id="reqDescriptionLanding" resourcekey="Required.ErrorMessage" CssClass="dnnFormMessage dnnFormError" runat="server" controltovalidate="txtDescriptionLanding" display="Dynamic" />
   </td>
   <td>
    <dnnweb:DnnTimePicker ID="tpTimeLanding" runat="server" TimeView-Columns="4" ShowPopupOnFocus="true" CssClass="dateFix" />
    <asp:requiredfieldvalidator id="reqTimeLanding" resourcekey="Required.ErrorMessage" CssClass="dnnFormMessage dnnFormError" runat="server" controltovalidate="tpTimeLanding" display="Dynamic" />
   </td>
   <td>
    <asp:TextBox runat="server" ID="txtCoordinatesLanding" Width="200" />
    <asp:requiredfieldvalidator id="reqCoordinatesLanding" resourcekey="Required.ErrorMessage" CssClass="dnnFormMessage dnnFormError" runat="server" controltovalidate="txtCoordinatesLanding" display="Dynamic" />
    <asp:RegularExpressionValidator runat="server" ID="regCoordinatesLanding" resourcekey="InvalidCoordinates.ErrorMessage" CssClass="dnnFormMessage dnnFormError" controltovalidate="txtCoordinatesLanding" display="Dynamic" ValidationExpression="\d{6}\s*/\s*\d{6}" />
   </td>
  </tr>
 </tbody>
</table>


<p>
 <asp:LinkButton runat="server" ID="cmdCancel" CssClass="dnnSecondaryAction" ResourceKey="cmdCancel" CausesValidation="false" />
 <asp:LinkButton runat="server" ID="cmdSubmit" CssClass="dnnPrimaryAction" ResourceKey="cmdSubmit" />
</p>

<script>
(function ($, Sys) {
 $(document).ready(function () {

  setRowVisibilities($('#<%=ddFlightType.ClientID%>').children('option:selected').val());

  $('#<%=ddFlightType.ClientID%>').change(function () {
   setRowVisibilities($(this).children('option:selected').val());
  });

  hookUpSiteBox('<%=txtDescriptionStart.ClientID%>', '<%=txtCoordinatesStart.ClientID%>');
  hookUpSiteBox('<%=txtDescriptionA.ClientID%>', '<%=txtCoordinatesA.ClientID%>');
  hookUpSiteBox('<%=txtDescriptionC1.ClientID%>', '<%=txtCoordinatesC1.ClientID%>');
  hookUpSiteBox('<%=txtDescriptionC2.ClientID%>', '<%=txtCoordinatesC2.ClientID%>');
  hookUpSiteBox('<%=txtDescriptionB.ClientID%>', '<%=txtCoordinatesB.ClientID%>');
  hookUpSiteBox('<%=txtDescriptionLanding.ClientID%>', '<%=txtCoordinatesLanding.ClientID%>');

 });

 function hookUpSiteBox(textId, coordsId) {
  $('#' + textId).autocomplete({
   source: function (request, response) {
    concoursService.listSites(request.term, function (data) {
     response(data)
    })
   },
   select: function (event, ui) {
    $('#' + coordsId).val(ui.item.coords);
   }
  })
 };

 function setRowVisibilities(flightType) {
  switch (flightType) {
   case '0':
    $('#trC1').hide();
    $('#trC2').hide();
    break;
   case '1':
    $('#trC1').show();
    $('#trC2').hide();
    break;
   case '2':
    $('#trC1').show();
    $('#trC2').hide();
    break;
   default:
    $('#trC1').show();
    $('#trC2').show();
  };
  positionValidators();
 };

 function positionValidators() {
  $('.concours_input .dnnFormError').css('top', function () {
   return $(this).parent().children().eq(0).offset().top - 40 + 'px';
  }).css('left', function () {
   return $(this).parent().children().eq(0).offset().left + $(this).parent().children().eq(0).width() - 30 + 'px';
  });

  $('div.dnnFormItem .dnnFormError').css('top', function () {
   return $(this).parent().children().eq(1).offset().top - 40 + 'px';
  }).css('left', function () {
   return $(this).parent().children().eq(1).offset().left + $(this).parent().children().eq(1).width() - 60 + 'px';
  });
 }

} (jQuery, window.Sys));

</script>

