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

  Public Shared Function GetDistancesByModule(moduleID As Int32, validated As Boolean, pageIndex As Int32, pageSize As Int32, orderBy As String, ByRef totalRecords As Integer) As List(Of DistanceInfo)

   If pageIndex < 0 Then
    pageIndex = 0
    pageSize = Integer.MaxValue
   End If

   Dim res As New List(Of DistanceInfo)
   Using ir As IDataReader = DataProvider.Instance().GetDistancesByModule(moduleID, validated, pageIndex, pageSize, orderBy)
    DotNetNuke.Common.Utilities.CBO.FillCollection(Of DistanceInfo)(ir, res, False)
    ir.NextResult()
    totalRecords = DotNetNuke.Common.Globals.GetTotalRecords(ir)
   End Using
   Return res

  End Function

  Public Shared Function GetDistancesByUser(userID As Int32, moduleId As Integer, pageIndex As Int32, pageSize As Int32, orderBy As String, ByRef totalRecords As Integer) As List(Of DistanceInfo)

   If pageIndex < 0 Then
    pageIndex = 0
    pageSize = Integer.MaxValue
   End If

   Dim res As New List(Of DistanceInfo)
   Using ir As IDataReader = DataProvider.Instance().GetDistancesByUser(userID, moduleId, pageIndex, pageSize, orderBy)
    DotNetNuke.Common.Utilities.CBO.FillCollection(Of DistanceInfo)(ir, res, False)
    ir.NextResult()
    totalRecords = DotNetNuke.Common.Globals.GetTotalRecords(ir)
   End Using
   Return res

  End Function


 End Class
End Namespace

