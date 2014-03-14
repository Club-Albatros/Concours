<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DistanceView.ascx.vb" Inherits="Albatros.DNN.Modules.Concours.DistanceView" %>
<%@ Register TagPrefix="dnnweb" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<h2><%=LocalizeString("FlightData")%></h2>
<fieldset>
	<div class="dnnFormItem">
  <dnn:label id="lblPilot" runat="server" suffix=":" />
  <span><%= DistanceTask.PilotDisplayName %></span>
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblFlightDate" runat="server" suffix=":" />
  <span><%= DistanceTask.FlightStart.ToString("dd.MM.yyyy") %></span>
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblSummary" runat="server" suffix=":" />
  <span><%= DistanceTask.Summary %>&nbsp;</span>
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblCategory" runat="server" suffix=":" />
  <span><%= Albatros.DNN.Modules.Concours.Common.Globals.ConvertToCategoryName(DistanceTask.Category) %></span>
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblFlightType" runat="server" suffix=":" />
  <asp:Image runat="server" ID="imgFlightType" />
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblComments" runat="server" suffix=":" />
  <span><%= DistanceTask.Comments.Replace(vbCrLf, "<br />")%>&nbsp;</span>
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblTotalDistance" runat="server" suffix=":" />
  <span><%= DistanceTask.TotalDistance.ToString("0.0") %></span>
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblTotalPoints" runat="server" suffix=":" />
  <span><%= DistanceTask.TotalPoints.ToString("0.0")%></span>
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblLastModified" runat="server" suffix=":" />
  <span><%= String.Format(LocalizeString("LastModifiedFormat"), DistanceTask.LastModifiedOnDate, DistanceTask.LastModifiedByDisplayName) %></span>
	</div>
	<div class="dnnFormItem">
  <dnn:label id="lblValidated" runat="server" suffix=":" />
  <span><%= IIf(DistanceTask.ValidatedOnDate=DateTime.MinValue, LocalizeString("NotValidated"), String.Format(LocalizeString("LastModifiedFormat"), DistanceTask.ValidatedOnDate, DistanceTask.ValidatedByDisplayName))%></span>
	</div>
	<div class="dnnFormItem" ruat="server" id="divUpload">
	</div>
</fieldset>

<h2><%=LocalizeString("FlightPath")%></h2>
<table class="concours">
 <thead>
  <tr>
   <th><%=LocalizeString("Point")%></th>
   <th><%=LocalizeString("Description")%></th>
   <th><%=LocalizeString("Time")%></th>
   <th><%=LocalizeString("Coordinates")%></th>
  </tr>
 </thead>
 <tbody>
<asp:Repeater runat="server" ID="rpPoints">
 <ItemTemplate>
  <tr>
   <td><%#Container.DataItem.Name%></td>
   <td><%#Container.DataItem.Description%></td>
   <td><%#IIf(CBool(Container.DataItem.Time = DateTime.MinValue), "", CDate(Container.DataItem.Time).ToString("HH:mm"))%></td>
   <td><%#Container.DataItem.Coords%></td>
  </tr>
 </ItemTemplate>
</asp:Repeater>
 </tbody>
</table>

<h2><%=LocalizeString("Files")%></h2>
<asp:Repeater runat="server" ID="rpFiles">
 <ItemTemplate>
  <div class="concours_file">
   <div class="concours_file_thumbnail">&nbsp;</div>
   <div class="concours_file_link">
    <a href="<%= Albatros.DNN.Modules.Concours.Common.Globals.GetDistanceDirectoryPath(DistanceId) %><%#Container.DataItem.Name%>" target="_blank"><%#Container.DataItem.Name%></a>
   </div>
  </div>
 </ItemTemplate>
</asp:Repeater>

<h2><%=LocalizeString("Images")%></h2>
<asp:Repeater runat="server" ID="rpImages">
 <ItemTemplate>
  <div class="concours_file">
   <div class="concours_file_thumbnail">
    <a href="<%= ResolveUrl(Albatros.DNN.Modules.Concours.Common.Globals.ModuleRelPath & "Image.ashx") %>?DistanceId=<%= DistanceId %>&Filename=<%#System.IO.Path.GetFilenameWithoutExtension(Container.DataItem.Name)%>&w=800&h=800&c=false" target="_blank">
     <img src="<%= ResolveUrl(Albatros.DNN.Modules.Concours.Common.Globals.ModuleRelPath & "Image.ashx") %>?DistanceId=<%= DistanceId %>&Filename=<%#System.IO.Path.GetFilenameWithoutExtension(Container.DataItem.Name)%>&w=80&h=80&c=true" alt="<%#Container.DataItem.Name%>" />
    </a>
   </div>
   <div class="concours_file_link">
    <a href="<%= Albatros.DNN.Modules.Concours.Common.Globals.GetDistanceDirectoryPath(DistanceId) %><%#Container.DataItem.Name%>" target="_blank">
     <%#Container.DataItem.Name%>
    </a>
   </div>
  </div>
 </ItemTemplate>
</asp:Repeater>


<p runat="server" id="ctlUploadContainer">
 <dnn:label id="lblAddFile" runat="server" suffix=":" />
 <asp:FileUpload runat="server" ID="ctlFileUpload" />
 <asp:Button runat="server" ID="cmdUpload" ResourceKey="cmdUpload" CssClass="dnnSecondaryAction" />
</p>

<p>
 <asp:LinkButton runat="server" ID="cmdCancel" resourcekey="cmdCancel" Visible="true" CssClass="dnnSecondaryAction" />
 <asp:LinkButton runat="server" ID="cmdEdit" resourcekey="cmdEdit" Visible="false" CssClass="dnnSecondaryAction" />
 <asp:LinkButton runat="server" ID="cmdDelete" resourcekey="cmdDelete" Visible="false" CssClass="dnnSecondaryAction" />
 <asp:LinkButton runat="server" ID="cmdValidate" resourcekey="cmdValidate" Visible="false" CssClass="dnnSecondaryAction" />
</p>

<script type="text/javascript">
 jQuery(function ($) {
  $('a[href*="Image.ashx"]').colorbox({ photo: true });
  $("tr:odd").addClass("concours_table_odd");
 });
</script>

