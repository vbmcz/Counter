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

	private void Increment(object sender, EventArgs e)
	{
		var btn = (Button)sender;

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
					if(int.Parse(node.Value) + 1 > int.MaxValue)
					{
						node.Value = "0";
						doc.Save(Models.AllCounters.filePath);
						break;
					}
					int temp = int.Parse(node.Value) + 1;
					node.Value = temp.ToString();
					doc.Save(Models.AllCounters.filePath);
					break;
				}
			}
		}
		((Models.AllCounters)BindingContext).LoadCounters();
	}

	private void Decrement(object sender, EventArgs e)
	{
		var btn = (Button)sender;

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
					if(int.Parse(node.Value) - 1 < int.MinValue)
					{
						node.Value = "0";
						doc.Save(Models.AllCounters.filePath);
						break;
					}
					int temp = int.Parse(node.Value) - 1;
					node.Value = temp.ToString();
					doc.Save(Models.AllCounters.filePath);
					break;
				}
			}
		}
		((Models.AllCounters)BindingContext).LoadCounters();
	}

	private void Reset(object sender, EventArgs e)
	{
		var btn = (Button)sender;

		var doc = XDocument.Load(Models.AllCounters.filePath);

		bool found = false;
		int temp = 0;

		foreach (var node in doc.Descendants())
		{
			if (node.Value.ToString() == btn.ClassId)
			{
				found = true;
				continue;
			}
			if (found)
			{
				if (node.Name == "CounterDefaultValue")
				{
					temp = int.Parse(node.Value);
					continue;
				}
				else if(node.Name == "CounterValue")
				{
					node.Value = temp.ToString();
					doc.Save(Models.AllCounters.filePath);
					break;
				}
			}
			
		}
		((Models.AllCounters)BindingContext).LoadCounters();
	}

	private async void Delete(object sender, EventArgs e)
	{
		var btn = (Button)sender;

		var doc = XDocument.Load(Models.AllCounters.filePath);

		bool answer = await DisplayAlert("Delete confirmation", $"Do you want to delete the '{btn.ClassId}' counter?", "Yes", "No");

		if (!answer)
			return;


		foreach (var node in doc.Descendants())
		{
			if (node.Value.ToString() == btn.ClassId)
			{
				node.Parent.Remove();
				doc.Save(Models.AllCounters.filePath);
				break;
			}
		}

		doc.Save(Models.AllCounters.filePath);

		((Models.AllCounters)BindingContext).LoadCounters();
	}
}