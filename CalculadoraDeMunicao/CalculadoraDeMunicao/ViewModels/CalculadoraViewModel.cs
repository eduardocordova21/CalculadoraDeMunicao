using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

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
