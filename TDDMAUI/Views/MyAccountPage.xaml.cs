using TDDMAUI.ViewModels;

namespace TDDMAUI.Views;

public partial class MyAccountPage : ContentPage
{
    private MyAccountPageModel _viewModel;
    
    public MyAccountPage(MyAccountPageModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}