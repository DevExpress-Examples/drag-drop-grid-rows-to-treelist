Imports System

Namespace DragAndDropRows
	Public Class Person
		Private _firstName As String
		Private _lastName As String
		Private _country As String

		Public Sub New()
		End Sub
		Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal country As String)
			Me._firstName = firstName
			Me._lastName = lastName
			Me._country = country
		End Sub
		Public Property FirstName() As String
			Get
				Return _firstName
			End Get
			Set(ByVal value As String)
				_firstName = value
			End Set
		End Property

		Public Property LastName() As String
			Get
				Return _lastName
			End Get
			Set(ByVal value As String)
				_lastName = value
			End Set
		End Property

		Public Property Country() As String
			Get
				Return _country
			End Get
			Set(ByVal value As String)
				_country = value
			End Set
		End Property

	End Class

	Public Class PersonEx
		Inherits Person
		Private _id As Integer
		Private _parentID As Integer
		Private Shared counter As Integer = 1
		Public Sub New()
		End Sub
		Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal country As String, ByVal parentID As Integer)
			MyBase.New(firstName, lastName, country)
			Me._parentID = parentID
			_id = counter
			counter += 1
		End Sub

		Public Sub New(ByVal person As Person, ByVal parentID As Integer)
			Me.New(person.FirstName, person.LastName, person.Country, parentID)
		End Sub

		Public Property ID() As Integer
			Get
				Return _id
			End Get
			Set(ByVal value As Integer)
				_id = value
			End Set
		End Property
		Public Property ParentID() As Integer
			Get
				Return _parentID
			End Get
			Set(ByVal value As Integer)
				_parentID = value
			End Set
		End Property
		Public Function ToArray() As Object()
			Return New Object() {ID, ParentID, FirstName, LastName, Country }
		End Function
	End Class
End Namespace