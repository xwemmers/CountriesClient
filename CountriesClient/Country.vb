

Public Class Country
    Public Property name As String
    Public Property topLevelDomain As List(Of String)
    Public Property alpha2Code As String
    Public Property alpha3Code As String
    Public Property callingCodes As List(Of String)
    Public Property capital As String
    Public Property altSpellings As List(Of String)
    Public Property region As String
    Public Property subregion As String
    Public Property population As Integer
    Public Property latlng As List(Of Single?)
    Public Property demonym As String
    Public Property area As Single?
    Public Property gini As Single?
    Public Property timezones As List(Of String)
    Public Property borders As List(Of String)

    Public ReadOnly Property borders2 As String
        Get
            Return String.Join(", ", borders)
        End Get
    End Property

    Public Property nativeName As String
    Public Property numericCode As String
    Public Property currencies As List(Of Currency)
    Public Property languages As List(Of Language)
    Public Property translations As Translations
    Public Property flag As String
    Public Property regionalBlocs As List(Of Regionalbloc)
    Public Property cioc As String
End Class

Public Class Translations
    Public Property de As String
    Public Property es As String
    Public Property fr As String
    Public Property ja As String
    Public Property it As String
    Public Property br As String
    Public Property pt As String
    Public Property nl As String
    Public Property hr As String
    Public Property fa As String
End Class

Public Class Currency
    Public Property code As String
    Public Property name As String
    Public Property symbol As String
End Class

Public Class Language
    Public Property iso639_1 As String
    Public Property iso639_2 As String
    Public Property name As String
    Public Property nativeName As String
End Class

Public Class Regionalbloc
    Public Property acronym As String
    Public Property name As String
    Public Property otherAcronyms As List(Of String)
    Public Property otherNames As List(Of String)
End Class
