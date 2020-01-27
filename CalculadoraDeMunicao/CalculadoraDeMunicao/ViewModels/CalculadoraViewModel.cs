using Prism.Navigation;

namespace CalculadoraDeMunicao.ViewModels
{
    public class CalculadoraViewModel : ViewModelBase
    {
        public CalculadoraViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Calculadora";
        }
    }
}