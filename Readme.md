<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128637525/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T202760)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/DragAndDropRows/Form1.cs) (VB: [Form1.vb](./VB/DragAndDropRows/Form1.vb))
* [Person.cs](./CS/DragAndDropRows/Person.cs) (VB: [Person.vb](./VB/DragAndDropRows/Person.vb))
* [Program.cs](./CS/DragAndDropRows/Program.cs) (VB: [Program.vb](./VB/DragAndDropRows/Program.vb))
<!-- default file list end -->
# How to: Drag-and-Drop GridControl Rows to the TreeList

<strong>Starting with version 17.2, you can attach <a href="https://documentation.devexpress.com/WindowsForms/118656/Common-Features/Behaviors/Drag-And-Drop-Behavior">Drag And Drop Behavior</a> to GridControl and TreeList to implement drag-and-drop</strong>



<strong>For earlier versions:</strong>

<p>This example demonstrates how to drag-and-drop rows from the Grid Control to the Tree List control. To support drag-and-drop operations within the GridView, set the <strong>ColumnViewOptionsBehavior.EditorShowMode</strong> property to either <strong>MouseUp</strong> or <strong>Click</strong>. This prevents a cell editor from being opened on the <strong>MouseDown</strong> event, as this event is used for initialization of drag-and drop operations. To allow the Tree List to accept data dropped onto it, set its <strong>AllowDrop</strong> property to <strong>true</strong>. <br>The <strong>TreeList.GetDXDragEventArgs</strong> method is used to convert drag event arguments to the <strong>DXDragEventArgs</strong> type. This allows you to get extended drag-and-drop parameters. The following parameters are used in this example

* <strong>DXDragEventArgsDrag.TargetNode</strong> - the target node over which the row is dropped;<br>- <strong>DXDragEventArgsDrag.DragInsertPosition</strong> - specifies how a node is inserted (as a child, before or after a node, or at the end of the node collection).<br>The TreeList is bound to a <strong>BindingList</strong> data source. Nodes are added using the <strong>AppendNode</strong> method overload, which takes an array of column values as a parameter. The order of values in this array should match the order of the public properties in the data source.<br><br></p>


<b>See also:</b>

[DevExpress WinForms Cheat Sheet - Drag-and-Drop Within/Between Controls](https://go.devexpress.com/CheatSheets_WinForms_Examples_T949086.aspx)

[DevExpress WinForms Troubleshooting - Grid Control](https://go.devexpress.com/CheatSheets_WinForms_Examples_T934742.aspx)

<br/>


