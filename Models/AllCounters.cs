using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Counter.Views;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Counter.Models
{
	internal class AllCounters : ContentPage
	{
        public static string filePath = @"C:\Users\Alan Szymczyk\source\repos\Counter\Resources\Raw\CounterStorage.xml";
		public ObservableCollection<Counter> Counters { get; set; } = new();

		public AllCounters() =>
			LoadCounters();


		public async void LoadCounters()
		{
			if (Counters.Count != 0)
				Counters.Clear();

			XDocument doc = XDocument.Load(filePath);
			Counter counter = new Counter();

			foreach(var node in doc.Descendants())
			{
				switch(node.Name.ToString())
				{
					case "CounterName":
						counter.CounterName = node.Value;
						break;
					case "CounterValue":
						counter.CounterValue = int.Parse(node.Value);
						break;
					case "CounterColor":
						counter.CounterColor = node.Value;
						break;
					case "CounterDefaultValue":
						counter.CounterDefaultValue = int.Parse(node.Value);
						break;
					default:
						break;
				}
				if(counter.CounterDefaultValue != null)
                {
					Counters.Add(counter);
					counter = new Counter();
                }
			}

			/*using (FileStream fs = new(filePath, FileMode.Open))
			{
				XmlSerializer serializer = new(typeof(Counter));
				Counters = serializer.Deserialize(fs) as ObservableCollection<Counter>;
            }*/
        }

	}
}
