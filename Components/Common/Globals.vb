Namespace Common
 Public Enum FlightType
  FreeDistance = 0
  OpenTriangle = 1
  ReturnFlight = 2
  Triangle = 3
 End Enum

 Public Enum FlightCategory
  Paraglider = 0
  Delta = 1
  Rigid = 2
 End Enum

 Public Structure Coordinates
  Public Latitude As Double
  Public Longitude As Double
 End Structure

 Public Class Globals

  Public Const ModuleRelPath As String = "~/DesktopModules/Albatros/Concours/"

  Public Shared Function DistanceBetweenPlaces(lon1 As Double, lat1 As Double, lon2 As Double, lat2 As Double) As Double
   Dim R As Double = 6371 ' km
   Dim sLat1 As Double = Math.Sin(DegsToRadians(lat1))
   Dim sLat2 As Double = Math.Sin(DegsToRadians(lat2))
   Dim cLat1 As Double = Math.Cos(DegsToRadians(lat1))
   Dim cLat2 As Double = Math.Cos(DegsToRadians(lat2))
   Dim cLon As Double = Math.Cos(DegsToRadians(lon1) - DegsToRadians(lon2))
   Dim cosD As Double = sLat1 * sLat2 + cLat1 * cLat2 * cLon
   Dim d As Double = Math.Acos(cosD)
   Dim dist As Double = R * d
   Return dist
  End Function

  Public Shared Function DegsToRadians(degrees As Double) As Double
   Return (0.017453292519943295 * degrees)
  End Function

  Public Shared Function ReadFile(fileName As String) As String
   If Not IO.File.Exists(fileName) Then Return ""
   Using sr As New IO.StreamReader(fileName)
    Return sr.ReadToEnd
   End Using
  End Function

  Public Shared Function GetDistanceDirectoryMapPath(distanceId As Integer) As String
   Return String.Format("{0}Albatros\Concours\Distance\{1}\", DotNetNuke.Entities.Portals.PortalSettings.Current.HomeDirectoryMapPath, distanceId)
  End Function
  Public Shared Function GetDistanceDirectoryPath(distanceId As Integer) As String
   Return String.Format("{0}Albatros/Concours/Distance/{1}/", DotNetNuke.Entities.Portals.PortalSettings.Current.HomeDirectory, distanceId)
  End Function

  Public Shared Function GetSharedResource(resourceKey As String) As String
   Return DotNetNuke.Services.Localization.Localization.GetString(resourceKey, "DesktopModules/Albatros/Concours/App_LocalResources/SharedResources")
  End Function

  Public Shared Function ConvertToCategoryName(categoryId As Integer) As String
   Select Case categoryId
    Case FlightCategory.Delta
     Return Common.Globals.GetSharedResource("Delta")
    Case FlightCategory.Rigid
     Return Common.Globals.GetSharedResource("Rigid")
    Case Else
     Return Common.Globals.GetSharedResource("Paraglider")
   End Select
  End Function

  Public Shared Function ConvertToFlightTypeName(flightTypeId As Integer) As String
   Select Case flightTypeId
    Case FlightType.FreeDistance
     Return Common.Globals.GetSharedResource("FreeDistance")
    Case FlightType.OpenTriangle
     Return Common.Globals.GetSharedResource("OpenTriangle")
    Case FlightType.ReturnFlight
     Return Common.Globals.GetSharedResource("ReturnFlight")
    Case Else
     Return Common.Globals.GetSharedResource("Triangle")
   End Select
  End Function

 End Class
End Namespace