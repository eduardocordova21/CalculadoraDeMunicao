using Prism;
using Prism.Ioc;
using CalculadoraDeMunicao.ViewModels;
using CalculadoraDeMunicao.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CalculadoraDeMunicao
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("TabbedMenu");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TabbedMenu, TabbedMenuViewModel>();
            containerRegistry.RegisterForNavigation<CalculadoraPage, CalculadoraViewModel>();
            containerRegistry.RegisterForNavigation<DefinicoesPage, DefinicoesPageViewModel>();
        }
    }
}
