Imports System
Imports System.Runtime.Serialization

Namespace Entities.Distances
  Partial Public Class DistanceInfo
#Region " Private Members "
#End Region
	
#Region " Constructors "
  Public Sub New()
  End Sub
#End Region

#Region " Public Properties "
  <DataMember()>
  Public Property DistanceId As Int32 = -1
  <DataMember()>
  Public Property ModuleId As Int32 = -1
  <DataMember()>
  Public Property UserId As Int32 = -1
  <DataMember()>
  Public Property FlightStart As Date = Date.MinValue
  <DataMember()>
  Public Property Category As Int32 = -1
  <DataMember()>
  Public Property FlightType As Int32 = -1
  <DataMember()>
  Public Property Comments As String = ""
  <DataMember()>
  Public Property StartDescription As String = ""
  <DataMember()>
  Public Property StartCoords As String = ""
  <DataMember()>
  Public Property StartLatitude As Double 
  <DataMember()>
  Public Property StartLongitude As Double 
  <DataMember()>
  Public Property ADescription As String = ""
  <DataMember()>
  Public Property ATime As Date = Date.MinValue
  <DataMember()>
  Public Property ACoords As String = ""
  <DataMember()>
  Public Property ALatitude As Double 
  <DataMember()>
  Public Property ALongitude As Double 
  <DataMember()>
  Public Property C1Description As String = ""
  <DataMember()>
  Public Property C1Coords As String = ""
  <DataMember()>
  Public Property C1Latitude As Double 
  <DataMember()>
  Public Property C1Longitude As Double 
  <DataMember()>
  Public Property C2Description As String = ""
  <DataMember()>
  Public Property C2Coords As String = ""
  <DataMember()>
  Public Property C2Latitude As Double 
  <DataMember()>
  Public Property C2Longitude As Double 
  <DataMember()>
  Public Property BDescription As String = ""
  <DataMember()>
  Public Property BTime As Date = Date.MinValue
  <DataMember()>
  Public Property BCoords As String = ""
  <DataMember()>
  Public Property BLatitude As Double 
  <DataMember()>
  Public Property BLongitude As Double 
  <DataMember()>
  Public Property LandingDescription As String = ""
  <DataMember()>
  Public Property LandingTime As Date = Date.MinValue
  <DataMember()>
  Public Property LandingCoords As String = ""
  <DataMember()>
  Public Property LandingLatitude As Double 
  <DataMember()>
  Public Property LandingLongitude As Double 
  <DataMember()>
  Public Property TotalDistance As Double = 0
  <DataMember()>
  Public Property TotalPoints As Double = 0
  <DataMember()>
  Public Property Summary As String = ""
  <DataMember()>
  Public Property Validated As Boolean = False
  <DataMember()>
  Public Property Rejected As Boolean = False
  <DataMember()>
  Public Property CreatedByUserID As Int32 = -1
  <DataMember()>
  Public Property CreatedOnDate As Date = Date.MinValue
  <DataMember()>
  Public Property LastModifiedByUserID As Int32 = -1
  <DataMember()>
  Public Property LastModifiedOnDate As Date = Date.MinValue
  <DataMember()>
  Public Property ValidatedByUserID As Int32 = -1
  <DataMember()>
  Public Property ValidatedOnDate As Date = Date.MinValue
  <DataMember()>
  Public Property PilotDisplayName As String = ""
  <DataMember()>
  Public Property CreatedByDisplayName As String = ""
  <DataMember()>
  Public Property LastModifiedByDisplayName As String = ""
  <DataMember()>
  Public Property ValidatedByDisplayName As String = ""
#End Region

 End Class
End Namespace


