Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace Data

 Partial Public Class SqlDataProvider

#Region " Distance Methods "
  Public Overrides Function GetDistancesByModule(moduleID As Int32, validated As Boolean, StartRowIndex As Integer, MaximumRows As Integer, OrderBy As String) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetDistancesByModule", moduleID, validated, StartRowIndex, MaximumRows, OrderBy.ToUpper), IDataReader)
  End Function

  Public Overrides Function GetDistancesByUser(userID As Int32, moduleId As Int32, StartRowIndex As Integer, MaximumRows As Integer, OrderBy As String) As IDataReader
   Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ModuleQualifier & "GetDistancesByUser", userID, moduleId, StartRowIndex, MaximumRows, OrderBy.ToUpper), IDataReader)
  End Function

#End Region

 End Class

End Namespace
