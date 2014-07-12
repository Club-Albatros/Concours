Imports DotNetNuke.Services.Journal
Imports System.Linq
Imports Albatros.DNN.Modules.Concours.Entities.Distances
Imports DotNetNuke.Entities.Modules

Namespace Integration

 Public Class JournalController

#Region " Public Methods "
  Public Shared Sub AddFlightToJournal(modInfo As ModuleInfo, flight As DistanceInfo, url As String)

   Dim objectKey As String = Integration.glbContentTypeName + "_" + String.Format("{0}:{1}", flight.DistanceId, flight.Validated)
   Dim ji As JournalItem = DotNetNuke.Services.Journal.JournalController.Instance.GetJournalItemByKey(modInfo.PortalID, objectKey)

   Dim title As String = ""
   Dim summary As String = ""

   If flight.Validated Then
    title = DotNetNuke.Services.Localization.Localization.GetString("FlightValidatedJournal.Title", Common.Globals.glbSharedResources, DotNetNuke.Entities.Portals.PortalSettings.Current.DefaultLanguage)
    summary = DotNetNuke.Services.Localization.Localization.GetString("FlightValidatedJournal.Summary", Common.Globals.glbSharedResources, DotNetNuke.Entities.Portals.PortalSettings.Current.DefaultLanguage)
   Else
    title = DotNetNuke.Services.Localization.Localization.GetString("NewFlightJournal.Title", Common.Globals.glbSharedResources, DotNetNuke.Entities.Portals.PortalSettings.Current.DefaultLanguage)
    summary = DotNetNuke.Services.Localization.Localization.GetString("NewFlightJournal.Summary", Common.Globals.glbSharedResources, DotNetNuke.Entities.Portals.PortalSettings.Current.DefaultLanguage)
   End If
   summary = String.Format(summary, flight.PilotDisplayName, flight.FlightStart, flight.Summary, url)

   If Not ji Is Nothing Then
    DotNetNuke.Services.Journal.JournalController.Instance.DeleteJournalItemByKey(modInfo.PortalID, objectKey)
   End If

   ji = New JournalItem

   ji.PortalId = modInfo.PortalID
   ji.ProfileId = flight.UserId
   ji.UserId = flight.UserId
   ji.ContentItemId = -1
   ji.Title = title
   ji.ItemData = New ItemData()
   ji.ItemData.Url = url
   ji.Summary = summary
   ji.Body = Nothing
   ji.JournalTypeId = GetStatusJournalTypeID(modInfo.PortalID)
   ji.ObjectKey = objectKey
   ji.SecuritySet = "E,"

   DotNetNuke.Services.Journal.JournalController.Instance.SaveJournalItem(ji, modInfo.TabID)

  End Sub

  Public Shared Sub RemoveFlightFromJournal(modInfo As ModuleInfo, flight As DistanceInfo)
   Dim objectKey As String = Integration.glbContentTypeName + "_" + String.Format("{0}:{1}", flight.DistanceId, flight.Validated)
   DotNetNuke.Services.Journal.JournalController.Instance.DeleteJournalItemByKey(modInfo.PortalID, objectKey)
  End Sub
#End Region

#Region " Private Methods "
  Private Shared Function GetStatusJournalTypeID(portalId As Integer) As Integer
   Dim colJournalTypes As IEnumerable(Of JournalTypeInfo)
   colJournalTypes = (From t In DotNetNuke.Services.Journal.JournalController.Instance.GetJournalTypes(portalId) Where t.JournalType = "status")
   Dim journalTypeId As Integer

   If colJournalTypes.Count() > 0 Then
    Dim journalType As JournalTypeInfo = colJournalTypes.[Single]()
    journalTypeId = journalType.JournalTypeId
   Else
    journalTypeId = 1
   End If

   Return journalTypeId
  End Function
#End Region

 End Class

End Namespace