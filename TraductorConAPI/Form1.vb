Imports System.Security
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports Windows.Win32.System
Imports Newtonsoft.Json
Imports Microsoft.Extensions.Configuration
Imports Google.Cloud.Translation.V2
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Diagnostics.Eventing.Reader


Public Class Form1
    'Private Const DeepLApiKey As String = "YOUR-Deepl_PRIVATE_KEY"

    Private Const DeepLApiKey As String = "YOUR_DeepLApiKey"
    Private Const GoogleApiKey As String = "YOUR_GoogleApiKey"


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim suportedLanguages() As String = {"Anglès", "Català", "Alemán", "Castellà", "Francès", "Italià", "Japonès", "Neerlandès",
                             "Polonès", "Portuguès", "Rus", "Xinès", "Afrikaans", "Amharic", "Àrab", "Azerbaijani",
                             "Bielorús", "Búlgar", "Bengalí", "Bosnià", "Cebuà", "Cors", "Txec", "Gal·lès", "Danès",
                             "Grec", "Esperanto", "Estonià", "Basc", "Persa", "Finlandès", "Frisó", "Gaèlic irlandès",
                             "Gaèlic escocès", "Gallec", "Gujarati", "Hausa", "Hawaià", "Hindi", "Hmong", "Croat", "Criolla haitiana",
                             "Hongarès", "Armeni", "Indonesi", "Igbo", "Islandès", "Hebreu", "Javanès", "Georgià", "Kannada",
                             "Kazakh", "Khmer", "Coreà", "Kurmanji", "Kirguís", "Lao", "Letó", "Lituà", "Luxemburguès", "Macedoni",
                             "Malgaix", "Malai", "Malayalam", "Maltès", "Maori", "Marathi", "Mongol", "Nepalès", "Noruec", "Pashto",
                             "Persa", "Polonès", "Punyabí", "Romanès", "Sango", "Serbi", "Sesotho", "Shona", "Sindhi", "Sinhala",
                             "Eslovac", "Eslovè", "Somali", "Sotho", "Sundanès", "Suahili", "Suec", "Swahili", "Tajik", "Tamil",
                             "Telugu", "Tailandès", "Turc", "Ucraïnès", "Urdu", "Uzbek", "Vietnamita", "Gal·lès", "Xhosa", "Iídix",
                             "Yoruba", "Zulu"}
        cbxOriginLanguage.Items.AddRange(suportedLanguages)
        cbxTargetLanguage.Items.AddRange(suportedLanguages)
    End Sub

    Private Sub btnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        Dim originalText As String
        Dim endText As String
        Dim targetLanguageCode As String
        Dim originalLanguageCode As String

        originalText = txtOriginText.Text
        targetLanguageCode = getLanguageCode(cbxTargetLanguage.SelectedItem.ToString)


        'See and set the original language based on the checkd buton or the list
        If ckbAutoDetect.Checked Then
            ' if autodetect language is selected then
            originalLanguageCode = detectLanguage(originalText)

        Else
            If cbxOriginLanguage.SelectedItem Is Nothing Then
                MsgBox("No item selected!", vbExclamation)
                Exit Sub
            Else
                originalLanguageCode = getLanguageCode(cbxOriginLanguage.SelectedItem.ToString)

            End If
        End If


        ' Check if languages are suported by deepl
        ' If languages are suported use deepl to translate
        ' Else use googleto translate
        If (isSuportedByDeepL(originalLanguageCode, targetLanguageCode)) Then

            endText = TranslateTextWithDeepL(originalText, targetLanguageCode) 'For now only Deepl works
            lblTranslatorUsed.Text = "Traductor usado: deepl"

        Else

            endText = TranslateTextWithGoogle(originalText, targetLanguageCode, originalLanguageCode)
            lblTranslatorUsed.Text = "Traductor usado: google"

        End If

        txtEndText.Text = endText
    End Sub

    Private Sub btnTestDeepl_Click(sender As Object, e As EventArgs) Handles btnTestDeepl.Click
        TestTranslationDeepl()
    End Sub

    Private Sub btnTestGoogle_Click(sender As Object, e As EventArgs) Handles btnTestGoogle.Click
        TestTranslationGoogle()
    End Sub

    Sub TestTranslationDeepl() ' Test that TranslateTextWithDeepL works
        On Error GoTo ErrorHandler

        Dim originalText As String
        Dim targetLanguage As String
        Dim translatedText As String

        ' Example translation: English to German
        originalText = "Hola, esto es un test :D"
        targetLanguage = "de"

        translatedText = TranslateTextWithDeepL(originalText, targetLanguage)

        MsgBox("Translated text: " & translatedText)

        Exit Sub

