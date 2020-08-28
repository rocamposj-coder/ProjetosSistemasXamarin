using BlankApp1.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {


        public DelegateCommand BotaoCommand => new DelegateCommand(async () => await ExecuteBotaoAsync());

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            
        }


        private async Task ExecuteBotaoAsync()
        {
            await NavigationService.NavigateAsync($"{nameof(PrismContentPage1)}");
        }

    }
}
