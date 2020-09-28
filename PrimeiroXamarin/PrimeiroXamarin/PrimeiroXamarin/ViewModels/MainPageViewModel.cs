using PrimeiroXamarin.Entidades;
using PrimeiroXamarin.Servicos;
using PrimeiroXamarin.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroXamarin.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        protected IServicos _iServicos;

        private string _entrada;
        public string Entrada
        {
            get { return _entrada; }
            set { SetProperty(ref _entrada, value); }
        }


        private string _saida;
        public string Saida
        {
            get { return _saida; }
            set { SetProperty(ref _saida, value); }
        }

        
        private string _nomeBotao;
        public string NomeBotao
        {
            get { return _nomeBotao; }
            set { SetProperty(ref _nomeBotao, value); }
        }

        public DelegateCommand BotaoOKCommand => new DelegateCommand(async () => await ExecuteBotaoOKAsync());

        private async Task ExecuteBotaoOKAsync()
        {
          List<Aluno> listAlunos = _iServicos.ObterTodosAlunos();

            Saida = Entrada;
            NomeBotao = Entrada;
            await NavigationService.NavigateAsync($"{nameof(Page2)}");
        }

        public MainPageViewModel(INavigationService navigationService,
            IServicos iServicos)
            : base(navigationService)
        {
            _iServicos = iServicos;
            Title = "Main Page";
            Saida = "Bem Vindo Indiana Jones";
            NomeBotao = "OK";
        }
    }
}
