Imports System.Xml

Namespace Common
 Module Extensions

#Region " Collection Read Extensions "
  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As Hashtable, ValueName As String, ByRef Variable As Integer)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Integer)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As Hashtable, ValueName As String, ByRef Variable As Long)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Long)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As Hashtable, ValueName As String, ByRef Variable As String)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), String)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As Hashtable, ValueName As String, ByRef Variable As Boolean)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Boolean)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As Hashtable, ValueName As String, ByRef Variable As Date)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Date)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As Hashtable, ValueName As String, ByRef Variable As TimeSpan)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = TimeSpan.Parse(CType(ValueTable.Item(ValueName), String))
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As NameValueCollection, ValueName As String, ByRef Variable As Integer)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Integer)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As NameValueCollection, ValueName As String, ByRef Variable As Long)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Long)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As NameValueCollection, ValueName As String, ByRef Variable As String)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), String)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As NameValueCollection, ValueName As String, ByRef Variable As Boolean)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Boolean)
    Catch ex As Exception
     Select Case ValueTable.Item(ValueName).ToLower
      Case "on", "yes"
       Variable = True
      Case Else
       Variable = False
     End Select
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As NameValueCollection, ValueName As String, ByRef Variable As Date)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Date)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As NameValueCollection, ValueName As String, ByRef Variable As TimeSpan)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = TimeSpan.Parse(CType(ValueTable.Item(ValueName), String))
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ValueTable As Dictionary(Of String, String), ValueName As String, ByRef Variable As Integer)
   If ValueTable.ContainsKey(ValueName) Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Integer)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ValueTable As Dictionary(Of String, String), ValueName As String, ByRef Variable As String)
   If ValueTable.ContainsKey(ValueName) Then
    Try
     Variable = CType(ValueTable.Item(ValueName), String)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ValueTable As Dictionary(Of String, String), ValueName As String, ByRef Variable As Boolean)
   If ValueTable.ContainsKey(ValueName) Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Boolean)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ValueTable As Dictionary(Of String, String), ValueName As String, ByRef Variable As Date)
   If ValueTable.ContainsKey(ValueName) Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Date)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ValueTable As Dictionary(Of String, String), ValueName As String, ByRef Variable As TimeSpan)
   If ValueTable.ContainsKey(ValueName) Then
    Try
     Variable = TimeSpan.Parse(CType(ValueTable.Item(ValueName), String))
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As StateBag, ValueName As String, ByRef Variable As Integer)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Integer)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As StateBag, ValueName As String, ByRef Variable As Long)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Long)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As StateBag, ValueName As String, ByRef Variable As String)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), String)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As StateBag, ValueName As String, ByRef Variable As Boolean)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Boolean)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As StateBag, ValueName As String, ByRef Variable As Date)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.Item(ValueName), Date)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As StateBag, ValueName As String, ByRef Variable As TimeSpan)
   If Not ValueTable.Item(ValueName) Is Nothing Then
    Try
     Variable = TimeSpan.Parse(CType(ValueTable.Item(ValueName), String))
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As XmlNode, ValueName As String, ByRef Variable As Integer)
   If Not ValueTable.SelectSingleNode(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.SelectSingleNode(ValueName).InnerText, Integer)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As XmlNode, ValueName As String, ByRef Variable As Long)
   If Not ValueTable.SelectSingleNode(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.SelectSingleNode(ValueName).InnerText, Long)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As XmlNode, ValueName As String, ByRef Variable As String)
   If Not ValueTable.SelectSingleNode(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.SelectSingleNode(ValueName).InnerText, String)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As XmlNode, ValueName As String, ByRef Variable As Boolean)
   If Not ValueTable.SelectSingleNode(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.SelectSingleNode(ValueName).InnerText, Boolean)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As XmlNode, ValueName As String, ByRef Variable As Date)
   If Not ValueTable.SelectSingleNode(ValueName) Is Nothing Then
    Try
     Variable = CType(ValueTable.SelectSingleNode(ValueName).InnerText, Date)
    Catch ex As Exception
    End Try
   End If
  End Sub

  <System.Runtime.CompilerServices.Extension()>
  Public Sub ReadValue(ByRef ValueTable As XmlNode, ValueName As String, ByRef Variable As TimeSpan)
   If Not ValueTable.SelectSingleNode(ValueName) Is Nothing Then
    Try
     Variable = TimeSpan.Parse(CType(ValueTable.SelectSingleNode(ValueName).InnerText, String))
    Catch ex As Exception
    End Try
   End If
  End Sub
#End Region

#Region " Conversion Extensions "
  <System.Runtime.CompilerServices.Extension()>
  Public Function ToInt(var As Boolean) As Integer
   If var Then
    Return 1
   Else
    Return 0
   End If
  End Function

  <System.Runtime.CompilerServices.Extension()>
  Public Function ToYesNo(var As Boolean) As String
   If var Then
    Return "Yes"
   Else
    Return "No"
   End If
  End Function

  <System.Runtime.CompilerServices.Extension()>
  Public Function ToInt(var As String) As Integer
   If IsNumeric(var) Then
    Return Integer.Parse(var)
   Else
    Return -1
   End If
  End Function

  <System.Runtime.CompilerServices.Extension()>
  Public Function ToBool(var As Integer) As Boolean
   Return CBool(var > 0)
  End Function

  <System.Runtime.CompilerServices.Extension()>
  Public Function ToStringOrZero(value As Integer?) As String
   If value Is Nothing Then
    Return "0"
   Else
    Return value.ToString
   End If
  End Function
#End Region

#Region " Other "
  <System.Runtime.CompilerServices.Extension()>
  Public Function FindControlByID(Control As System.Web.UI.Control, id As String) As Control
   Dim found As Control = Nothing
   If Control IsNot Nothing Then
    If Control.ID = id Then
     found = Control
    Else
     found = FindControlByID(Control.Controls, id)
    End If
   End If
   Return found
  End Function

  <System.Runtime.CompilerServices.Extension()>
  Public Function FindControlByID(Controls As System.Web.UI.ControlCollection, id As String) As Control
   Dim found As Control = Nothing
   If Controls IsNot Nothing AndAlso Controls.Count > 0 Then
    For i As Integer = 0 To Controls.Count - 1
     If Controls(i).ID = id Then
      found = Controls(i)
     Else
      found = FindControlByID(Controls(i).Controls, id)
     End If
     If found IsNot Nothing Then Exit For
    Next
   End If
   Return found
  End Function

  <System.Runtime.CompilerServices.Extension()>
  Public Function SubstringWithoutException(input As String, startIndex As Integer, length As Integer) As String
   If String.IsNullOrEmpty(input) Then Return ""
   If startIndex > 0 Then
    If startIndex >= input.Length Then
     Return ""
    End If
    If startIndex + length > input.Length Then
     Return input.Substring(startIndex, input.Length - startIndex)
    Else
     Return input.Substring(startIndex, length)
    End If
   Else
    If length > input.Length Then
     Return input.Substring(0, input.Length - startIndex)
    Else
     Return input.Substring(0, length)
    End If
   End If
  End Function
#End Region

 End Module
End Namespace
