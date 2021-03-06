Imports System
Imports System.Runtime.Serialization

Namespace Entities.Distances
  Partial Public Class DistanceInfo

#Region " Public Methods "
  Public Sub CalculateTotals()

   Dim pointA As New Common.Coordinates
   Dim pointB As New Common.Coordinates

   If String.IsNullOrEmpty(ACoords) Then
    pointA.Latitude = StartLatitude
    pointA.Longitude = StartLongitude
    Summary = StartDescription
   Else
    pointA.Latitude = ALatitude
    pointA.Longitude = ALongitude
    Summary = ADescription
   End If

   If String.IsNullOrEmpty(BCoords) Then
    pointB.Latitude = LandingLatitude
    pointB.Longitude = LandingLongitude
   Else
    pointB.Latitude = BLatitude
    pointB.Longitude = BLongitude
   End If

   Dim ABDistance As Double = Common.Globals.DistanceBetweenPlaces(pointA.Longitude, pointA.Latitude, pointB.Longitude, pointB.Latitude)

   Select Case FlightType
    Case Common.FlightType.FreeDistance
     TotalDistance = ABDistance
     TotalPoints = TotalDistance
    Case Common.FlightType.OpenTriangle
     TotalDistance = Common.Globals.DistanceBetweenPlaces(pointA.Longitude, pointA.Latitude, C1Longitude, C1Latitude)
     TotalDistance += Common.Globals.DistanceBetweenPlaces(C1Longitude, C1Latitude, pointB.Longitude, pointB.Latitude)
     TotalPoints = TotalDistance
     Summary &= " - " & C1Description
    Case Common.FlightType.ReturnFlight
     TotalDistance = Common.Globals.DistanceBetweenPlaces(pointA.Longitude, pointA.Latitude, C1Longitude, C1Latitude)
     TotalDistance += Common.Globals.DistanceBetweenPlaces(C1Longitude, C1Latitude, pointA.Longitude, pointA.Latitude)
     If TotalDistance > 20 Then
      If ABDistance * 5 > TotalDistance Then ' not closed!
       FlightType = Common.FlightType.OpenTriangle
       TotalPoints = TotalDistance
      Else
       TotalPoints = TotalDistance * 1.3
      End If
     Else
      If ABDistance > 4 Then ' not closed!
       FlightType = Common.FlightType.OpenTriangle
       TotalPoints = TotalDistance
      Else
       TotalPoints = TotalDistance * 1.3
      End If
     End If
     Summary &= " - " & C1Description
    Case Common.FlightType.Triangle
     TotalDistance = Common.Globals.DistanceBetweenPlaces(pointA.Longitude, pointA.Latitude, C1Longitude, C1Latitude)
     TotalDistance += Common.Globals.DistanceBetweenPlaces(C1Longitude, C1Latitude, C2Longitude, C2Latitude)
     TotalDistance += Common.Globals.DistanceBetweenPlaces(C2Longitude, C2Latitude, pointB.Longitude, pointB.Latitude)
     If TotalDistance > 20 Then
      If ABDistance * 5 > TotalDistance Then ' not closed!
       FlightType = Common.FlightType.OpenTriangle
       TotalPoints = TotalDistance
      Else
       TotalPoints = TotalDistance * 1.3
      End If
     Else
      If ABDistance > 4 Then ' not closed!
       FlightType = Common.FlightType.OpenTriangle
       TotalPoints = TotalDistance
      Else
       TotalPoints = TotalDistance * 1.3
      End If
     End If
     Summary &= " - " & C1Description
     Summary &= " - " & C2Description
   End Select

   If String.IsNullOrEmpty(BCoords) Then
    If LandingDescription = "" Then
     Summary &= " - " & DotNetNuke.Services.Localization.Localization.GetString("Outside", Common.Globals.glbSharedResources)
    Else
     Summary &= " - " & LandingDescription
    End If
   Else
    Summary &= " - " & BDescription
   End If

  End Sub
#End Region

 End Class
End Namespace


