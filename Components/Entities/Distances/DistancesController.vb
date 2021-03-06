Imports System
Imports System.Data
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Imports DotNetNuke
Imports DotNetNuke.Common
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Entities.Portals
Imports DotNetNuke.Services.Tokens

Imports Albatros.DNN.Modules.Concours.Data

Namespace Entities.Distances

 Partial Public Class DistancesController

  Public Shared Function GetDistance(distanceId As Int32, moduleId As Integer) As DistanceInfo

   Return CType(CBO.FillObject(DataProvider.Instance().GetDistance(distanceId, moduleId), GetType(DistanceInfo)), DistanceInfo)

  End Function

 End Class
End Namespace

