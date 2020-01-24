using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculadoraDeMunicao.ViewModels
{
    public class TabbedMenuViewModel : ViewModelBase
    {
        public TabbedMenuViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }
    }
}
