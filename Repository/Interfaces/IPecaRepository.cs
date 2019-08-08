using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IPecaRepository
    {

        int Inserir(Peca peca);

        bool Alterar(Peca peca);

        List<Peca> ObterTodos();

        Peca ObterPeloId(int id);

        bool Apagar(int id);
    }
}