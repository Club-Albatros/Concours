Imports System
Imports DotNetNuke

Namespace Data

 Partial Public MustInherit Class DataProvider

#Region " Shared/Static Methods "

  ' singleton reference to the instantiated object 
  Private Shared objProvider As DataProvider = Nothing

  ' constructor
  Shared Sub New()
   CreateProvider()
  End Sub

  ' dynamically create provider
  Private Shared Sub CreateProvider()
   objProvider = CType(DotNetNuke.Framework.Reflection.CreateObject("data", "Albatros.DNN.Modules.Concours.Data", ""), DataProvider)
  End Sub

  ' return the provider
  Public Shared Shadows Function Instance() As DataProvider
   Return objProvider
  End Function

#End Region

#Region " General Methods "
  Public MustOverride Function GetNull(Field As Object) As Object
#End Region

#Region " Distance Methods "
	Public MustOverride Function AddDistance(aCoords As String, moduleId As Int32, aDescription As String, aLatitude As Double, aLongitude As Double, aTime As Date, bCoords As String, bDescription As String, bLatitude As Double, bLongitude As Double, bTime As Date, c1Coords As String, c1Description As String, c1Latitude As Double, c1Longitude As Double, c2Coords As String, c2Description As String, c2Latitude As Double, c2Longitude As Double, category As Int32, comments As String, flightStart As Date, flightType As Int32, landingCoords As String, landingDescription As String, landingLatitude As Double, landingLongitude As Double, landingTime As Date, rejected As Boolean, startCoords As String, startDescription As String, startLatitude As Double, startLongitude As Double, summary As String, totalDistance As Double, totalPoints As Double, userId As Int32, validated As Boolean, validatedByUserID As Int32, validatedOnDate As Date, createdByUser As Int32) As Integer	
	Public MustOverride Sub UpdateDistance(aCoords As String, moduleId As Int32, aDescription As String, aLatitude As Double, aLongitude As Double, aTime As Date, bCoords As String, bDescription As String, bLatitude As Double, bLongitude As Double, bTime As Date, c1Coords As String, c1Description As String, c1Latitude As Double, c1Longitude As Double, c2Coords As String, c2Description As String, c2Latitude As Double, c2Longitude As Double, category As Int32, comments As String, distanceId As Int32, flightStart As Date, flightType As Int32, landingCoords As String, landingDescription As String, landingLatitude As Double, landingLongitude As Double, landingTime As Date, rejected As Boolean, startCoords As String, startDescription As String, startLatitude As Double, startLongitude As Double, summary As String, totalDistance As Double, totalPoints As Double, userId As Int32, validated As Boolean, validatedByUserID As Int32, validatedOnDate As Date, updatedByUser As Int32)	
	Public MustOverride Sub DeleteDistance(distanceId As Int32)
#End Region


 End Class

End Namespace

