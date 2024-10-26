using System.Xml.Linq;

namespace Counter.Views;

public partial class AllCountersPage : ContentPage
{
	public AllCountersPage()
	{
		InitializeComponent();
		BindingContext =  new Models.AllCounters();
	}

    protected override void OnAppearing()
    {
        ((Models.AllCounters)BindingContext).LoadCounters();
    }

    private async void Add_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(CounterPage));
	}

	private void increment(object sender, EventArgs e)
	{
		var btn = (Button)sender;

		((Models.AllCounters)BindingContext).Counters.ElementAt(0).CounterValue += 1;

		var doc = XDocument.Load(Models.AllCounters.filePath);
		bool found = false;

		foreach (var node in doc.Descendants())
		{
			if (node.Value.ToString() == btn.ClassId)
			{
				found = true;
				continue;
			}
			if (found)
			{
				if (node.Name == "CounterValue")
				{
					node.Value = node.Value + 1;
					break;
				}
			}
		}
		((Models.AllCounters)BindingContext).LoadCounters();
		//btn.Text = color;
	}
	
}