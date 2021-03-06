Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports DotNetNuke.Framework.Providers

Namespace Data

 Partial Public Class SqlDataProvider
  Inherits DataProvider

#Region " Private Members "

  Private Const ProviderType As String = "data"
  Private Const ModuleQualifier As String = "Concours_"

  Private _providerConfiguration As DotNetNuke.Framework.Providers.ProviderConfiguration = DotNetNuke.Framework.Providers.ProviderConfiguration.GetProviderConfiguration(ProviderType)
  Private _connectionString As String
  Private _providerPath As String
  Private _objectQualifier As String
  Private _databaseOwner As String

#End Region

#Region " Constructors "

  Public Sub New()

   ' Read the configuration specific information for this provider
   Dim objProvider As DotNetNuke.Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Provider)

   'Get Connection string from web.config
   _connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString()

   If _connectionString = "" Then
    ' Use connection string specified in provider
    _connectionString = objProvider.Attributes("connectionString")
   End If

   _providerPath = objProvider.Attributes("providerPath")

   _objectQualifier = objProvider.Attributes("objectQualifier")
   If _objectQualifier <> "" And _objectQualifier.EndsWith("_") = False Then
    _objectQualifier += "_"
   End If

   _databaseOwner = objProvider.Attributes("databaseOwner")
   If _databaseOwner <> "" And _databaseOwner.EndsWith(".") = False Then
    _databaseOwner += "."
   End If

  End Sub

#End Region

#Region " Properties "

  Public ReadOnly Property ConnectionString() As String
   Get
    Return _connectionString
   End Get
  End Property

  Public ReadOnly Property ProviderPath() As String
   Get
    Return _providerPath
   End Get
  End Property

  Public ReadOnly Property ObjectQualifier() As String
   Get
    Return _objectQualifier
   End Get
  End Property

  Public ReadOnly Property DatabaseOwner() As String
   Get
    Return _databaseOwner
   End Get
  End Property

#End Region

#Region " General Methods "
  Public Overrides Function GetNull(Field As Object) As Object
   Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
  End Function
#End Region


#Region " Distance Methods "

	Public Overrides Function AddDistance(aCoords As String, moduleId As Int32, aDescription As String, aLatitude As Double, aLongitude As Double, aTime As Date, bCoords As String, bDescription As String, bLatitude As Double, bLongitude As Double, bTime As Date, c1Coords As String, c1Description As String, c1Latitude As Double, c1Longitude As Double, c2Coords As String, c2Description As String, c2Latitude As Double, c2Longitude As Double, category As Int32, comments As String, flightStart As Date, flightType As Int32, landingCoords As String, landingDescription As String, landingLatitude As Double, landingLongitude As Double, landingTime As Date, rejected As Boolean, startCoords As String, startDescription As String, startLatitude As Double, startLongitude As Double, summary As String, totalDistance As Double, totalPoints As Double, userId As Int32, validated As Boolean, validatedByUserID As Int32, validatedOnDate As Date, createdByUser As Int32) As Integer
		Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "AddDistance", GetNull(aCoords), moduleId, GetNull(aDescription), GetNull(aLatitude), GetNull(aLongitude), GetNull(aTime), GetNull(bCoords), GetNull(bDescription), GetNull(bLatitude), GetNull(bLongitude), GetNull(bTime), GetNull(c1Coords), GetNull(c1Description), GetNull(c1Latitude), GetNull(c1Longitude), GetNull(c2Coords), GetNull(c2Description), GetNull(c2Latitude), GetNull(c2Longitude), category, GetNull(comments), flightStart, flightType, GetNull(landingCoords), GetNull(landingDescription), landingLatitude, landingLongitude, landingTime, rejected, GetNull(startCoords), startDescription, startLatitude, startLongitude, GetNull(summary), GetNull(totalDistance), GetNull(totalPoints), userId, validated, GetNull(validatedByUserID), GetNull(validatedOnDate), createdByUser), Integer)
	End Function
	
	Public Overrides Sub UpdateDistance(aCoords As String, moduleId As Int32, aDescription As String, aLatitude As Double, aLongitude As Double, aTime As Date, bCoords As String, bDescription As String, bLatitude As Double, bLongitude As Double, bTime As Date, c1Coords As String, c1Description As String, c1Latitude As Double, c1Longitude As Double, c2Coords As String, c2Description As String, c2Latitude As Double, c2Longitude As Double, category As Int32, comments As String, distanceId As Int32, flightStart As Date, flightType As Int32, landingCoords As String, landingDescription As String, landingLatitude As Double, landingLongitude As Double, landingTime As Date, rejected As Boolean, startCoords As String, startDescription As String, startLatitude As Double, startLongitude As Double, summary As String, totalDistance As Double, totalPoints As Double, userId As Int32, validated As Boolean, validatedByUserID As Int32, validatedOnDate As Date, updatedByUser As Int32)
		SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "UpdateDistance", GetNull(aCoords), moduleId, GetNull(aDescription), GetNull(aLatitude), GetNull(aLongitude), GetNull(aTime), GetNull(bCoords), GetNull(bDescription), GetNull(bLatitude), GetNull(bLongitude), GetNull(bTime), GetNull(c1Coords), GetNull(c1Description), GetNull(c1Latitude), GetNull(c1Longitude), GetNull(c2Coords), GetNull(c2Description), GetNull(c2Latitude), GetNull(c2Longitude), category, GetNull(comments), distanceId, flightStart, flightType, GetNull(landingCoords), GetNull(landingDescription), landingLatitude, landingLongitude, landingTime, rejected, GetNull(startCoords), startDescription, startLatitude, startLongitude, GetNull(summary), GetNull(totalDistance), GetNull(totalPoints), userId, validated, GetNull(validatedByUserID), GetNull(validatedOnDate), updatedByUser)
	End Sub

  Public Overrides Sub DeleteDistance(distanceId As Int32)
   SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "DeleteDistance", distanceId)
  End Sub

#End Region


 End Class

End Namespace
