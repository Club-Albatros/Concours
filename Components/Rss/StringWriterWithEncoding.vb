Namespace Rss

 Public Class StringWriterWithEncoding
  Inherits IO.StringWriter

  Private _encoding As System.Text.Encoding

  Public Sub New(builder As StringBuilder, encoding As System.Text.Encoding)
   MyBase.New(builder)
   _encoding = encoding
  End Sub

  Public Overrides ReadOnly Property Encoding() As System.Text.Encoding
   Get
    Return _encoding
   End Get
  End Property

 End Class

End Namespace