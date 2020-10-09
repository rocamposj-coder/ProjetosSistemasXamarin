using PrimeiroXamarin.Entidades;
using PrimeiroXamarin.Servicos;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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


        public ListarTodosAlunosViewModel(INavigationService navigationService,
            IServicos iServicos)
            : base(navigationService)
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


    }
}
