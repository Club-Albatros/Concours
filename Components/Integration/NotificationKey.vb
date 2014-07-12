Namespace Integration
 Public Class NotificationKey

  Public ID As String = ""
  Public ModuleId As Integer = -1
  Public DistanceId As Integer = -1
  Public BeaconFlightId As Integer = -1

  Public Sub New(key As String)
   Dim keyParts() As String = key.Split(":"c)
   If keyParts.Length < 5 Then Exit Sub
   ID = keyParts(0)
   ModuleId = Integer.Parse(keyParts(1))
   DistanceId = Integer.Parse(keyParts(2))
   BeaconFlightId = Integer.Parse(keyParts(3))
  End Sub

  Public Sub New(id As String, moduleId As Integer, distanceId As Integer, beaconFlightId As Integer)
   Me.ID = id
   Me.ModuleId = moduleId
   Me.DistanceId = distanceId
   Me.BeaconFlightId = beaconFlightId
  End Sub

  Public Shadows Function ToString() As String
   Return String.Format("{0}:{1}:{2}:{3}", ID, ModuleId, DistanceId, BeaconFlightId)
  End Function

 End Class
End Namespace
