Option Strict On
Option Explicit On

Imports DotNetNuke.Web.Api

Public Class ConcoursRouteMapper

 Implements IServiceRouteMapper

 Public Enum ServiceControllers
  Distance
 End Enum

 Public Const ServicePath As String = "~/DesktopModules/Albatros/Concours/API/"

 Public Sub RegisterRoutes(mapRouteManager As IMapRoute) Implements IServiceRouteMapper.RegisterRoutes
  mapRouteManager.MapHttpRoute("Albatros/Concours", "Distances", "Distances/{action}", New With {.Controller = "Distances"}, New String() {"Albatros.DNN.Modules.Concours.Entities.Distances"})
  'mapRouteManager.MapHttpRoute("Albatros/Concours", "Other", "{controller}/{action}", New String() {"DotNetNuke.Modules.Blog.Services", "DotNetNuke.Modules.Blog.Integration.Services"})
 End Sub

 Public Shared Function GetRoute(controller As ServiceControllers, method As String) As String
  Select Case controller
   Case ServiceControllers.Distance
    Return GetRoute("Distances", method)
   Case Else
    Return GetRoute("Distances", method)
  End Select
 End Function

 Public Shared Function GetRoute(controller As String, method As String) As String
  Return HttpContext.Current.Request.Url.Scheme & "://" & HttpContext.Current.Request.Url.Host & DotNetNuke.Common.ResolveUrl(ServicePath & controller & "/" & method)
 End Function

End Class
