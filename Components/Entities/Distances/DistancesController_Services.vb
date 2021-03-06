Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Json
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Xml
Imports DotNetNuke.Web.Api

Namespace Entities.Distances
 Partial Public Class DistancesController
  Inherits DnnApiController

  'Public Class ListSitesDTO
  ' Public Property StartString As String
  'End Class

  Public Structure Site
   Public Property label As String
   Public Property value As String
   Public Property coords As String
  End Structure

#Region " Service Methods "
  <HttpGet()>
  <ValidateAntiForgeryToken()>
  <ActionName("ListSites")>
  <DnnModuleAuthorize(accesslevel:=DotNetNuke.Security.SecurityAccessLevel.View)>
  Public Function ListSites() As HttpResponseMessage

   Dim startString As String = HttpContext.Current.Request.Params("StartString")

   Dim res As New List(Of Site)
   Using dr As IDataReader = Albatros.DNN.Modules.Concours.Data.DataProvider.Instance.ListSites(startString)
    Do While dr.Read
     Dim s As New Site With {.label = CStr(dr.Item("Description")), .value = CStr(dr.Item("Description")), .coords = CStr(dr.Item("Coords"))}
     res.Add(s)
    Loop
   End Using

   Return Request.CreateResponse(HttpStatusCode.OK, res)

  End Function

  Public Structure dtObject
   Public aaData As List(Of DistanceInfo)
   Public totalRecs As Integer
  End Structure
#End Region

 End Class
End Namespace

