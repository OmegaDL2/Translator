<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        txtEndText = New TextBox()
        txtOriginText = New TextBox()
        radAutoDetect = New RadioButton()
        cbxOriginLanguage = New ComboBox()
        Label3 = New Label()
        cbxTargetLanguage = New ComboBox()
        btnTranslate = New Button()
        btnTestDeepl = New Button()
        btnTestGoogle = New Button()
        lblTranslatorUsed = New Label()
        ckbAutoDetect = New CheckBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(127, 20)
        Label1.TabIndex = 0
        Label1.Text = "Seleciona idioma:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 52)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 20)
        Label2.TabIndex = 1
        Label2.Text = "Text a traduir"
        ' 
        ' txtEndText
        ' 
        txtEndText.Location = New Point(24, 170)
        txtEndText.Name = "txtEndText"
        txtEndText.Size = New Size(630, 27)
        txtEndText.TabIndex = 2
        ' 
        ' txtOriginText
        ' 
        txtOriginText.Location = New Point(114, 49)
        txtOriginText.Name = "txtOriginText"
        txtOriginText.Size = New Size(540, 27)
        txtOriginText.TabIndex = 3
        ' 
        ' radAutoDetect
        ' 
        radAutoDetect.AutoSize = True
        radAutoDetect.Location = New Point(382, 338)
        radAutoDetect.Name = "radAutoDetect"
        radAutoDetect.Size = New Size(197, 24)
        radAutoDetect.TabIndex = 4
        radAutoDetect.Text = "Detecta Automaticament"
        radAutoDetect.UseVisualStyleBackColor = True
        ' 
        ' cbxOriginLanguage
        ' 
        cbxOriginLanguage.FormattingEnabled = True
        cbxOriginLanguage.Location = New Point(373, 5)
        cbxOriginLanguage.Name = "cbxOriginLanguage"
        cbxOriginLanguage.Size = New Size(206, 28)
        cbxOriginLanguage.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 126)
        Label3.Name = "Label3"
        Label3.Size = New Size(94, 20)
        Label3.TabIndex = 6
        Label3.Text = "Idioma Destí"
        ' 
        ' cbxTargetLanguage
        ' 
        cbxTargetLanguage.FormattingEnabled = True
        cbxTargetLanguage.Location = New Point(134, 123)
        cbxTargetLanguage.Name = "cbxTargetLanguage"
        cbxTargetLanguage.Size = New Size(198, 28)
        cbxTargetLanguage.TabIndex = 7
        ' 
        ' btnTranslate
        ' 
        btnTranslate.Location = New Point(485, 108)
        btnTranslate.Name = "btnTranslate"
        btnTranslate.Size = New Size(94, 29)
        btnTranslate.TabIndex = 8
        btnTranslate.Text = "Traduir"
        btnTranslate.UseVisualStyleBackColor = True
        ' 
        ' btnTestDeepl
        ' 
        btnTestDeepl.Location = New Point(191, 288)
        btnTestDeepl.Name = "btnTestDeepl"
        btnTestDeepl.Size = New Size(94, 29)
        btnTestDeepl.TabIndex = 9
        btnTestDeepl.Text = "test deep L"
        btnTestDeepl.UseVisualStyleBackColor = True
        ' 
        ' btnTestGoogle
        ' 
        btnTestGoogle.Location = New Point(336, 288)
        btnTestGoogle.Name = "btnTestGoogle"
        btnTestGoogle.Size = New Size(94, 29)
        btnTestGoogle.TabIndex = 10
        btnTestGoogle.Text = "test Google"
        btnTestGoogle.UseVisualStyleBackColor = True
        ' 
        ' lblTranslatorUsed
        ' 
        lblTranslatorUsed.AutoSize = True
        lblTranslatorUsed.Location = New Point(24, 217)
        lblTranslatorUsed.Name = "lblTranslatorUsed"
        lblTranslatorUsed.Size = New Size(21, 20)
        lblTranslatorUsed.TabIndex = 11
        lblTranslatorUsed.Text = "--"
        ' 
        ' ckbAutoDetect
        ' 
        ckbAutoDetect.AutoSize = True
        ckbAutoDetect.FlatStyle = FlatStyle.System
        ckbAutoDetect.Location = New Point(145, 8)
        ckbAutoDetect.Name = "ckbAutoDetect"
        ckbAutoDetect.Size = New Size(212, 25)
        ckbAutoDetect.TabIndex = 12
        ckbAutoDetect.Text = "Detectar Automaticament"
        ckbAutoDetect.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(ckbAutoDetect)
        Controls.Add(lblTranslatorUsed)
        Controls.Add(btnTestGoogle)
        Controls.Add(btnTestDeepl)
        Controls.Add(btnTranslate)
        Controls.Add(cbxTargetLanguage)
        Controls.Add(Label3)
        Controls.Add(cbxOriginLanguage)
        Controls.Add(radAutoDetect)
        Controls.Add(txtOriginText)
        Controls.Add(txtEndText)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEndText As TextBox
    Friend WithEvents txtOriginText As TextBox
    Friend WithEvents radAutoDetect As RadioButton
    Friend WithEvents cbxOriginLanguage As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbxTargetLanguage As ComboBox
    Friend WithEvents btnTranslate As Button
    Friend WithEvents btnTestDeepl As Button
    Friend WithEvents btnTestGoogle As Button
    Friend WithEvents lblTranslatorUsed As Label
    Friend WithEvents ckbAutoDetect As CheckBox

End Class
