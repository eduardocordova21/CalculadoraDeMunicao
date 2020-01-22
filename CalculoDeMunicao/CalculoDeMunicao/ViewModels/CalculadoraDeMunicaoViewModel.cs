using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculoDeMunicao.ViewModels
{
    public class CalculadoraDeMunicaoViewModel : ViewModelBase
    {
        public CalculadoraDeMunicaoViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Calculadora de Munição";
        }
    }
}
