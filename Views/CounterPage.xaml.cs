using System.Xml;
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
		var counter = new Models.Counter()
		{
			CounterName = CounterNameEditor.Text,
			CounterDefaultValue = int.Parse(CounterDefaultEditor.Text),
			CounterColor = ColorPicker.SelectedItem.ToString(),
			CounterValue = int.Parse(CounterDefaultEditor.Text),
		};
        using (FileStream fs = new FileStream(Models.AllCounters.filePath, FileMode.OpenOrCreate))
        {
            XmlSerializer serializer = new (typeof(Models.Counter));
            serializer.Serialize(fs, counter);
        }
		await Shell.Current.GoToAsync("..");
	}
}