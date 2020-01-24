using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculadoraDeMunicao.ViewModels
{
    public class DefinicoesPageViewModel : ViewModelBase
    {
        public DefinicoesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Definições";
        }
    }
}
