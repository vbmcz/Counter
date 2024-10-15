using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Counter.Views;

namespace Counter.Models
{
    class AllCounters : ContentPage
    {

        public AllCounters()
        {
            this.CreateButton();
        }


        private void CreateButton()
        {
			int counter = 0;

			Label label = new Label
			{
				Text = $"Counter: {counter}",
			};

			Button button = new Button
			{
				Text = "OK",
				Command = new Command(
					execute: () =>
					{
						counter += 1;
						label.Text = $"Counter: {counter}";
					}
				)
			};

			Label lblName = new Label
			{
				Text = "AA",
			};

			BatchBegin();

            Content = lblName;

			BatchCommit();
		
        }
        
    }
}
