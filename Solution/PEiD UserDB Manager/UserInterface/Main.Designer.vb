Imports PEiD_UserDB_Manager.UserInterface

Namespace UserInterface

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Main
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
            Me.Button_Sort = New System.Windows.Forms.Button()
            Me.ComboBox_SortBy = New System.Windows.Forms.ComboBox()
            Me.Button_RemoveDups = New System.Windows.Forms.Button()
            Me.ComboBox_RemoveDupsBy = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TextBox_UserDB = New System.Windows.Forms.TextBox()
            Me.Label_LineCount = New System.Windows.Forms.Label()
            Me.Label_SigCount = New System.Windows.Forms.Label()
            Me.Timer_UpdateSignatureCount = New System.Windows.Forms.Timer(Me.components)
            Me.OpenFileDialog_LoadDatabase = New System.Windows.Forms.OpenFileDialog()
            Me.Label_Filename = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Button_Append = New System.Windows.Forms.Button()
            Me.Button_Save = New System.Windows.Forms.Button()
            Me.Button_OpenFile = New System.Windows.Forms.Button()
            Me.Button_ClearDatabase = New System.Windows.Forms.Button()
            Me.SaveFileDialog_SaveDatabase = New System.Windows.Forms.SaveFileDialog()
            Me.OpenFileDialog_AppendFiles = New System.Windows.Forms.OpenFileDialog()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Button_Sort
            '
            Me.Button_Sort.Enabled = False
            Me.Button_Sort.Location = New System.Drawing.Point(6, 79)
            Me.Button_Sort.Name = "Button_Sort"
            Me.Button_Sort.Size = New System.Drawing.Size(110, 23)
            Me.Button_Sort.TabIndex = 1
            Me.Button_Sort.Text = "Sort signatures"
            Me.Button_Sort.UseVisualStyleBackColor = True
            '
            'ComboBox_SortBy
            '
            Me.ComboBox_SortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ComboBox_SortBy.Enabled = False
            Me.ComboBox_SortBy.FormattingEnabled = True
            Me.ComboBox_SortBy.Items.AddRange(New Object() {"By Name", "By Signature"})
            Me.ComboBox_SortBy.Location = New System.Drawing.Point(6, 108)
            Me.ComboBox_SortBy.Name = "ComboBox_SortBy"
            Me.ComboBox_SortBy.Size = New System.Drawing.Size(110, 21)
            Me.ComboBox_SortBy.TabIndex = 2
            '
            'Button_RemoveDups
            '
            Me.Button_RemoveDups.Enabled = False
            Me.Button_RemoveDups.Location = New System.Drawing.Point(6, 162)
            Me.Button_RemoveDups.Name = "Button_RemoveDups"
            Me.Button_RemoveDups.Size = New System.Drawing.Size(110, 23)
            Me.Button_RemoveDups.TabIndex = 3
            Me.Button_RemoveDups.Text = "Remove duplicates"
            Me.Button_RemoveDups.UseVisualStyleBackColor = True
            '
            'ComboBox_RemoveDupsBy
            '
            Me.ComboBox_RemoveDupsBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ComboBox_RemoveDupsBy.Enabled = False
            Me.ComboBox_RemoveDupsBy.FormattingEnabled = True
            Me.ComboBox_RemoveDupsBy.Items.AddRange(New Object() {"By Name", "By Signature"})
            Me.ComboBox_RemoveDupsBy.Location = New System.Drawing.Point(6, 190)
            Me.ComboBox_RemoveDupsBy.Name = "ComboBox_RemoveDupsBy"
            Me.ComboBox_RemoveDupsBy.Size = New System.Drawing.Size(110, 21)
            Me.ComboBox_RemoveDupsBy.TabIndex = 4
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
            Me.Label1.Location = New System.Drawing.Point(0, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(702, 33)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "PEiD UserDB Manager"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'TextBox_UserDB
            '
            Me.TextBox_UserDB.AllowDrop = True
            Me.TextBox_UserDB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBox_UserDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.TextBox_UserDB.Location = New System.Drawing.Point(140, 105)
            Me.TextBox_UserDB.MaxLength = 0
            Me.TextBox_UserDB.Multiline = True
            Me.TextBox_UserDB.Name = "TextBox_UserDB"
            Me.TextBox_UserDB.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.TextBox_UserDB.Size = New System.Drawing.Size(550, 309)
            Me.TextBox_UserDB.TabIndex = 6
            '
            'Label_LineCount
            '
            Me.Label_LineCount.AutoSize = True
            Me.Label_LineCount.Location = New System.Drawing.Point(6, 18)
            Me.Label_LineCount.Name = "Label_LineCount"
            Me.Label_LineCount.Size = New System.Drawing.Size(84, 13)
            Me.Label_LineCount.TabIndex = 7
            Me.Label_LineCount.Text = "Database Lines:"
            '
            'Label_SigCount
            '
            Me.Label_SigCount.AutoSize = True
            Me.Label_SigCount.Location = New System.Drawing.Point(6, 34)
            Me.Label_SigCount.Name = "Label_SigCount"
            Me.Label_SigCount.Size = New System.Drawing.Size(86, 13)
            Me.Label_SigCount.TabIndex = 8
            Me.Label_SigCount.Text = "Signature Count:"
            '
            'Timer_UpdateSignatureCount
            '
            Me.Timer_UpdateSignatureCount.Interval = 750
            '
            'OpenFileDialog_LoadDatabase
            '
            Me.OpenFileDialog_LoadDatabase.DefaultExt = "txt"
            Me.OpenFileDialog_LoadDatabase.FileName = "UserDB.txt"
            Me.OpenFileDialog_LoadDatabase.Filter = "PeId Signature Database|*.txt"
            Me.OpenFileDialog_LoadDatabase.RestoreDirectory = True
            '
            'Label_Filename
            '
            Me.Label_Filename.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label_Filename.AutoSize = True
            Me.Label_Filename.Location = New System.Drawing.Point(12, 417)
            Me.Label_Filename.Name = "Label_Filename"
            Me.Label_Filename.Size = New System.Drawing.Size(49, 13)
            Me.Label_Filename.TabIndex = 11
            Me.Label_Filename.Text = "Filename"
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Controls.Add(Me.Label_LineCount)
            Me.GroupBox1.Controls.Add(Me.Label_SigCount)
            Me.GroupBox1.Location = New System.Drawing.Point(12, 36)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(678, 57)
            Me.GroupBox1.TabIndex = 12
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Database Info"
            '
            'GroupBox2
            '
            Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.GroupBox2.Controls.Add(Me.Button_Append)
            Me.GroupBox2.Controls.Add(Me.Button_Save)
            Me.GroupBox2.Controls.Add(Me.Button_OpenFile)
            Me.GroupBox2.Controls.Add(Me.ComboBox_SortBy)
            Me.GroupBox2.Controls.Add(Me.Button_ClearDatabase)
            Me.GroupBox2.Controls.Add(Me.Button_Sort)
            Me.GroupBox2.Controls.Add(Me.Button_RemoveDups)
            Me.GroupBox2.Controls.Add(Me.ComboBox_RemoveDupsBy)
            Me.GroupBox2.Location = New System.Drawing.Point(12, 99)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(122, 315)
            Me.GroupBox2.TabIndex = 13
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Database  Manager"
            '
            'Button_Append
            '
            Me.Button_Append.BackgroundImage = My.Resources.Resources.Append
            Me.Button_Append.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.Button_Append.Location = New System.Drawing.Point(35, 19)
            Me.Button_Append.Name = "Button_Append"
            Me.Button_Append.Size = New System.Drawing.Size(23, 23)
            Me.Button_Append.TabIndex = 12
            Me.Button_Append.UseVisualStyleBackColor = True
            '
            'Button_Save
            '
            Me.Button_Save.BackgroundImage = My.Resources.Resources.save
            Me.Button_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.Button_Save.Enabled = False
            Me.Button_Save.Location = New System.Drawing.Point(93, 19)
            Me.Button_Save.Name = "Button_Save"
            Me.Button_Save.Size = New System.Drawing.Size(23, 23)
            Me.Button_Save.TabIndex = 11
            Me.Button_Save.UseVisualStyleBackColor = True
            '
            'Button_OpenFile
            '
            Me.Button_OpenFile.BackgroundImage = My.Resources.Resources.OpenFile
            Me.Button_OpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.Button_OpenFile.Location = New System.Drawing.Point(6, 19)
            Me.Button_OpenFile.Name = "Button_OpenFile"
            Me.Button_OpenFile.Size = New System.Drawing.Size(23, 23)
            Me.Button_OpenFile.TabIndex = 9
            Me.Button_OpenFile.UseVisualStyleBackColor = True
            '
            'Button_ClearDatabase
            '
            Me.Button_ClearDatabase.BackColor = System.Drawing.SystemColors.Window
            Me.Button_ClearDatabase.BackgroundImage = My.Resources.Resources.Clear
            Me.Button_ClearDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.Button_ClearDatabase.Enabled = False
            Me.Button_ClearDatabase.Location = New System.Drawing.Point(64, 19)
            Me.Button_ClearDatabase.Name = "Button_ClearDatabase"
            Me.Button_ClearDatabase.Size = New System.Drawing.Size(23, 23)
            Me.Button_ClearDatabase.TabIndex = 10
            Me.Button_ClearDatabase.UseVisualStyleBackColor = False
            '
            'SaveFileDialog_SaveDatabase
            '
            Me.SaveFileDialog_SaveDatabase.DefaultExt = "txt"
            Me.SaveFileDialog_SaveDatabase.FileName = "UserDB.txt"
            Me.SaveFileDialog_SaveDatabase.Filter = "PeId Signature Database|*.txt"
            '
            'OpenFileDialog_AppendFiles
            '
            Me.OpenFileDialog_AppendFiles.DefaultExt = "txt"
            Me.OpenFileDialog_AppendFiles.Filter = "PeId Signature Database|*.txt"
            Me.OpenFileDialog_AppendFiles.Multiselect = True
            Me.OpenFileDialog_AppendFiles.RestoreDirectory = True
            '
            'Main
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.Window
            Me.ClientSize = New System.Drawing.Size(702, 439)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Label_Filename)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.TextBox_UserDB)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "Main"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "PEiD UserDB Manager"
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Button_Sort As System.Windows.Forms.Button
        Friend WithEvents ComboBox_SortBy As System.Windows.Forms.ComboBox
        Friend WithEvents Button_RemoveDups As System.Windows.Forms.Button
        Friend WithEvents ComboBox_RemoveDupsBy As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TextBox_UserDB As System.Windows.Forms.TextBox
        Friend WithEvents Label_LineCount As System.Windows.Forms.Label
        Friend WithEvents Label_SigCount As System.Windows.Forms.Label
        Friend WithEvents Timer_UpdateSignatureCount As System.Windows.Forms.Timer
        Friend WithEvents Button_OpenFile As System.Windows.Forms.Button
        Friend WithEvents Button_ClearDatabase As System.Windows.Forms.Button
        Friend WithEvents OpenFileDialog_LoadDatabase As System.Windows.Forms.OpenFileDialog
        Friend WithEvents Label_Filename As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Button_Save As System.Windows.Forms.Button
        Friend WithEvents SaveFileDialog_SaveDatabase As System.Windows.Forms.SaveFileDialog
        Friend WithEvents Button_Append As System.Windows.Forms.Button
        Friend WithEvents OpenFileDialog_AppendFiles As System.Windows.Forms.OpenFileDialog

    End Class

End Namespace