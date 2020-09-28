using PrimeiroXamarin.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeiroXamarin.Servicos
{
    public interface IServicos
    {
        List<Aluno> ObterTodosAlunos();
    }
}
