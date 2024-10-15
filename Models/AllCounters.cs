using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Counter.Views;

namespace Counter.Models
{
    class AllCounters : Page
    {

        public AllCounters() {
            CreateButton();
        }


        private void CreateButton()
        {
            int counter = 0;

            var layout = new VerticalStackLayout();

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
            layout.Children.Add( label );
            layout.Children.Add( button );

            AllCountersPage allCountersPage = new()
            {
                Content = layout
            };
        }
        
    }
}
