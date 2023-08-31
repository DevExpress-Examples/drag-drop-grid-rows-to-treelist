Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraGrid
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors

Namespace DragAndDropRows

    Public Partial Class Form1
        Inherits XtraForm

        Private hitInfo As GridHitInfo = Nothing

        Private gridDataSource As BindingList(Of Person) = New BindingList(Of Person)()

        Public Sub New()
            InitializeComponent()
            InitGrid()
            InitTreeList()
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
            ' Allow the control to accept data dropped onto it.
            treeList.AllowDrop = True
            ' Allow tree indents to be interpreted as parts of rows. 
            ' The TargetNode parameter of the TreeList.DragDrop event will return a proper node, when dropping over tree indents. 
            treeList.OptionsView.ShowIndentAsRowStyle = True
        End Sub

        Private Sub gridControl_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            hitInfo = gridView.CalcHitInfo(New Point(e.X, e.Y))
        End Sub

        ' Initialize a drag-and-drop operation.
        Private Sub gridControl_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            If hitInfo Is Nothing Then Return
            If e.Button <> MouseButtons.Left Then Return
            Dim dragRect As Rectangle = New Rectangle(New Point(hitInfo.HitPoint.X - SystemInformation.DragSize.Width \ 2, hitInfo.HitPoint.Y - SystemInformation.DragSize.Height \ 2), SystemInformation.DragSize)
            If Not hitInfo.RowHandle = GridControl.InvalidRowHandle AndAlso Not dragRect.Contains(New Point(e.X, e.Y)) Then
                Dim data As Object = gridView.GetRow(hitInfo.RowHandle)
                gridControl.DoDragDrop(data, DragDropEffects.Copy)
            End If
        End Sub

        Private Sub treeList_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
            e.Effect = DragDropEffects.Copy
        End Sub

        ' Add a node to the TreeList when a grid row is dropped.
        Private Sub treeList_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
            ' Get extended arguments of the drag event.
            Dim args As DXDragEventArgs = treeList.GetDXDragEventArgs(e)
            ' Get how a node is inserted (as a child, before or after a node, or at the end of the node collection).
            Dim position As DragInsertPosition = args.DragInsertPosition
            Dim dataRow As Person = TryCast(e.Data.GetData(GetType(Person)), Person)
            If dataRow Is Nothing Then Return
            Dim parentID As Integer = CInt(treeList.RootValue)
            ' Get the node over which the row is dropped.
            Dim node As TreeListNode = args.TargetNode
            ' Add a node at the root level.
            If node Is Nothing Then
                treeList.AppendNode((New PersonEx(CType(dataRow, Person), CInt(parentID))).ToArray(), Nothing)
            Else
                ' Add a child node to the target node.
                If position = DragInsertPosition.AsChild Then
                    parentID = Convert.ToInt32(node.GetValue("ID"))
                    Dim targetObject As Object() =(New PersonEx(dataRow, parentID)).ToArray()
                    treeList.AppendNode(targetObject, node)
                End If

                ' Insert a node before the taget node.
                If position = DragInsertPosition.Before Then
                    parentID = Convert.ToInt32(node.GetValue("ParentID"))
                    Dim targetObject As Object() =(New PersonEx(dataRow, parentID)).ToArray()
                    Dim newNode As TreeListNode = treeList.AppendNode(targetObject, node.ParentNode)
                    Dim targetPosition As Integer
                    If node.ParentNode Is Nothing Then
                        targetPosition = treeList.Nodes.IndexOf(node)
                    Else
                        targetPosition = node.ParentNode.Nodes.IndexOf(node)
                    End If

                    treeList.SetNodeIndex(newNode, targetPosition)
                End If

                node.Expanded = True
            End If
        End Sub

        Private Sub treeList_DragOver(ByVal sender As Object, ByVal e As DragEventArgs)
            e.Effect = DragDropEffects.Copy
        End Sub
    End Class
End Namespace
