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
		var doc = new XDocument();
		var counter = new Models.Counter()
		{
			CounterName = CounterNameEditor.Text,
			CounterDefaultValue = int.Parse(CounterDefaultEditor.Text),
			CounterColor = ColorPicker.SelectedItem.ToString(),
			CounterValue = int.Parse(CounterDefaultEditor.Text),
		};
		/*using (FileStream fs = new FileStream(Models.AllCounters.filePath, FileMode.OpenOrCreate))
        {
            XmlSerializer serializer = new (typeof(Models.Counter));
            serializer.Serialize(fs, counter);
        }*/
		var count = new XElement("Counter", [
			new XElement("CounterName", counter.CounterName),
			new XElement("CounterValue", counter.CounterValue),
			new XElement("CounterColor", counter.CounterColor),
			new XElement("CounterDefaultValue", counter.CounterDefaultValue)
		]);

		doc = XDocument.Load(Models.AllCounters.filePath);
		doc.Element("Counters").Add(count);
		doc.Save(Models.AllCounters.filePath);	
		await Shell.Current.GoToAsync("..");
	}
}