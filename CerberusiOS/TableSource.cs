using System;
using Cerberus;
using Foundation;
using UIKit;

public class TableSource : UITableViewSource
{

	protected string[] tableItems;
	protected string cellIdentifier = "TableCell";
	UIViewController owner;

	public delegate void NewPageHandler(object sender, EventArgs e);

	public TableSource(string[] items, UIViewController owner)
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
		
		//UIAlertController okAlertController = UIAlertController.Create("Message", tableItems[indexPath.Row], UIAlertControllerStyle.Alert);
		//okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
		//owner.PresentViewController(okAlertController, true, null);

		tableView.DeselectRow(indexPath, true);

		if (this.owner.Title.Equals("InboxView"))
		{
			InboxViewController temp = (Cerberus.InboxViewController)this.owner;
			temp.rowSelected(tableView, indexPath);
		}
		else if (this.owner.Title.Equals("PastEventsView"))
		{
			PastEventsViewController temp = (Cerberus.PastEventsViewController)this.owner;
			temp.rowSelected(tableView, indexPath);
		}
		else if (this.owner.Title.Equals("Upcoming"))
		{
			UpcomingEventsViewController temp = (Cerberus.UpcomingEventsViewController)this.owner;
			temp.rowSelected(tableView, indexPath);
		}
		else if (this.owner.Title.Equals("Accepted"))
		{
			AcceptedEventsViewController temp = (Cerberus.AcceptedEventsViewController)this.owner;
			temp.rowSelected(tableView, indexPath);
		}
		else if (this.owner.Title.Equals("Rejected"))
		{
			RejectedEventsViewController temp = (Cerberus.RejectedEventsViewController)this.owner;
			temp.rowSelected(tableView, indexPath);
		}

	}

	/// <summary>
	/// Called by the TableView to get the actual UITableViewCell to render for the particular row
	/// </summary>
	public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
	{
		// request a recycled cell to save memory
		UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
		//UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);

		// if there are no cells to reuse, create a new one
		if (cell == null)
			cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);

		cell.TextLabel.Text = tableItems[indexPath.Row];

		if (this.owner.Title.Equals("PastEventsView"))
		{
			cell.DetailTextLabel.Text = "12/26/2016";
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
		}
		else if (this.owner.Title.Equals("Upcoming"))
		{
			cell.DetailTextLabel.Text = "04/26/2017";
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
		}
		else if (this.owner.Title.Equals("Accepted"))
		{
			cell.DetailTextLabel.Text = "04/11/2017";
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
		}
		else if (this.owner.Title.Equals("Rejected"))
		{
			cell.DetailTextLabel.Text = "04/05/2017";
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
		}

		return cell;
	}
}
