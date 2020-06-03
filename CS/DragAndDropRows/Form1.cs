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
using DevExpress.Utils.DragDrop;
using DevExpress.Utils.Behaviors;

namespace DragAndDropRows {
    public partial class Form1 : XtraForm {

        BindingList<Person> gridDataSource = new BindingList<Person>();
        public Form1() {
            InitializeComponent();
            InitGrid();
            InitTreeList();
            InitDragDrop();
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
            // Allow tree indents to be interpreted as parts of rows. 
            // The TargetNode parameter of the TreeList.DragDrop event will return a proper node, when dropping over tree indents. 
            treeList.OptionsView.ShowIndentAsRowStyle = true;
        }

        void InitDragDrop() {
            BehaviorManager behaviorManager1 = new BehaviorManager(this.components);
            behaviorManager1.Attach<DragDropBehavior>(gridView, behavior => {
                behavior.Properties.AllowDrop = false;
                behavior.Properties.InsertIndicatorVisible = true;
                behavior.Properties.PreviewVisible = true;
            });

            behaviorManager1.Attach<DragDropBehavior>(treeList, behavior => {
                behavior.Properties.AllowDrop = true;
                behavior.Properties.InsertIndicatorVisible = true;
                behavior.Properties.PreviewVisible = true;
                behavior.DragOver += OnDragOver;
                behavior.DragDrop += OnDragDrop;
            });
        }
        private void OnDragDrop(object sender, DevExpress.Utils.DragDrop.DragDropEventArgs e) {
            var indexes = e.GetData<IEnumerable<int>>();
            if(indexes == null)
                return;
            var destNode = GetDestNode(e.Location);
            int destIndex = CalcDestNodeIndex(e, destNode);
            treeList.BeginUpdate();

            foreach(int _index in indexes) {
                var person = gridDataSource[_index];
                int parentID = -1;
                if(destNode != null)
                    parentID = (int)destNode["ID"];
                TreeListNode node = treeList.AppendNode(new PersonEx(person, parentID).ToArray(), destIndex == -1000 ? destNode : null);
                if(destIndex > -1) {
                    treeList.MoveNode(node, destNode.ParentNode, true, destIndex);
                    destIndex++;
                }
                if(node.ParentNode != null)
                    node.ParentNode.Expand();
            }
            treeList.EndUpdate();
        }
        TreeListNode GetDestNode(Point hitPoint) {
            Point pt = treeList.PointToClient(hitPoint);
            var ht = treeList.CalcHitInfo(pt);
            TreeListNode destNode = ht.Node;
            if(destNode is TreeListAutoFilterNode)
                return null;
            return destNode;
        }
        int CalcDestNodeIndex(DragDropEventArgs e, TreeListNode destNode) {
            if(destNode == null)
                return -1;
            if(e.InsertType == InsertType.AsChild)
                return -1000;
            var nodes = destNode.ParentNode == null ? treeList.Nodes : destNode.ParentNode.Nodes;
            int index = nodes.IndexOf(destNode);
            if(e.InsertType == InsertType.After)
                return ++index;
            return index;
        }

        private void OnDragOver(object sender, DevExpress.Utils.DragDrop.DragOverEventArgs e) {
            e.Default();
            e.Action = DragDropActions.Copy;
            e.Handled = true;
            e.Cursor = Cursors.Default;
        }
    }
}