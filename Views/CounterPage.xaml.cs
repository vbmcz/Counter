using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Counter.Views;

public partial class CounterPage : ContentPage
{
	public CounterPage()
	{
		InitializeComponent();
	}

	public async void Add_Clicked(object sender, EventArgs e)
	{
		var doc = XDocument.Load(Models.AllCounters.filePath);

		foreach(var node in doc.Descendants())
		{
			if(node.Name.ToString() == "CounterName" && node.Value == CounterNameEditor.Text)
			{
				ErrorLabel.Text = "Counter name already in use!";
				return;
			}
		}

		if(CounterNameEditor.Text == null)
		{
			ErrorLabel.Text = "Set name of the counter!";
			return;
		}

		if(CounterDefaultEditor.Text == null)
		{
			ErrorLabel.Text = "Invalid counter default value!";
			return;
		}

		int? temp = null;
		try
		{
			temp = int.Parse(CounterDefaultEditor.Text);
		} catch (Exception) {
			ErrorLabel.Text = "Invalid default counter value!";
			return;
		}

		if(ColorPicker.SelectedItem == null)
		{
			ErrorLabel.Text = "Select color of the counter!";
			return;
		}

		var counter = new Models.Counter()
		{
			CounterName = CounterNameEditor.Text,
			CounterDefaultValue = temp,
			CounterColor = ColorPicker.SelectedItem.ToString(),
			CounterValue = (int)temp,
		};

		var count = new XElement("Counter", [
			new XElement("CounterName", counter.CounterName),
			new XElement("CounterDefaultValue", counter.CounterDefaultValue),
			new XElement("CounterValue", counter.CounterValue),
			new XElement("CounterColor", counter.CounterColor),
		]);

		doc.Element("Counters").Add(count);
		doc.Save(Models.AllCounters.filePath);	
		await Shell.Current.GoToAsync("..");
	}
}