Imports System

Namespace DragAndDropRows
	Public Class Person
'INSTANT VB NOTE: The variable firstName was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private firstName_Renamed As String
'INSTANT VB NOTE: The variable lastName was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private lastName_Renamed As String
'INSTANT VB NOTE: The variable country was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private country_Renamed As String

		Public Sub New()
		End Sub
		Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal country As String)
			Me.firstName_Renamed = firstName
			Me.lastName_Renamed = lastName
			Me.country_Renamed = country
		End Sub
		Public Property FirstName() As String
			Get
				Return firstName_Renamed
			End Get
			Set(ByVal value As String)
				firstName_Renamed = value
			End Set
		End Property

		Public Property LastName() As String
			Get
				Return lastName_Renamed
			End Get
			Set(ByVal value As String)
				lastName_Renamed = value
			End Set
		End Property

		Public Property Country() As String
			Get
				Return country_Renamed
			End Get
			Set(ByVal value As String)
				country_Renamed = value
			End Set
		End Property

	End Class

	Public Class PersonEx
		Inherits Person

'INSTANT VB NOTE: The variable id was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private id_Renamed As Integer
'INSTANT VB NOTE: The variable parentID was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private parentID_Renamed As Integer
		Private Shared counter As Integer = 1
		Public Sub New()
		End Sub
		Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal country As String, ByVal parentID As Integer)
			MyBase.New(firstName, lastName, country)
			Me.parentID_Renamed = parentID
			id_Renamed = counter
			counter += 1
		End Sub

		Public Sub New(ByVal person As Person, ByVal parentID As Integer)
			Me.New(person.FirstName, person.LastName, person.Country, parentID)
		End Sub

		Public Property ID() As Integer
			Get
				Return id_Renamed
			End Get
			Set(ByVal value As Integer)
				id_Renamed = value
			End Set
		End Property
		Public Property ParentID() As Integer
			Get
				Return parentID_Renamed
			End Get
			Set(ByVal value As Integer)
				parentID_Renamed = value
			End Set
		End Property
		Public Function ToArray() As Object()
			Return New Object() {ID, ParentID, FirstName, LastName, Country }
		End Function
	End Class
End Namespace