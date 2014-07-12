Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Json
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Xml
Imports DotNetNuke.Web.Api
Imports Albatros.DNN.Modules.Concours.Common.Globals

Namespace Rss

 Public Class RssController
  Inherits DnnApiController
  Implements IServiceRouteMapper

#Region " IServiceRouteMapper "
  Public Sub RegisterRoutes(mapRouteManager As DotNetNuke.Web.Api.IMapRoute) Implements DotNetNuke.Web.Api.IServiceRouteMapper.RegisterRoutes
   mapRouteManager.MapHttpRoute("Albatros/Concours", "Rss", "Rss", New With {.Controller = "Rss", .Action = "GetRssFeed"}, New String() {"Albatros.DNN.Modules.Concours.Rss"})
  End Sub
#End Region

#Region " Service Methods "
  <HttpGet()>
  <AllowAnonymous()>
  Public Function GetRssFeed() As HttpResponseMessage
   Dim res As New HttpResponseMessage(HttpStatusCode.OK)
   Dim queryString As NameValueCollection = HttpUtility.ParseQueryString(Me.Request.RequestUri.Query)
   Dim feed As New RssFeed(queryString)
   res.Content = New StringContent(ReadFile(feed.CacheFile), System.Text.Encoding.UTF8, "application/xml")
   Return res
  End Function
#End Region

 End Class

End Namespace