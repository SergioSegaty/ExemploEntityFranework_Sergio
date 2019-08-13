using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        int Inserir(Categoria categoria);

        bool Alterar(Categoria categoria);

        List<Categoria> ObterTodos(int quantidade, int pagina, string busca, string colunaOrdem, string ordem);

        Categoria ObterPeloId(int id);

        bool Apagar(int id);

        List<Categoria> ObterTodosSelect2(string pesquisa);
    }
}