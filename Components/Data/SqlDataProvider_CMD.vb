Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace Data

 Partial Public Class SqlDataProvider

  Public Overrides Function GetDistance(distanceId As Int32, moduleId As Int32) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetDistance", distanceId, moduleId), IDataReader)
  End Function

  Public Overrides Function GetDistancesStandings(moduleId As Int32, year As Int32, category As Int32) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetDistancesStandings", moduleId, year, category), IDataReader)
  End Function

  Public Overrides Function ListSites(startString As String) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "ListSites", startString), IDataReader)
  End Function


 End Class

End Namespace
