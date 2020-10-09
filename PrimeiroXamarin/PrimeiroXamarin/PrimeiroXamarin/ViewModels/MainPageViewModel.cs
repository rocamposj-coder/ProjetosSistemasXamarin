using PrimeiroXamarin.Entidades;
using PrimeiroXamarin.Servicos;
using PrimeiroXamarin.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
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


        public DelegateCommand BotaoListarTodosCommand => new DelegateCommand(async () => await ListarTodosAsync());
        //public DelegateCommand BotaoListarEspecificoCommand => new DelegateCommand(async () => await ListarEspecificoAsync());
        //public DelegateCommand BotaoAtualizarAlunoCommand => new DelegateCommand(async () => await AtualizarAlunoAsync());
        //public DelegateCommand BotaoRemoverAlunoCommand => new DelegateCommand(async () => await RemoverAlunoAsync());
        //public DelegateCommand BotaoInserirAlunoCommand => new DelegateCommand(async () => await ListarTodosAsync());
        

        private async Task ExecuteBotaoOKAsync()
        {
          List<Aluno> listAlunos = _iServicos.ObterTodosAlunos();

            Saida = Entrada;
            NomeBotao = Entrada;
            await NavigationService.NavigateAsync($"{nameof(Page2)}");
        }

        
        private async Task ListarTodosAsync()
        {   
            await NavigationService.NavigateAsync($"{nameof(ListarTodosAlunos)}");
        }



        public MainPageViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService,
            IServicos iServicos)
            : base(navigationService, pageDialogService)
        {
            _iServicos = iServicos;
            Title = "Main Page";
            Saida = "Bem Vindo Indiana Jones";
            NomeBotao = "OK";
        }
    }
}
