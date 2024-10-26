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

		var counter = new Models.Counter()
		{
			CounterName = CounterNameEditor.Text,
			CounterDefaultValue = int.Parse(CounterDefaultEditor.Text),
			CounterColor = ColorPicker.SelectedItem.ToString(),
			CounterValue = int.Parse(CounterDefaultEditor.Text),
		};

		var count = new XElement("Counter", [
			new XElement("CounterName", counter.CounterName),
			new XElement("CounterValue", counter.CounterValue),
			new XElement("CounterColor", counter.CounterColor),
			new XElement("CounterDefaultValue", counter.CounterDefaultValue),
		]);

		doc.Element("Counters").Add(count);
		doc.Save(Models.AllCounters.filePath);	
		await Shell.Current.GoToAsync("..");
	}
}