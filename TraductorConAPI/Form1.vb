Imports System.Security
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports Windows.Win32.System
Imports Newtonsoft.Json


Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        Dim originalText As String
        Dim endText As String
        Dim targetLanguageCode As String

        originalText = txtOriginText.Text
        targetLanguageCode = getLanguageCode(cbxTargetLanguage.Text)


        ' TODO: check what translator to use and use the apropiate one
        endText = TranslateTextWithDeepL(originalText, targetLanguageCode) 'For now only Deepl works

        txtEndText.Text = endText
    End Sub

    Private Sub btnTestDeepl_Click(sender As Object, e As EventArgs) Handles btnTestDeepl.Click
        TestTranslation()
    End Sub

    Sub TestTranslation() ' Test that TranslateTextWithDeepL works
        On Error GoTo ErrorHandler

        Dim originalText As String
        Dim targetLanguage As String
        Dim translatedText As String

        ' Example translation: English to German
        originalText = "me pica el ano"
        targetLanguage = "DE"

        translatedText = TranslateTextWithDeepL(originalText, targetLanguage)

        MsgBox("Translated text: " & translatedText)

        Exit Sub

ErrorHandler:
        MsgBox("Error: " & Err.Description)
    End Sub

    Public Function TranslateTextWithDeepL(originalText As String, targetLanguage As String) As String

        ' Replace with your actual DeepL API key
        Const DeepLApiKey As String = "YOUR_API_KEY"

        ' URL for the DeepL translation endpoint
        Const DeepLTranslateUrl As String = "https://api-free.deepl.com/v2/translate"

        Dim http As Object
        http = CreateObject("MSXML2.ServerXMLHTTP")

        ' Set up request headers
        http.Open("POST", DeepLTranslateUrl, False)
        http.setRequestHeader("Authorization", "DeepL-Auth-Key " & DeepLApiKey)
        http.setRequestHeader("User-Agent", "myApp/0.2")
        http.setRequestHeader("Content-Type", "application/json")

        ' Prepare request body in JSON format
        Dim requestBody As String
        requestBody = "{""text"": [""" & originalText & """],""target_lang"": """ & targetLanguage & """}"

        http.Send(requestBody)

        ' Handle response
        If http.Status = 200 Then
            Dim responseText As String
            responseText = http.responseText

            ' Parse JSON response to extract translated text
            Dim json As Newtonsoft.Json.Linq.JObject
            json = Newtonsoft.Json.Linq.JObject.Parse(responseText)

            If Not json Is Nothing Then
                If json.ContainsKey("translations") Then ' Check for the existence of the "translations" property
                    Dim translationsArray As Object
                    translationsArray = json("translations")

                    If translationsArray IsNot Nothing Then ' Ensure the array is not null
                        Dim translatedText As String
                        translatedText = translationsArray(0)("text") ' Access the first translation's text
                        Return translatedText
                    End If
                End If
            End If

            ' Error handling for invalid JSON response
            Err.Raise(10001, "TranslateTextWithDeepL", "Invalid response from DeepL API")
        Else
            ' Error handling for non-200 HTTP status codes
            Err.Raise(10002, "TranslateTextWithDeepL", "DeepL API request failed with status " & http.Status)
        End If

        Return "ERROR"
    End Function

    Private Function getLanguageCode(ByVal idioma As String) As String
        Dim code = "null"
        Select Case idioma
            Case "Anglès"
                code = "EN"
            Case "Alemán"
                code = "DE"
            Case "Castellà"
                code = "ES"
            Case "Francès"
                code = "FR"
            Case "Italià"
                code = "IT"
            Case "Japonès"
                code = "JA"
            Case "Neerlandès"
                code = "NL"
            Case "Polonès"
                code = "PL"
            Case "Portuguès"
                code = "PT"
            Case "Rus"
                code = "RU"
            Case "Xinès "
                code = "ZH"
        End Select
        Return code
    End Function

End Class



