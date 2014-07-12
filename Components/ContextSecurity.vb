Imports DotNetNuke.Entities.Users
Imports DotNetNuke.Security.Permissions
Imports DotNetNuke.Entities.Modules

Public Class ContextSecurity

 Public Property CanValidate As Boolean = False
 Public Property CanAdd As Boolean = False
 Public Property CanEdit As Boolean = False

#Region " Constructor "
 Public Sub New(objModule As ModuleInfo, user As UserInfo)
  CanEdit = ModulePermissionController.HasModulePermission(objModule.ModulePermissions, "EDIT")
  CanAdd = ModulePermissionController.HasModulePermission(objModule.ModulePermissions, Common.Globals.glbLoggerPermissionKey)
  CanValidate = ModulePermissionController.HasModulePermission(objModule.ModulePermissions, Common.Globals.glbControllerPermissionKey)
 End Sub
#End Region

End Class
