using Android.App;
using Android.Widget;
using Android.OS;
using ActionComponents;

namespace AndroidActionTable
{
	[Activity(Label = "AndroidActionTable", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private ACTableViewController documentList;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Access interface items
			documentList = FindViewById<ACTableViewController>(Resource.Id.documentList);

			// Configure table
			documentList.activity = this;
			documentList.allowsSelection = true;

			// Wireup data request
			documentList.dataSource.RequestData += (dataSource) => {
				// Populate table with data
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

				accessories.AddItem("Switch", false).AddAccessorySwitch(false, (on) => {
					// Display switch state
					Toast.MakeText(Application.Context, $"Switch State: {on}", ToastLength.Short).Show();
				});

				accessories.AddItem("Stepper {0}", false).AddAccessoryStepper(1, 10, 1, 1, (value) => {
					// Display step value
					Toast.MakeText(Application.Context, $"Stepper Value: {value}", ToastLength.Short).Show();
				});

				accessories.AddItem("Slider {0:0}", false).AddAccessorySlider(1, 100, 50, (value) => {
					// Display slider value
					Toast.MakeText(Application.Context, $"Slider Value: {value}", ToastLength.Short).Show();
				});

				accessories.AddItem("Button", false).AddAccessoryButton(100, "OK", () => {
					// Display results
					Toast.MakeText(Application.Context, $"Button Pressed", ToastLength.Short).Show();

				});

				accessories.AddItem("Text", false).AddAccessoryTextField(250, "<enter text>", "", (text) => {
					// Display value
					Toast.MakeText(Application.Context, $"Text Value: {text}", ToastLength.Short).Show();
				});

			};

			// Ask the controller to populate the table
			documentList.LoadData();

			// Wireup touch handler
			documentList.ItemsSelected += (item) => {
				Toast.MakeText(Application.Context, $"Item Selected: {item.text}", ToastLength.Short).Show();
			};
		}
	}
}

