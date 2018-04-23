# How to: Drag-and-Drop GridControl Rows to the TreeList


<p>This example demonstrates how to drag-and-drop rows from the Grid Control to the Tree List control. To support drag-and-drop operations within the GridView, set the <strong>ColumnViewOptionsBehavior.EditorShowMode</strong> property to either <strong>MouseUp</strong> or <strong>Click</strong>. This prevents a cell editor from being opened on the <strong>MouseDown</strong> event, as this event is used for initialization of drag-and drop operations. To allow the Tree List to accept data dropped onto it, set its <strong>AllowDrop</strong> property to <strong>true</strong>. <br>The <strong>TreeList.GetDXDragEventArgs</strong> method is used to convert drag event arguments to the <strong>DXDragEventArgs</strong> type. This allows you to get extended drag-and-drop parameters. The following parameters are used in this example

* <strong>DXDragEventArgsDrag.TagetNode</strong> - the target node over which the row is dropped;<br>- <strong>DXDragEventArgsDrag.DragInsertPosition</strong> - specifies how a node is inserted (as a child, before or after a node, or at the end of the node collection).<br>The TreeList is bound to a <strong>BindingList</strong> data source. Nodes are added using the <strong>AppendNode</strong> method overload, which takes an array of column values as a parameter. The order of values in this array should match the order of the public properties in the data source.<br><br></p>

<br/>


