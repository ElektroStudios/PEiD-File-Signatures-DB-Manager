' ***********************************************************************
' Author   : Elektro
' Modified : 12-28-2014
' ***********************************************************************
' <copyright file="UserDBTools.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Option Statements "

Option Explicit On
Option Strict On
Option Infer Off

#End Region

#Region " Imports "

Imports System.Text.RegularExpressions

#End Region

Namespace Tools

#Region " UserDBTools "

    ''' <summary>
    ''' Class UserDBTools. This class cannot be inherited.
    ''' </summary>
    Friend NotInheritable Class UserDBTools

#Region " Enumerations "

        ''' <summary>
        ''' Specifies a PeId signature database field.
        ''' </summary>
        Friend Enum DatabaseField As Integer

            ''' <summary>
            ''' The name field.
            ''' </summary>
            Name = &H0

            ''' <summary>
            ''' The signature field.
            ''' </summary>
            Signature = &H1

        End Enum

#End Region

#Region " Types "

#Region " RegExPatterns "

        ''' <summary>
        ''' Constains the PeId signature database regular expression patterns.
        ''' </summary>
        Friend NotInheritable Class RegExPatterns

#Region " Properties "

            ''' <summary>
            ''' Regular Expression that matches UserDB comment lines.
            ''' </summary>
            Friend Shared ReadOnly Property CommentLine As Regex
                Get
                    Return New Regex("^(\s+)?;.+", RegexOptions.Multiline)
                End Get
            End Property

            ''' <summary>
            ''' Regular Expression that matches UserDB signature blocks.
            ''' </summary>
            Friend Shared ReadOnly Property Block As Regex
                Get
                    Return New Regex("\n\s+?$", RegexOptions.Multiline)
                End Get
            End Property

            ''' <summary>
            ''' Regular Expression that matches UserDB signature names.
            ''' </summary>
            Friend Shared ReadOnly Property Name As Regex
                Get
                    Return New Regex("\[(.+)\]", RegexOptions.Singleline)
                End Get
            End Property

            ''' <summary>
            ''' Regular Expression that matches UserDB signatures.
            ''' </summary>
            Friend Shared ReadOnly Property Signature As Regex
                Get
                    Return New Regex("signature\s=\s(.+)", RegexOptions.Singleline)
                End Get
            End Property

#End Region

#Region " Constructors "

            ''' <summary>
            ''' Prevents a default instance of the <see cref="RegExPatterns"/> class from being created.
            ''' </summary>
            Private Sub New()

            End Sub

#End Region

        End Class

#End Region

#End Region

#Region " Public Methods "

        ''' <summary>
        ''' Gets the user database's signature blocks.
        ''' </summary>
        ''' <param name="text">The text.</param>
        ''' <returns>System.String().</returns>
        Friend Shared Function GetBlocks(ByVal text As String) As IEnumerable(Of String)

            Return From match As String In RegExPatterns.Block.Split(text)
                   Where Not RegExPatterns.CommentLine.IsMatch(match) _
                         AndAlso RegExPatterns.Signature.IsMatch(match)
                   Select match.Trim(Environment.NewLine.ToCharArray)

        End Function

        ''' <summary>
        ''' Sorts the user database's signature blocks.
        ''' </summary>
        ''' <param name="text">The user database text.</param>
        ''' <param name="sortBy">The sorting field.</param>
        ''' <returns>System.String.</returns>
        Friend Shared Function SortUserDB(ByVal text As String,
                                          ByVal sortBy As DatabaseField) As String

            Dim sortByRegExPattern As Regex

            Select Case sortBy

                Case DatabaseField.Name
                    sortByRegExPattern = RegExPatterns.Name

                Case DatabaseField.Signature
                    sortByRegExPattern = RegExPatterns.Signature

                Case Else
                    sortByRegExPattern = Nothing

            End Select

            Dim blocks As IEnumerable(Of String) = GetBlocks(text)
            If blocks.Count < 1 Then
                Return text
            End If

            Dim orderedBlocks As IEnumerable(Of String) =
                From match As String In blocks
                Order By sortByRegExPattern.Match(match).Value
                Select match

            Return String.Join(Environment.NewLine & Environment.NewLine, orderedBlocks)

        End Function

        ''' <summary>
        ''' Removes the user database's signature duplicates.
        ''' </summary>
        ''' <param name="text">The text.</param>
        ''' <param name="removeBy">The remove by.</param>
        ''' <returns>System.String.</returns>
        Friend Shared Function RemoveUserDBDuplicates(ByVal text As String,
                                                      ByVal removeBy As DatabaseField) As String

            Dim removeByRegExPattern As Regex

            Select Case removeBy

                Case DatabaseField.Name
                    removeByRegExPattern = RegExPatterns.Name

                Case DatabaseField.Signature
                    removeByRegExPattern = RegExPatterns.Signature

                Case Else
                    removeByRegExPattern = Nothing

            End Select

            Dim blocks As IEnumerable(Of String) = GetBlocks(text)
            If blocks.Count < 1 Then
                Return text
            End If

            Dim distinctedBlocks As IEnumerable(Of String) =
                From match As String In blocks
                Group By removeByRegExPattern.Match(match).Value
                Into Group
                Select Group.First

            Return String.Join(Environment.NewLine & Environment.NewLine, distinctedBlocks)

        End Function

#End Region

    End Class

#End Region

End Namespace