Imports System
Imports DotNetNuke

Namespace Data

 Partial Public MustInherit Class DataProvider

  Public MustOverride Function GetDistance(distanceId As Int32, moduleId As Int32) As IDataReader
  Public MustOverride Function GetDistancesStandings(moduleId As Int32, year As Int32, category As Int32) As IDataReader
  Public MustOverride Function ListSites(startString As String) As IDataReader

 End Class

End Namespace

