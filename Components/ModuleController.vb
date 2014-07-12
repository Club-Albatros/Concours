Imports System.Xml
Imports System.Text
Imports System.Collections.Generic
Imports System.IO

Imports DotNetNuke.Common.Utilities.XmlUtils
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Search.Entities

Public Class ModuleController
 Inherits ModuleSearchBase
 Implements DotNetNuke.Entities.Modules.IUpgradeable

#Region " IUpgradeable Implementation "
 Public Function UpgradeModule(ByVal Version As String) As String Implements DotNetNuke.Entities.Modules.IUpgradeable.UpgradeModule
  Dim strResults As String = ""
  Try
   Select Case Version
    Case "01.01.00"
     Integration.NotificationController.AddNotificationTypes()
   End Select
  Catch ex As Exception
   strResults += "Error: " & ex.Message & vbCrLf
   Try
    DotNetNuke.Services.Exceptions.LogException(ex)
   Catch
    ' ignore
   End Try
  End Try
  Return strResults
 End Function
#End Region

#Region " Search "
 Public Overrides Function GetModifiedSearchDocuments(moduleInfo As ModuleInfo, beginDate As Date) As IList(Of SearchDocument)
  Return New List(Of SearchDocument)
 End Function
#End Region

End Class

