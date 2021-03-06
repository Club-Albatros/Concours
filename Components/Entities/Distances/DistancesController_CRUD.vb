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

  Public Shared Function AddDistance(ByRef objDistance As DistanceInfo, createdByUser As Integer) As Integer

  objDistance.DistanceId = CType(DataProvider.Instance().AddDistance(objDistance.ACoords, objDistance.ModuleId, objDistance.ADescription, objDistance.ALatitude, objDistance.ALongitude, objDistance.ATime, objDistance.BCoords, objDistance.BDescription, objDistance.BLatitude, objDistance.BLongitude, objDistance.BTime, objDistance.C1Coords, objDistance.C1Description, objDistance.C1Latitude, objDistance.C1Longitude, objDistance.C2Coords, objDistance.C2Description, objDistance.C2Latitude, objDistance.C2Longitude, objDistance.Category, objDistance.Comments, objDistance.FlightStart, objDistance.FlightType, objDistance.LandingCoords, objDistance.LandingDescription, objDistance.LandingLatitude, objDistance.LandingLongitude, objDistance.LandingTime, objDistance.Rejected, objDistance.StartCoords, objDistance.StartDescription, objDistance.StartLatitude, objDistance.StartLongitude, objDistance.Summary, objDistance.TotalDistance, objDistance.TotalPoints, objDistance.UserId, objDistance.Validated, objDistance.ValidatedByUserID, objDistance.ValidatedOnDate, createdByUser), Integer)
   Return objDistance.DistanceId

  End Function

 Public Shared Sub UpdateDistance(objDistance As DistanceInfo, updatedByUser As Integer)
	
  DataProvider.Instance().UpdateDistance(objDistance.ACoords, objDistance.ModuleId, objDistance.ADescription, objDistance.ALatitude, objDistance.ALongitude, objDistance.ATime, objDistance.BCoords, objDistance.BDescription, objDistance.BLatitude, objDistance.BLongitude, objDistance.BTime, objDistance.C1Coords, objDistance.C1Description, objDistance.C1Latitude, objDistance.C1Longitude, objDistance.C2Coords, objDistance.C2Description, objDistance.C2Latitude, objDistance.C2Longitude, objDistance.Category, objDistance.Comments, objDistance.DistanceId, objDistance.FlightStart, objDistance.FlightType, objDistance.LandingCoords, objDistance.LandingDescription, objDistance.LandingLatitude, objDistance.LandingLongitude, objDistance.LandingTime, objDistance.Rejected, objDistance.StartCoords, objDistance.StartDescription, objDistance.StartLatitude, objDistance.StartLongitude, objDistance.Summary, objDistance.TotalDistance, objDistance.TotalPoints, objDistance.UserId, objDistance.Validated, objDistance.ValidatedByUserID, objDistance.ValidatedOnDate, updatedByUser)
	
 End Sub

 Public Shared Sub DeleteDistance(distanceId As Int32)
	
  DataProvider.Instance().DeleteDistance(distanceId)

 End Sub

 End Class
End Namespace

