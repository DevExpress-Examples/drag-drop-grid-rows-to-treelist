using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors;


namespace DragAndDropRows {
    public partial class Form1 : XtraForm {

        GridHitInfo hitInfo = null;
        BindingList<Person> gridDataSource = new BindingList<Person>();

        public Form1() {
            InitializeComponent();
            InitGrid();
            InitTreeList();
        }

        void InitGrid() {
            gridDataSource.Add(new Person("John", "Smith", "USA"));
            gridDataSource.Add(new Person("Michael", "Suyama", "UK"));
            gridDataSource.Add(new Person("Laura", "Callahan", "UK"));
            gridDataSource.Add(new Person("Gerard", "Blain", "France"));
            gridDataSource.Add(new Person("Sergio", "Rubini", "Italy"));
            gridDataSource.Add(new Person("Andrew", "Fuller", "USA"));
            gridControl.DataSource = gridDataSource;
            // Enable support for drag-and-drop operations within the View.
            gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
        }

        void InitTreeList() {
            treeList.DataSource = new BindingList<PersonEx>() ;
            // Specify the key field in the data source.
            treeList.KeyFieldName = "ID";
            // Specify the data source field identifying the parent key field.
            treeList.ParentFieldName = "ParentID";
            // Allow the control to accept data dropped onto it.
            treeList.AllowDrop = true;
            // Allow tree indents to be interpreted as parts of rows. 
            // The TargetNode parameter of the TreeList.DragDrop event will return a proper node, when dropping over tree indents. 
            treeList.OptionsView.ShowIndentAsRowStyle = true;
        }
   
        private void gridControl_MouseDown(object sender, MouseEventArgs e) {
            hitInfo = gridView.CalcHitInfo(new Point(e.X, e.Y));
        }

        // Initialize a drag-and-drop operation.
        private void gridControl_MouseMove(object sender, MouseEventArgs e) {
            if (hitInfo == null) return;
            if (e.Button != MouseButtons.Left) return;
            Rectangle dragRect = new Rectangle(new Point(
                hitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
                hitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            if (!(hitInfo.RowHandle == GridControl.InvalidRowHandle) && !dragRect.Contains(new Point(e.X, e.Y))) {
                Object data = gridView.GetRow(hitInfo.RowHandle);
                gridControl.DoDragDrop(data, DragDropEffects.Copy);
            }
            
        }

        private void treeList_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        // Add a node to the TreeList when a grid row is dropped.
        private void treeList_DragDrop(object sender, DragEventArgs e) {
            // Get extended arguments of the drag event.
            DXDragEventArgs args = treeList.GetDXDragEventArgs(e);
            // Get how a node is inserted (as a child, before or after a node, or at the end of the node collection).
            DragInsertPosition position = args.DragInsertPosition;
            Person dataRow = e.Data.GetData(typeof(DragAndDropRows.Person)) as Person;
            if (dataRow == null) return;
            int parentID = (int)treeList.RootValue;
            // Get the node over which the row is dropped.
            TreeListNode node = args.TargetNode;
            // Add a node at the root level.
            if (node == null) {
                treeList.AppendNode((new PersonEx(dataRow, parentID)).ToArray(), null);
            }
            else {
                // Add a child node to the target node.
                if (position == DragInsertPosition.AsChild) {
                    parentID = Convert.ToInt32(node.GetValue("ID"));
                    Object[] targetObject = (new PersonEx(dataRow, parentID)).ToArray(); 
                    treeList.AppendNode(targetObject, node);
                }
                // Insert a node before the taget node.
                if (position == DragInsertPosition.Before) {
                    parentID = Convert.ToInt32(node.GetValue("ParentID"));
                    Object[] targetObject = (new PersonEx(dataRow, parentID)).ToArray();
                    TreeListNode newNode = treeList.AppendNode(targetObject, node.ParentNode);
                    int targetPosition;
                    if (node.ParentNode == null)
                        targetPosition = treeList.Nodes.IndexOf(node);
                    else targetPosition = node.ParentNode.Nodes.IndexOf(node);
                    treeList.SetNodeIndex(newNode, targetPosition);
                }
                node.Expanded = true;
            }
        }

        private void treeList_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

    }
}