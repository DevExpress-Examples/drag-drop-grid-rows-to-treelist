Imports System

Namespace DragAndDropRows

    Public Class Person

        Private firstNameField As String

        Private lastNameField As String

        Private countryField As String

        Public Sub New()
        End Sub

        Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal country As String)
            firstNameField = firstName
            lastNameField = lastName
            countryField = country
        End Sub

        Public Property FirstName As String
            Get
                Return firstNameField
            End Get

            Set(ByVal value As String)
                firstNameField = value
            End Set
        End Property

        Public Property LastName As String
            Get
                Return lastNameField
            End Get

            Set(ByVal value As String)
                lastNameField = value
            End Set
        End Property

        Public Property Country As String
            Get
                Return countryField
            End Get

            Set(ByVal value As String)
                countryField = value
            End Set
        End Property
    End Class

    Public Class PersonEx
        Inherits Person

        Private idField As Integer

        Private parentIDField As Integer

        Private Shared counter As Integer = 1

        Public Sub New()
        End Sub

        Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal country As String, ByVal parentID As Integer)
            MyBase.New(firstName, lastName, country)
            parentIDField = parentID
            idField = Math.Min(Threading.Interlocked.Increment(counter), counter - 1)
        End Sub

        Public Sub New(ByVal person As Person, ByVal parentID As Integer)
            Me.New(person.FirstName, person.LastName, person.Country, parentID)
        End Sub

        Public Property ID As Integer
            Get
                Return idField
            End Get

            Set(ByVal value As Integer)
                idField = value
            End Set
        End Property

        Public Property ParentID As Integer
            Get
                Return parentIDField
            End Get

            Set(ByVal value As Integer)
                parentIDField = value
            End Set
        End Property

        Public Function ToArray() As Object()
            Return New Object() {ID, ParentID, FirstName, LastName, Country}
        End Function
    End Class
End Namespace
