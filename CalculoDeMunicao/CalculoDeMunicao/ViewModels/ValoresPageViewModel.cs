using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculoDeMunicao.ViewModels
{
    public class ValoresPageViewModel : ViewModelBase
    {
        public ValoresPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Quantidade e Valores";
        }
    }
}
