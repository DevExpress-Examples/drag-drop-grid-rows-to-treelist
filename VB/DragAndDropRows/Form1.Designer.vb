Namespace DragAndDropRows
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.gridControl = New DevExpress.XtraGrid.GridControl()
			Me.gridView = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.treeList = New DevExpress.XtraTreeList.TreeList()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			DirectCast(Me.gridControl, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.gridView, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.treeList, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl
			' 
			Me.gridControl.Dock = System.Windows.Forms.DockStyle.Left
			Me.gridControl.Location = New System.Drawing.Point(0, 0)
			Me.gridControl.MainView = Me.gridView
			Me.gridControl.Name = "gridControl"
			Me.gridControl.Size = New System.Drawing.Size(428, 336)
			Me.gridControl.TabIndex = 0
			Me.gridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView})
			' 
			' gridView
			' 
			Me.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
			Me.gridView.GridControl = Me.gridControl
			Me.gridView.Name = "gridView"
			' 
			' treeList
			' 
			Me.treeList.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeList.Location = New System.Drawing.Point(428, 0)
			Me.treeList.Name = "treeList"
			Me.treeList.Size = New System.Drawing.Size(505, 336)
			Me.treeList.TabIndex = 1
			' 
			' labelControl1
			' 
			Me.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
			Me.labelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.labelControl1.Location = New System.Drawing.Point(0, 336)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(933, 13)
			Me.labelControl1.TabIndex = 2
			Me.labelControl1.Text = "This example demonstrates how to drag-and-drop rows from the GridControl to the T" & "reeList."
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(933, 349)
			Me.Controls.Add(Me.treeList)
			Me.Controls.Add(Me.gridControl)
			Me.Controls.Add(Me.labelControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			DirectCast(Me.gridControl, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.gridView, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.treeList, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region

		Private WithEvents gridControl As DevExpress.XtraGrid.GridControl
		Private gridView As DevExpress.XtraGrid.Views.Grid.GridView
		Private WithEvents treeList As DevExpress.XtraTreeList.TreeList
		Private labelControl1 As DevExpress.XtraEditors.LabelControl
	End Class
End Namespace
