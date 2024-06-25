<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128637525/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T202760)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Drag-and-Drop Grid Rows to the TreeList

This example demonstrates how to attach the [Drag And Drop Behavior](https://documentation.devexpress.com/WindowsForms/118656/Common-Features/Behaviors/Drag-And-Drop-Behavior) to the TreeList and Grid controls to allow users to move rows from the Grid to the TreeList with the mouse.

In this example:

* The `InitDragDrop()` method creates the Behavior Manager and attaches the Drag and Drop Behavior to the TreeList and GridView:

  ```csharp
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
  ```
* The bahavior's `DragOver` and `DragDrop` events are handled to customize drag-and-drop operations.

> **Note**
>
> A drag-and-drop operation is initiated when a user clicks a row. If there is a cell editor beneath the mouse pointer, it intercepts mouse events and cancels the drag-and-drop operation. To prevent this, the GridView's [EditorShowMode](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Base.ColumnViewOptionsBehavior.EditorShowMode) property is set to `Click`.
>
> ```csharp
> gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
> ```


## Files to Review

* [Form1.cs](./CS/DragAndDropRows/Form1.cs) (VB: [Form1.vb](./VB/DragAndDropRows/Form1.vb))
* [Person.cs](./CS/DragAndDropRows/Person.cs) (VB: [Person.vb](./VB/DragAndDropRows/Person.vb))


## Documentation

* [Drag-and-Drop Behavior](https://docs.devexpress.com/WindowsForms/118656/common-features/behaviors/drag-and-drop-behavior)


## See Also

* [Drag and Drop Appointments from the Grid Control to Scheduler](https://github.com/DevExpress-Examples/how-to-drag-appointments-from-gridview-and-drop-them-onto-the-scheduler-control-using-sche-t179722)
* [DevExpress WinForms Cheat Sheet - Drag-and-Drop Within/Between Controls](https://go.devexpress.com/CheatSheets_WinForms_Examples_T949086.aspx)
* [DevExpress WinForms Troubleshooting - Grid Control](https://go.devexpress.com/CheatSheets_WinForms_Examples_T934742.aspx)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=drag-drop-grid-rows-to-treelist&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=drag-drop-grid-rows-to-treelist&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
