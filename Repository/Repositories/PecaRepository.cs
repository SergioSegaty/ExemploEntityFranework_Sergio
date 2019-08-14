using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class PecaRepository : IPecaRepository
    {

        public SistemContext context;

        public PecaRepository(SistemContext context)
        {
            this.context = context;
        }

        public bool Alterar(Peca peca)
        {
            peca.RegistroAtivo = true;
            context.Pecas.Update(peca);
            return context.SaveChanges() == 1;
             
        }

        public bool Apagar(int id)
        {
            var peca = context.Pecas.FirstOrDefault(x => x.Id == id);
            peca.RegistroAtivo = false;
            return context.SaveChanges() == 1;
        }

        public int Inserir(Peca peca)
        {
            peca.RegistroAtivo = true;
            context.Pecas.Add(peca);
            context.SaveChanges();
            return peca.Id;
        }

        public Peca ObterPeloId(int id)
        {
            return context.Pecas.FirstOrDefault(x => x.Id == id && x.RegistroAtivo);
        }

        public List<Peca> ObterTodos()
        {
            return context.Pecas.Where(x => x.RegistroAtivo).ToList();
        }
    }
}
