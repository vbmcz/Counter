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
}