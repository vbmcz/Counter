using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Counter.Views;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

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
			Counters.Clear();

			using (FileStream fs = new(filePath, FileMode.Open))
			{
				XmlSerializer serializer = new(typeof(Counter));
				Counters = serializer.Deserialize(fs) as ObservableCollection<Counter>;
            }
        }

	}
}
