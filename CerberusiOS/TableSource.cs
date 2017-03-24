﻿using System;
using Cerberus;
using Foundation;
using UIKit;

public class TableSource : UITableViewSource
{

	protected string[] tableItems;
	protected string cellIdentifier = "TableCell";
	InboxViewController owner;

	public delegate void NewPageHandler(object sender, EventArgs e);
	public event NewPageHandler NewPageEvent;

	public TableSource(string[] items, InboxViewController owner)
	{
		tableItems = items;
		this.owner = owner;
	}

	/// <summary>
	/// Called by the TableView to determine how many cells to create for that particular section.
	/// </summary>
	public override nint RowsInSection(UITableView tableview, nint section)
	{
		return tableItems.Length;
	}

	/// <summary>
	/// Called when a row is touched
	/// </summary>
	public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
	{
		
		UIAlertController okAlertController = UIAlertController.Create("Message", tableItems[indexPath.Row], UIAlertControllerStyle.Alert);
		okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
		owner.PresentViewController(okAlertController, true, null);

		tableView.DeselectRow(indexPath, true);

		//NewPageEvent(this, new EventArgs());
		//var messageView = Storyboard.InstantiateViewController("messageView") as ViewMessageController;
		//NavigationController.PushViewController(messageView, true);

	}

	/// <summary>
	/// Called by the TableView to get the actual UITableViewCell to render for the particular row
	/// </summary>
	public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
	{
		// request a recycled cell to save memory
		UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
		// if there are no cells to reuse, create a new one
		if (cell == null)
			cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

		cell.TextLabel.Text = tableItems[indexPath.Row];

		return cell;
	}
}
