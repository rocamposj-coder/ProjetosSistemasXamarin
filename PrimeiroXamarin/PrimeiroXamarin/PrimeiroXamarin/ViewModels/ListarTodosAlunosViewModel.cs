using PrimeiroXamarin.Entidades;
using PrimeiroXamarin.Servicos;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiroXamarin.ViewModels
{
    public class ListarTodosAlunosViewModel : ViewModelBase
    {
        #region Props

        protected IServicos _iServicos;

        private ObservableCollection<Aluno> _listaAlunos;
        public ObservableCollection<Aluno> ListaAlunos
        {
            get { return _listaAlunos; }
            set { SetProperty(ref _listaAlunos, value); }
        }

        #endregion


        #region commands
        
            public DelegateCommand<Aluno> ExcluirAlunoCommand => new DelegateCommand<Aluno>(async (aluno) => await ExcluirAlunoAsync(aluno));
           
           

        #endregion

        public ListarTodosAlunosViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService,
            IServicos iServicos)
            : base(navigationService, pageDialogService)
        {
            _iServicos = iServicos;
            Title = "Listar todos alunos";
            _listaAlunos = new ObservableCollection<Aluno>();
        }

        //Sempre que navega para esta tela
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            List<Aluno> lista = _iServicos.ObterTodosAlunos();
            ListaAlunos.Clear();
            foreach (var item in lista)
            {
                ListaAlunos.Add(item);
            }
        }


        private async Task ExcluirAlunoAsync(Aluno aluno)
        {
            bool resposta = await PageDialogService.DisplayAlertAsync("Primeiro Xamarin", "Deseja realmente excluir " + aluno.Nome, "Sim", "Não");
            if(resposta)
            {
                bool resultado = _iServicos.ExcluirAluno(aluno);
                if (resultado)
                {
                    await PageDialogService.DisplayAlertAsync("Primeiro Xamarin", "Aluno  " + aluno.Nome + " excluido com sucesso !", "OK");
                }
                else
                {
                    await PageDialogService.DisplayAlertAsync("Primeiro Xamarin", "Erro ao exclurr o aluno " + aluno.Nome + "!", "OK");
                }
            }

            List<Aluno> lista = _iServicos.ObterTodosAlunos();
            ListaAlunos.Clear();
            foreach (var item in lista)
            {
                ListaAlunos.Add(item);
            }

        }
           


    }
}
