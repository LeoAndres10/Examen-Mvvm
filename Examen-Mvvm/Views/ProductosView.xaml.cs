using Examen_Mvvm.ViewModels;

namespace Examen_Mvvm.Views;

public partial class ProductosView : ContentPage
{
	private ProductosViewModel viewModel;
	public ProductosView()
	{
		InitializeComponent();
		viewModel = new ProductosViewModel();
		BindingContext=viewModel;
	}
}
