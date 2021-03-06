﻿Imports DotNetNuke.Services.Social.Notifications
Imports DotNetNuke.Entities.Users
Imports DotNetNuke.Entities.Modules
Imports System.Linq
Imports Albatros.DNN.Modules.Concours.Entities.Distances
Imports DotNetNuke.Security.Roles
Imports DotNetNuke.Security.Permissions

Namespace Integration

 Public Class NotificationController

#Region " Constants "
  Public Const DistanceFlightAddition As String = "Concours_Distance_Addition"
  Public Const DistanceFlightValidation As String = "Concours_Distance_Validation"
#End Region

#Region " Integration Methods "
  Public Shared Sub FlightAdded(modInfo As ModuleInfo, flight As DistanceInfo, url As String)

   Dim notificationType As NotificationType = NotificationsController.Instance.GetNotificationType(DistanceFlightValidation)
   Dim notificationKey As New NotificationKey(Integration.glbContentTypeName, flight.ModuleId, flight.DistanceId, -1)

   Dim title As String = DotNetNuke.Services.Localization.Localization.GetString("FlightAdded.Title", Common.Globals.glbSharedResources, DotNetNuke.Entities.Portals.PortalSettings.Current.DefaultLanguage)
   Dim summary As String = DotNetNuke.Services.Localization.Localization.GetString("FlightAdded.Summary", Common.Globals.glbSharedResources, DotNetNuke.Entities.Portals.PortalSettings.Current.DefaultLanguage)
   summary = String.Format(summary, flight.PilotDisplayName, flight.FlightStart, flight.Summary, url)

   Dim objNotification As New Notification
   objNotification.NotificationTypeID = notificationType.NotificationTypeId
   objNotification.Subject = title
   objNotification.Body = summary
   objNotification.IncludeDismissAction = True
   objNotification.SenderUserID = flight.UserId
   objNotification.Context = notificationKey.ToString

   AddNotifications(modInfo.PortalID, GetUsersInPermission(modInfo, Common.Globals.glbControllerPermissionKey).Values.ToList(), objNotification)

  End Sub

  Public Shared Sub RemoveFlightNotifications(flight As DistanceInfo)
   Dim notificationType As NotificationType = NotificationsController.Instance.GetNotificationType(DistanceFlightValidation)
   Dim notificationKey As New NotificationKey(Integration.glbContentTypeName, flight.ModuleId, flight.DistanceId, -1)
   For Each objNotify As Notification In NotificationsController.Instance.GetNotificationByContext(notificationType.NotificationTypeId, notificationKey.ToString)
    NotificationsController.Instance.DeleteAllNotificationRecipients(objNotify.NotificationID)
   Next
  End Sub

  Public Shared Sub FlightValidated(modInfo As ModuleInfo, flight As DistanceInfo, url As String)

   RemoveFlightNotifications(flight)
   Dim notificationType As NotificationType = NotificationsController.Instance.GetNotificationType(DistanceFlightValidation)
   Dim notificationKey As New NotificationKey(Integration.glbContentTypeName, flight.ModuleId, flight.DistanceId, -1)

   Dim title As String = ""
   Dim summary As String = ""
   If flight.Rejected Then
    title = DotNetNuke.Services.Localization.Localization.GetString("FlightRejected.Title", Common.Globals.glbSharedResources, DotNetNuke.Entities.Portals.PortalSettings.Current.DefaultLanguage)
    summary = DotNetNuke.Services.Localization.Localization.GetString("FlightRejected.Summary", Common.Globals.glbSharedResources, DotNetNuke.Entities.Portals.PortalSettings.Current.DefaultLanguage)
   ElseIf flight.Validated Then
    title = DotNetNuke.Services.Localization.Localization.GetString("FlightApproved.Title", Common.Globals.glbSharedResources, DotNetNuke.Entities.Portals.PortalSettings.Current.DefaultLanguage)
    summary = DotNetNuke.Services.Localization.Localization.GetString("FlightApproved.Summary", Common.Globals.glbSharedResources, DotNetNuke.Entities.Portals.PortalSettings.Current.DefaultLanguage)
   Else
    Exit Sub ' we removed all notifications and the flight is neither validated nor rejected
   End If
   summary = String.Format(summary, flight.PilotDisplayName, flight.FlightStart, flight.ValidatedByDisplayName, flight.Summary, url)

   Dim objNotification As New Notification
   objNotification.NotificationTypeID = notificationType.NotificationTypeId
   objNotification.Subject = title
   objNotification.Body = summary
   objNotification.IncludeDismissAction = True
   objNotification.SenderUserID = flight.UserId
   objNotification.Context = notificationKey.ToString

   Dim sendList As Dictionary(Of Integer, UserInfo) = GetUsersInPermission(modInfo, Common.Globals.glbControllerPermissionKey)
   AddUser(sendList, modInfo.PortalID, flight.UserId)

   AddNotifications(modInfo.PortalID, sendList.Values.ToList(), objNotification)

  End Sub
