using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeiroXamarin.ViewModels
{
    public class Page2ViewModel : ViewModelBase
    {
        public Page2ViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            Title = "Page 2";
        }
    }
}
