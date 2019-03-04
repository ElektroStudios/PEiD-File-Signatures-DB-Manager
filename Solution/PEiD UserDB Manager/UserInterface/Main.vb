' ***********************************************************************
' Assembly : PeId Database Manager
' Author   : Elektro
' Modified : 12-28-2014
' ***********************************************************************
' <copyright file="Main.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Option Statements "

Option Explicit On
Option Strict On
Option Infer Off

#End Region

#Region " Imports "

Imports PEiD_UserDB_Manager.Tools
Imports PEiD_UserDB_Manager.Tools.UserDBTools
Imports System.IO
Imports System.Text
Imports System.ComponentModel

#End Region

Namespace UserInterface

#Region " Main "

    ''' <summary>
    ''' The Main user-interface Form.
    ''' </summary>
    Public NotInheritable Class Main

#Region " Properties "

        ''' <summary>
        ''' Gets or sets the PeId database's field to sort the signatures.
        ''' </summary>
        ''' <value>The PeId database's field to sort the signatures.</value>
        Private Property SortBy As DatabaseField = DatabaseField.Name

        ''' <summary>
        ''' Gets or sets the PeId database's field to remove duplicated signatures.
        ''' </summary>
        ''' <value>The PeId database's field to remove duplicated signatures.</value>
        Private Property RemoveDupsBy As DatabaseField = DatabaseField.Name

        ''' <summary>
        ''' Gets or sets the text encoding to read/write the UserDB.txt.
        ''' </summary>
        ''' <value>The text encoding to read/write the UserDB.txt.</value>
        Private ReadOnly Property DefaultEncoding As Encoding
            Get
                Return Encoding.Default
            End Get
        End Property

#End Region

#Region " Event Handlers "

        ''' <summary>
        ''' Handles the Load event of the Main control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Main_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load

            Me.LoadDefaultsettings()

        End Sub

        ''' <summary>
        ''' Handles the ResizeBegin event of the Main control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Main_ResizeBegin(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.ResizeBegin

            Me.TextBox_UserDB.SuspendLayout()
            Me.Timer_UpdateSignatureCount.Stop()

        End Sub

        ''' <summary>
        ''' Handles the ResizeEnd event of the Main control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Main_ResizeEnd(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.ResizeEnd

            Me.TextBox_UserDB.ResumeLayout()
            Me.Timer_UpdateSignatureCount.Start()

        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the TextBox_UserDB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub TextBox_UserDB_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TextBox_UserDB.TextChanged

            Dim tb As TextBox = DirectCast(sender, TextBox)
            Dim text As String = tb.Text

            Me.Button_Sort.Enabled = Not String.IsNullOrEmpty(text)
            Me.ComboBox_SortBy.Enabled = Not String.IsNullOrEmpty(text)
            Me.Button_RemoveDups.Enabled = Not String.IsNullOrEmpty(text)
            Me.ComboBox_RemoveDupsBy.Enabled = Not String.IsNullOrEmpty(text)
            Me.Button_Save.Enabled = Not String.IsNullOrEmpty(text)
            Me.Button_ClearDatabase.Enabled = Not String.IsNullOrEmpty(text)
            Me.Timer_UpdateSignatureCount.Enabled = Not String.IsNullOrEmpty(text)

            Me.BeginInvokeControl(Me.Label_LineCount, Sub(lb As Label)
                                                          lb.Text = String.Format("Database Lines: {0}", CStr(tb.Lines.Count))
                                                      End Sub)

            If String.IsNullOrEmpty(text) Then ' Reset signature count text.
                Me.Label_SigCount.Text = "Signature Count: 0"
            End If

        End Sub

        ''' <summary>
        ''' Handles the KeyDown event of the TextBox_UserDB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        Private Sub TextBox_UserDB_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
        Handles TextBox_UserDB.KeyDown

            ' Select All
            If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.A Then
                DirectCast(sender, TextBox).SelectAll()
            End If

        End Sub

        ''' <summary>
        ''' Handles the DragEnter event of the TextBox_UserDB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        Private Sub TextBox_UserDB_DragEnter(sender As Object, e As DragEventArgs) _
        Handles TextBox_UserDB.DragEnter

            If e.Data.GetDataPresent(DataFormats.FileDrop) Then

                Dim filenames As IEnumerable(Of String) =
                    DirectCast(e.Data.GetData(DataFormats.FileDrop), IEnumerable(Of String))

                If (From filename As String In filenames
                    Where Not Path.GetExtension(filename).Equals(".txt", StringComparison.OrdinalIgnoreCase)).Any Then
                    e.Effect = DragDropEffects.None

                Else
                    e.Effect = DragDropEffects.All

                End If

            End If

        End Sub

        ''' <summary>
        ''' Handles the DragDrop event of the TextBox_UserDB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        Private Sub TextBox_UserDB_DragDrop(sender As Object, e As DragEventArgs) _
        Handles TextBox_UserDB.DragDrop

            If e.Data.GetDataPresent(DataFormats.FileDrop) Then

                Me.AppendFiles(DirectCast(e.Data.GetData(DataFormats.FileDrop), IEnumerable(Of String)))

            End If

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the ComboBox_SortBy control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ComboBox_SortBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ComboBox_SortBy.SelectedIndexChanged

            Me.SortBy = DirectCast([Enum].Parse(GetType(DatabaseField),
                                                DirectCast(sender, ComboBox).Text.Split(" "c).Last, True), DatabaseField)

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the ComboBox_RemoveDupsBy control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ComboBox_RemoveDupsBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ComboBox_RemoveDupsBy.SelectedIndexChanged

            Me.RemoveDupsBy = DirectCast([Enum].Parse(GetType(DatabaseField),
                                                      DirectCast(sender, ComboBox).Text.Split(" "c).Last, True), DatabaseField)

        End Sub

        ''' <summary>
        ''' Handles the Click event of the Button_Sort control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Button_Sort_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Button_Sort.Click

            Me.DisableControls()
            Me.TextBox_UserDB.Text = UserDBTools.SortUserDB(Me.TextBox_UserDB.Text, Me.SortBy)
            Me.EnableControls()

        End Sub

        ''' <summary>
        ''' Handles the Click event of the Button_RemoveDups control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Button_RemoveDups_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Button_RemoveDups.Click

            Me.DisableControls()
            Me.TextBox_UserDB.Text = UserDBTools.RemoveUserDBDuplicates(Me.TextBox_UserDB.Text, Me.RemoveDupsBy)
            Me.EnableControls()

        End Sub

        ''' <summary>
        ''' Handles the Click event of the Button_OpenFile control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Button_OpenFile_Click(sender As Object, e As EventArgs) _
        Handles Button_OpenFile.Click

            Me.OpenFileDialog_LoadDatabase.ShowDialog()

        End Sub

        ''' <summary>
        ''' Handles the Click event of the Button_Append control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Button_Append_Click(sender As Object, e As EventArgs) _
        Handles Button_Append.Click

            Me.OpenFileDialog_AppendFiles.ShowDialog()

        End Sub

        ''' <summary>
        ''' Handles the Click event of the Button_Save control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Button_Save_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Button_Save.Click

            Me.SaveFileDialog_SaveDatabase.ShowDialog()

        End Sub

        ''' <summary>
        ''' Handles the Click event of the Button_ClearDatabase control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Button_ClearDatabase_Click(sender As Object, e As EventArgs) _
        Handles Button_ClearDatabase.Click

            Me.TextBox_UserDB.Clear()

        End Sub

        ''' <summary>
        ''' Handles the FileOk event of the OpenFileDialog_LoadDatabase control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        Private Sub OpenFileDialog_LoadDatabase_FileOk(sender As Object, e As CancelEventArgs) _
        Handles OpenFileDialog_LoadDatabase.FileOk

            Dim ofd As OpenFileDialog = DirectCast(sender, OpenFileDialog)

            Try
                Me.TextBox_UserDB.Text = File.ReadAllText(ofd.FileName, Me.DefaultEncoding)
                Me.Label_Filename.Text = ofd.FileName

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Sub

        ''' <summary>
        ''' Handles the FileOk event of the OpenFileDialog_AppendFiles control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        Private Sub OpenFileDialog_AppendFiles_FileOk(sender As Object, e As CancelEventArgs) _
        Handles OpenFileDialog_AppendFiles.FileOk

            Me.Appendfiles(DirectCast(sender, OpenFileDialog).FileNames)

        End Sub

        ''' <summary>
        ''' Handles the FileOk event of the SaveFileDialog_SaveDatabase control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        Private Sub SaveFileDialog_SaveDatabase_FileOk(sender As Object, e As CancelEventArgs) _
        Handles SaveFileDialog_SaveDatabase.FileOk

            Dim sfd As SaveFileDialog = DirectCast(sender, SaveFileDialog)

            Try
                File.WriteAllText(sfd.FileName, Me.TextBox_UserDB.Text, Me.DefaultEncoding)
                Me.Label_Filename.Text = sfd.FileName

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Sub

        ''' <summary>
        ''' Handles the Tick event of the Timer_UpdateSignatureCount control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Timer_UpdateSignatureCount_Tick(sender As Object, e As EventArgs) _
        Handles Timer_UpdateSignatureCount.Tick

            ' Avoid redundant calls.
            Static oldText As String = Me.TextBox_UserDB.Text
            Dim newText As String = Me.TextBox_UserDB.Text
            If newText = oldText Then
                Exit Sub
            Else
                oldText = newText
            End If

            Me.BeginInvokeControl(Me.Label_SigCount, Sub(lb As Label)
                                                         lb.Text = String.Format("Signature Count: {0}", CStr(UserDBTools.GetBlocks(newText).Count))
                                                     End Sub)

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' Loaddefaultsettingses this instance.
        ''' </summary>
        Private Sub LoadDefaultsettings()

            Me.Label_Filename.Text = String.Empty
            Me.ComboBox_SortBy.Text = String.Format("By {0}", DatabaseField.Name.ToString)
            Me.ComboBox_RemoveDupsBy.Text = String.Format("By {0}", DatabaseField.Signature.ToString)

        End Sub

        ''' <summary>
        ''' Disables the main user interface controls.
        ''' </summary>
        Private Sub DisableControls()

            Me.Button_Sort.Enabled = False
            Me.Button_RemoveDups.Enabled = False
            Me.TextBox_UserDB.Enabled = False

        End Sub

        ''' <summary>
        ''' Enables the main user interface controls.
        ''' </summary>
        Private Sub EnableControls()

            Me.Button_Sort.Enabled = True
            Me.Button_RemoveDups.Enabled = True
            Me.TextBox_UserDB.Enabled = True

        End Sub

        ''' <summary>
        ''' Appends the specified files in the UserDB TextBox.
        ''' </summary>
        ''' <param name="filenames">The filenames.</param>
        Private Sub AppendFiles(ByVal filenames As IEnumerable(Of String))

            For Each filename As String In filenames

                Try
                    Me.TextBox_UserDB.AppendText(Environment.NewLine &
                                                 File.ReadAllText(filename, Me.DefaultEncoding) &
                                                 Environment.NewLine)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try

            Next filename

        End Sub

        ''' <summary>
        ''' Invokes an <see cref="T:Action"/> delegate on the specified control.
        ''' This method avoids cross-threading exceptions.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="control">The control to invoke.</param>
        ''' <param name="action">The encapsulated method.</param>
        Public Sub BeginInvokeControl(Of T As Control)(ByVal control As T, ByVal action As Action(Of T))

            If control.InvokeRequired Then
                control.BeginInvoke(New Action(Of T, Action(Of T))(AddressOf BeginInvokeControl),
                                    New Object() {control, action})

            Else
                action(control)

            End If

        End Sub

#End Region

    End Class

#End Region

End Namespace