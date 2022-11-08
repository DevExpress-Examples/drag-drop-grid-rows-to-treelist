Imports System.ComponentModel
Imports DevExpress.Utils.Behaviors
Imports DevExpress.Utils.DragDrop
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes

Namespace DragAndDropRows
	Partial Public Class Form1
		Inherits XtraForm

		Private gridDataSource As New BindingList(Of Person)()
		Public Sub New()
			InitializeComponent()
			InitGrid()
			InitTreeList()
			InitDragDrop()
		End Sub
		Private Sub InitGrid()
			gridDataSource.Add(New Person("John", "Smith", "USA"))
			gridDataSource.Add(New Person("Michael", "Suyama", "UK"))
			gridDataSource.Add(New Person("Laura", "Callahan", "UK"))
			gridDataSource.Add(New Person("Gerard", "Blain", "France"))
			gridDataSource.Add(New Person("Sergio", "Rubini", "Italy"))
			gridDataSource.Add(New Person("Andrew", "Fuller", "USA"))
			gridControl.DataSource = gridDataSource
			' Enable support for drag-and-drop operations within the View.
			gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
		End Sub

		Private Sub InitTreeList()
			treeList.DataSource = New BindingList(Of PersonEx)()
			' Specify the key field in the data source.
			treeList.KeyFieldName = "ID"
			' Specify the data source field identifying the parent key field.
			treeList.ParentFieldName = "ParentID"
			' Allow tree indents to be interpreted as parts of rows. 
			' The TargetNode parameter of the TreeList.DragDrop event will return a proper node, when dropping over tree indents. 
			treeList.OptionsView.ShowIndentAsRowStyle = True
		End Sub

		Private Sub InitDragDrop()
			Dim behaviorManager1 As New BehaviorManager(Me.components)
			behaviorManager1.Attach(Of DragDropBehavior)(gridView, Sub(behavior)
																	   behavior.Properties.AllowDrop = False
																	   behavior.Properties.InsertIndicatorVisible = True
																	   behavior.Properties.PreviewVisible = True
																   End Sub)

			behaviorManager1.Attach(Of DragDropBehavior)(treeList, Sub(behavior)
																	   behavior.Properties.AllowDrop = True
																	   behavior.Properties.InsertIndicatorVisible = True
																	   behavior.Properties.PreviewVisible = True
																	   AddHandler behavior.DragOver, AddressOf OnDragOver
																	   AddHandler behavior.DragDrop, AddressOf OnDragDrop
																   End Sub)
		End Sub
		Private Overloads Sub OnDragDrop(ByVal sender As Object, ByVal e As DevExpress.Utils.DragDrop.DragDropEventArgs)
			Dim indexes = e.GetData(Of IEnumerable(Of Integer))()
			If indexes Is Nothing Then
				Return
			End If
			Dim destNode = GetDestNode(e.Location)
			Dim destIndex As Integer = CalcDestNodeIndex(e, destNode)
			treeList.BeginUpdate()

			For Each _index As Integer In indexes
				Dim person = gridDataSource(_index)
				Dim parentID As Integer = -1
				If destNode IsNot Nothing Then
					parentID = DirectCast(destNode("ID"), Integer)
				End If
				Dim node As TreeListNode = treeList.AppendNode((New PersonEx(person, parentID)).ToArray(), If(destIndex = -1000, destNode, Nothing))
				If destIndex > -1 Then
					treeList.MoveNode(node, destNode.ParentNode, True, destIndex)
					destIndex += 1
				End If
				If node.ParentNode IsNot Nothing Then
					node.ParentNode.Expand()
				End If
			Next _index
			treeList.EndUpdate()
		End Sub
		Private Function GetDestNode(ByVal hitPoint As Point) As TreeListNode
			Dim pt As Point = treeList.PointToClient(hitPoint)
			Dim ht = treeList.CalcHitInfo(pt)
			Dim destNode As TreeListNode = ht.Node
			If TypeOf destNode Is TreeListAutoFilterNode Then
				Return Nothing
			End If
			Return destNode
		End Function
		Private Function CalcDestNodeIndex(ByVal e As DragDropEventArgs, ByVal destNode As TreeListNode) As Integer
			If destNode Is Nothing Then
				Return -1
			End If
			If e.InsertType = InsertType.AsChild Then
				Return -1000
			End If
			Dim nodes = If(destNode.ParentNode Is Nothing, treeList.Nodes, destNode.ParentNode.Nodes)
			Dim index As Integer = nodes.IndexOf(destNode)
			If e.InsertType = InsertType.After Then
				index += 1
				Return index
			End If
			Return index
		End Function

		Private Overloads Sub OnDragOver(ByVal sender As Object, ByVal e As DevExpress.Utils.DragDrop.DragOverEventArgs)
			e.Default()
			e.Action = DragDropActions.Copy
			e.Handled = True
			e.Cursor = Cursors.Default
		End Sub
	End Class
End Namespace