Imports System
Imports DotNetNuke

Namespace Data

 Partial Public MustInherit Class DataProvider

#Region " Distance Methods "
  Public MustOverride Function GetDistancesByModule(moduleID As Int32, validated As Boolean, pageIndex As Int32, pageSize As Int32, orderBy As String) As IDataReader
  Public MustOverride Function GetDistancesByUser(userID As Int32, moduleId As Int32, pageIndex As Int32, pageSize As Int32, orderBy As String) As IDataReader
#End Region

 End Class

End Namespace

