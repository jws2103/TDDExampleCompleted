using System.Diagnostics.CodeAnalysis;
using FreshMvvm;

namespace TDDExample
{
    [ExcludeFromCodeCoverage]
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            Initialise();
            MainPage = FreshPageModelResolver.ResolvePageModel<MyAccountPageModel>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void Initialise()
        {
            // Add IOC stuffs
            FreshIOC.Container.Register<IBankAccountService, BankAccountService>();
            FreshIOC.Container.Register<ILogger, Logger>();
        }
    }
}