#End Region

#Region " Private Methods "
  Private Shared Function GetUsersInPermission(modInfo As ModuleInfo, permissionKey As String) As Dictionary(Of Integer, UserInfo)
   Dim res As New Dictionary(Of Integer, UserInfo)
   For Each perm As ModulePermissionInfo In modInfo.ModulePermissions.Where(Function(x) x.PermissionKey = Common.Globals.glbControllerPermissionKey)
    If perm.UserID > -1 Then
     AddUser(res, modInfo.PortalID, perm.UserID, perm.Username)
    Else
     For Each u As UserInfo In (New RoleController).GetUsersByRoleName(modInfo.PortalID, perm.RoleName)
      AddUser(res, modInfo.PortalID, u.UserID, u.Username)
     Next
    End If
   Next
   Return res
  End Function

  Private Shared Sub AddUser(ByRef userList As Dictionary(Of Integer, UserInfo), portalId As Integer, userId As Integer, username As String)
   If Not userList.ContainsKey(userId) Then
    Dim u As UserInfo = UserController.GetCachedUser(portalId, username)
    If u IsNot Nothing Then
     userList.Add(userId, u)
    End If
   End If
  End Sub

  Private Shared Sub AddUser(ByRef userList As Dictionary(Of Integer, UserInfo), portalId As Integer, userId As Integer)
   If Not userList.ContainsKey(userId) Then
    Dim u As UserInfo = UserController.GetUserById(portalId, userId)
    If u IsNot Nothing Then
     userList.Add(userId, u)
    End If
   End If
  End Sub
  Private Shared Sub AddNotifications(portalId As Integer, colUsers As List(Of UserInfo), objNotification As Notification)
   If colUsers.Count > DotNetNuke.Services.Social.Messaging.Internal.InternalMessagingController.Instance.RecipientLimit(portalId) Then
    For Each u As UserInfo In colUsers
     Dim list As New List(Of UserInfo)
     list.Add(u)
     NotificationsController.Instance.SendNotification(objNotification, portalId, Nothing, list)
    Next
   Else
    NotificationsController.Instance.SendNotification(objNotification, portalId, Nothing, colUsers)
   End If
  End Sub
#End Region

#Region " Install Methods "
  Friend Shared Sub AddNotificationTypes() ' runs on 1.1.0 upgrade

   Dim deskModuleId As Integer = DesktopModuleController.GetDesktopModuleByFriendlyName("Concours").DesktopModuleID

   Dim objNotificationType As NotificationType = New NotificationType
   objNotificationType.Name = DistanceFlightAddition
   objNotificationType.Description = "New distance flight addition"
   objNotificationType.DesktopModuleId = deskModuleId

   If NotificationsController.Instance.GetNotificationType(objNotificationType.Name) Is Nothing Then
    NotificationsController.Instance.CreateNotificationType(objNotificationType)
   End If

   objNotificationType.Name = DistanceFlightValidation
   objNotificationType.Description = "New distance flight validation"

   If NotificationsController.Instance.GetNotificationType(objNotificationType.Name) Is Nothing Then
    NotificationsController.Instance.CreateNotificationType(objNotificationType)
   End If

  End Sub
#End Region

 End Class

End Namespace