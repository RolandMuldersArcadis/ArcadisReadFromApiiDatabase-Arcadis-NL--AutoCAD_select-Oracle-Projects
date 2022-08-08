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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txt_sap_projectNummer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txt_sap_projectOmschrijving = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_apiiwbsId = New System.Windows.Forms.TextBox()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.BTN_addversion = New System.Windows.Forms.Button()
        Me.txt_DocID = New System.Windows.Forms.TextBox()
        Me.txt_version = New System.Windows.Forms.TextBox()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.BTN_RetrieveTreeview = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.BTN_open_DOCIDs = New System.Windows.Forms.Button()
        Me.Txt_selectbox = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.BTN_RetrieveProjectsBIM360 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_AppVersion = New System.Windows.Forms.TextBox()
        Me.Txt_api_Projnumber = New System.Windows.Forms.TextBox()
        Me.lb_recentused = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Projectname = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1145, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(1046, 40)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(93, 30)
        Me.ListBox1.TabIndex = 1
        Me.ListBox1.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(986, 98)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(532, 97)
        Me.DataGridView1.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Button2.Location = New System.Drawing.Point(1358, 59)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(160, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Retrieve SAP_Projects"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(1046, 13)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(459, 21)
        Me.ComboBox1.TabIndex = 4
        Me.ComboBox1.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(987, 201)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(531, 104)
        Me.DataGridView2.TabIndex = 5
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1033, 669)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(160, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Select SAP_WBS"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'txt_sap_projectNummer
        '
        Me.txt_sap_projectNummer.Location = New System.Drawing.Point(178, 18)
        Me.txt_sap_projectNummer.Name = "txt_sap_projectNummer"
        Me.txt_sap_projectNummer.Size = New System.Drawing.Size(190, 20)
        Me.txt_sap_projectNummer.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "FilterSAP_projectnummer"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Button4.Location = New System.Drawing.Point(384, 581)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(160, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Create DocID + Close"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'txt_sap_projectOmschrijving
        '
        Me.txt_sap_projectOmschrijving.Location = New System.Drawing.Point(178, 43)
        Me.txt_sap_projectOmschrijving.Name = "txt_sap_projectOmschrijving"
        Me.txt_sap_projectOmschrijving.Size = New System.Drawing.Size(190, 20)
        Me.txt_sap_projectOmschrijving.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "FilterSAP_projectOmschrijving"
        '
        'txt_apiiwbsId
        '
        Me.txt_apiiwbsId.Enabled = False
        Me.txt_apiiwbsId.Location = New System.Drawing.Point(287, 665)
        Me.txt_apiiwbsId.Name = "txt_apiiwbsId"
        Me.txt_apiiwbsId.Size = New System.Drawing.Size(134, 20)
        Me.txt_apiiwbsId.TabIndex = 11
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(12, 711)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(165, 77)
        Me.DataGridView3.TabIndex = 12
        '
        'BTN_addversion
        '
        Me.BTN_addversion.BackColor = System.Drawing.SystemColors.Control
        Me.BTN_addversion.Location = New System.Drawing.Point(381, 825)
        Me.BTN_addversion.Name = "BTN_addversion"
        Me.BTN_addversion.Size = New System.Drawing.Size(160, 24)
        Me.BTN_addversion.TabIndex = 13
        Me.BTN_addversion.Text = "Add Doc Version(s)"
        Me.BTN_addversion.UseVisualStyleBackColor = False
        '
        'txt_DocID
        '
        Me.txt_DocID.Location = New System.Drawing.Point(9, 829)
        Me.txt_DocID.Name = "txt_DocID"
        Me.txt_DocID.Size = New System.Drawing.Size(166, 20)
        Me.txt_DocID.TabIndex = 14
        '
        'txt_version
        '
        Me.txt_version.Location = New System.Drawing.Point(190, 829)
        Me.txt_version.Name = "txt_version"
        Me.txt_version.Size = New System.Drawing.Size(134, 20)
        Me.txt_version.TabIndex = 15
        '
        'DataGridView4
        '
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Location = New System.Drawing.Point(8, 865)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.Size = New System.Drawing.Size(167, 141)
        Me.DataGridView4.TabIndex = 16
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(626, 84)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(343, 577)
        Me.TreeView1.TabIndex = 17
        '
        'BTN_RetrieveTreeview
        '
        Me.BTN_RetrieveTreeview.Location = New System.Drawing.Point(626, 47)
        Me.BTN_RetrieveTreeview.Name = "BTN_RetrieveTreeview"
        Me.BTN_RetrieveTreeview.Size = New System.Drawing.Size(103, 23)
        Me.BTN_RetrieveTreeview.TabIndex = 18
        Me.BTN_RetrieveTreeview.Text = "RetrieveTreeview"
        Me.BTN_RetrieveTreeview.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(1056, 522)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(215, 56)
        Me.ListBox2.TabIndex = 19
        '
        'BTN_open_DOCIDs
        '
        Me.BTN_open_DOCIDs.Location = New System.Drawing.Point(381, 933)
        Me.BTN_open_DOCIDs.Name = "BTN_open_DOCIDs"
        Me.BTN_open_DOCIDs.Size = New System.Drawing.Size(160, 24)
        Me.BTN_open_DOCIDs.TabIndex = 22
        Me.BTN_open_DOCIDs.Text = "open_DOCIDs..."
        Me.BTN_open_DOCIDs.UseVisualStyleBackColor = True
        '
        'Txt_selectbox
        '
        Me.Txt_selectbox.Location = New System.Drawing.Point(1045, 179)
        Me.Txt_selectbox.Name = "Txt_selectbox"
        Me.Txt_selectbox.Size = New System.Drawing.Size(307, 20)
        Me.Txt_selectbox.TabIndex = 23
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button5.Location = New System.Drawing.Point(381, 737)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(160, 23)
        Me.Button5.TabIndex = 24
        Me.Button5.Text = "Close to continue >>"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'ListBox3
        '
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Location = New System.Drawing.Point(1046, 272)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(120, 95)
        Me.ListBox3.TabIndex = 25
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(1045, 216)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(121, 23)
        Me.Button6.TabIndex = 26
        Me.Button6.Text = "Button6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.AllowDrop = True
        Me.ComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(1045, 245)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 27
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button7.Location = New System.Drawing.Point(381, 711)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(160, 23)
        Me.Button7.TabIndex = 28
        Me.Button7.Text = "Create DocID + NO Close"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'DataGridView5
        '
        Me.DataGridView5.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Location = New System.Drawing.Point(12, 84)
        Me.DataGridView5.MultiSelect = False
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.ReadOnly = True
        Me.DataGridView5.RowHeadersVisible = False
        Me.DataGridView5.Size = New System.Drawing.Size(532, 441)
        Me.DataGridView5.TabIndex = 29
        '
        'BTN_RetrieveProjectsBIM360
        '
        Me.BTN_RetrieveProjectsBIM360.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BTN_RetrieveProjectsBIM360.Location = New System.Drawing.Point(375, 41)
        Me.BTN_RetrieveProjectsBIM360.Name = "BTN_RetrieveProjectsBIM360"
        Me.BTN_RetrieveProjectsBIM360.Size = New System.Drawing.Size(169, 23)
        Me.BTN_RetrieveProjectsBIM360.TabIndex = 30
        Me.BTN_RetrieveProjectsBIM360.Text = "Retrieve SAP_Projects BIM360"
        Me.BTN_RetrieveProjectsBIM360.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 561)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(352, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Select a text in the row of the ProjectNumber or MRU and click button >>"
        '
        'Txt_AppVersion
        '
        Me.Txt_AppVersion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt_AppVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AppVersion.Location = New System.Drawing.Point(439, 2)
        Me.Txt_AppVersion.Name = "Txt_AppVersion"
        Me.Txt_AppVersion.Size = New System.Drawing.Size(105, 11)
        Me.Txt_AppVersion.TabIndex = 33
        '
        'Txt_api_Projnumber
        '
        Me.Txt_api_Projnumber.Enabled = False
        Me.Txt_api_Projnumber.Location = New System.Drawing.Point(384, 531)
        Me.Txt_api_Projnumber.Name = "Txt_api_Projnumber"
        Me.Txt_api_Projnumber.Size = New System.Drawing.Size(160, 20)
        Me.Txt_api_Projnumber.TabIndex = 34
        '
        'lb_recentused
        '
        Me.lb_recentused.FormattingEnabled = True
        Me.lb_recentused.Location = New System.Drawing.Point(56, 591)
        Me.lb_recentused.Name = "lb_recentused"
        Me.lb_recentused.Size = New System.Drawing.Size(189, 43)
        Me.lb_recentused.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 591)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "MRU:"
        '
        'Txt_Projectname
        '
        Me.Txt_Projectname.Enabled = False
        Me.Txt_Projectname.Location = New System.Drawing.Point(384, 557)
        Me.Txt_Projectname.Name = "Txt_Projectname"
        Me.Txt_Projectname.Size = New System.Drawing.Size(160, 20)
        Me.Txt_Projectname.TabIndex = 39
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(573, 656)
        Me.Controls.Add(Me.Txt_Projectname)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lb_recentused)
        Me.Controls.Add(Me.Txt_api_Projnumber)
        Me.Controls.Add(Me.Txt_AppVersion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTN_RetrieveProjectsBIM360)
        Me.Controls.Add(Me.DataGridView5)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Txt_selectbox)
        Me.Controls.Add(Me.BTN_open_DOCIDs)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.BTN_RetrieveTreeview)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.DataGridView4)
        Me.Controls.Add(Me.txt_version)
        Me.Controls.Add(Me.txt_DocID)
        Me.Controls.Add(Me.BTN_addversion)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.txt_apiiwbsId)
        Me.Controls.Add(Me.txt_sap_projectOmschrijving)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_sap_projectNummer)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Arcadis Project + WBS selector + DocID Generator"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents txt_sap_projectNummer As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents txt_sap_projectOmschrijving As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_apiiwbsId As TextBox
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents BTN_addversion As Button
    Friend WithEvents txt_DocID As TextBox
    Friend WithEvents txt_version As TextBox
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents BTN_RetrieveTreeview As Button
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents BTN_open_DOCIDs As Button
    Friend WithEvents Txt_selectbox As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents ListBox3 As ListBox
    Friend WithEvents Button6 As Button
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Button7 As Button
    Friend WithEvents DataGridView5 As DataGridView
    Friend WithEvents BTN_RetrieveProjectsBIM360 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_AppVersion As TextBox
    Friend WithEvents Txt_api_Projnumber As TextBox
    Friend WithEvents lb_recentused As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_Projectname As TextBox
End Class
