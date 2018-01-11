using System;
using UIKit;
using ActionComponents;

namespace iOSActionTable
{
	public partial class ViewController : UIViewController
	{
		#region Private Variables
		private ACTableViewController tableViewController;
		#endregion

		#region Constructors
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
		#endregion

		#region Override Methods
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Create a new table view controller
			tableViewController = new ACTableViewController(UITableViewStyle.Grouped, View.Frame);
			View.AddSubview(tableViewController.TableView);
			tableViewController.cellSelectionStyle = UITableViewCellSelectionStyle.None;

			// Wireup data request event
			tableViewController.dataSource.RequestData += (dataSource) => {
				// Add simple items
				var components = dataSource.AddSection("Action Components");

				components.AddItem("Action Alerts", "For iOS and Android", true);
				components.AddItem("Action Table", "For iOS and Android", true);
				components.AddItem("Action Toast", "For iOS", true);
				components.AddItem("Action Tray", "For iOS and Android", true);
				components.AddItem("Action View", "For iOS and Android", true);
				components.AddItem("Action Download Manager", "For iOS and Android", true);
				components.AddItem("Action Nav Bar", "For iOS and Android", true);

				// Add accessories
				var accessories = dataSource.AddSection("Accessories");

				accessories.AddItem("Switch", false).AddAccessorySwitch(false,(on) => {
					// Display switch state
					ACToast.ShowText($"Switch State: {on}");	
				});

				accessories.AddItem("Stepper {0}", false).AddAccessoryStepper(1, 10, 1, 1,(value) => {
					// Display step value
					ACToast.ShowText($"Stepper Value: {value}");
				});

				accessories.AddItem("Slider {0:0}", false).AddAccessorySlider(1, 100, 50, (value) => {
					// Display slider value
					ACToast.ShowText($"Slider Value: {value}");
				});

				accessories.AddItem("Button", false).AddAccessoryButton(UIButtonType.RoundedRect, 100, "OK", () => {
					// Display results
					ACToast.ShowText("Button Pressed");
				});

				accessories.AddItem("Text", false).AddAccessoryTextField(250, "<enter text>", "", (text) => {
					// Display value
					ACToast.ShowText($"Text Value: {text}");
				});
			};

			// Wireup item selection
			tableViewController.ItemsSelected += (item) => {
				// Display selected item
				ACToast.ShowText($"Item Selected {item.text}");

			};

			// Ask table to load data
			tableViewController.LoadData();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
		#endregion
	}
}