ErrorHandler:
        MsgBox("Error: " & Err.Description)
    End Sub

    Sub TestTranslationGoogle()
        Dim originalText As String = "Hola esto es un test usando Google Traductor API :D"
        Dim targetLanguage As String = "en"
        Dim originalLanguage As String = "es"

        Dim translatedText As String
        translatedText = TranslateTextWithGoogle(originalText, targetLanguage, originalLanguage)

        ' Display the translated text or any errors
        MsgBox(translatedText)
    End Sub

    Public Function TranslateTextWithGoogle(originalText As String, targetLanguage As String, originalLanguage As String) As String
        ' The translated text
        Dim translatedText As String = "ERORR: General Error on TranslateTextWithGoogle"

        Dim translateClient As TranslationClient
        translateClient = TranslationClient.CreateFromApiKey(GoogleApiKey)

        Dim response As TranslationResult
        response = translateClient.TranslateText(originalText, targetLanguage, originalLanguage)

        translatedText = response.TranslatedText

        Return translatedText
    End Function

    Public Function TranslateTextWithDeepL(originalText As String, targetLanguage As String, Optional originalLanguage As String = Nothing) As String


        ' URL for the DeepL translation endpoint
        Const DeepLTranslateUrl As String = "https://api-free.deepl.com/v2/translate"

        Dim http As Object
        http = CreateObject("MSXML2.ServerXMLHTTP")

        ' Set up request headers
        http.Open("POST", DeepLTranslateUrl, False)
        http.setRequestHeader("Authorization", "DeepL-Auth-Key " & DeepLApiKey)
        http.setRequestHeader("User-Agent", "myApp/0.3")
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

        Return "ERORR: General Error on TranslateTextWithDeepL"
    End Function

    Private Function detectLanguage(ByVal OriginalText As String) As String
        Dim translatedText As String = "ERORR: General Error on detectLanguage"

        Dim translateClient As TranslationClient
        translateClient = TranslationClient.CreateFromApiKey(GoogleApiKey)

        Dim response As Detection
        response = translateClient.DetectLanguage(OriginalText)

        translatedText = response.Language()

        Return translatedText
    End Function

    Private Function getLanguageCode(ByVal idioma As String) As String
        Dim code = "null"
        Select Case idioma
            Case "Català"
                code = "ca"
            Case "Anglès"
                code = "en"
            Case "Alemán"
                code = "de"
            Case "Castellà"
                code = "es"
            Case "Francès"
                code = "fr"
            Case "Italià"
                code = "it"
            Case "Japonès"
                code = "ja"
            Case "Neerlandès"
                code = "nl"
            Case "Polonès"
                code = "pl"
            Case "Portuguès"
                code = "pt"
            Case "Rus"
                code = "ru"
            Case "Xinès"
                code = "zh"
            Case "Afrikaans"
                code = "af"
            Case "Amharic"
                code = "am"
            Case "Àrab"
                code = "ar"
            Case "Azerbaijani"
                code = "az"
            Case "Bielorús"
                code = "be"
            Case "Búlgar"
                code = "bg"
            Case "Bengalí"
                code = "bn"
            Case "Bosnià"
                code = "bs"
            Case "Cebuà"
                code = "ceb"
            Case "Cors"
                code = "co"
            Case "Txec"
                code = "cs"
            Case "Gal·lès"
                code = "cy"
            Case "Danès"
                code = "da"
            Case "Grec"
                code = "el"
            Case "Esperanto"
                code = "eo"
            Case "Estonià"
                code = "et"
            Case "Basc"
                code = "eu"
            Case "Persa"
                code = "fa"
            Case "Finlandès"
                code = "fi"
            Case "Frisó"
                code = "fy"
            Case "Gaèlic irlandès"
                code = "ga"
            Case "Gaèlic escocès"
                code = "gd"
            Case "Gallec"
                code = "gl"
            Case "Gujarati"
                code = "gu"
            Case "Hausa"
                code = "ha"
            Case "Hawaià"
                code = "haw"
            Case "Hindi"
                code = "hi"
            Case "Hmong"
                code = "hmn"
            Case "Croat"
                code = "hr"
            Case "Criolla haitiana"
                code = "ht"
            Case "Hongarès"
                code = "hu"
            Case "Armeni"
                code = "hy"
            Case "Indonesi"
                code = "id"
            Case "Igbo"
                code = "ig"
            Case "Islandès"
                code = "is"
            Case "Hebreu"
                code = "iw"
            Case "Javanès"
                code = "jw"
            Case "Georgià"
                code = "ka"
        End Select
        Return code
    End Function

    Private Function isSuportedByDeepL(ByVal lanOne As String, ByVal lanTwo As String) As Boolean
        ' devuelve verdad si ambos idiomas pueden usar deepL para traducir 

        Dim IdiomesSoportats() As String = {"zh", "ru", "pt", "pl", "nl", "ja", "it", "fr", "es", "de", "en"}

        Return IdiomesSoportats.Contains(lanOne) And IdiomesSoportats.Contains(lanTwo)
    End Function

End Class



