using ListaTelefonica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTelefonica.presenters
{
    public class ContatoPresenter
    {
        private Contexto db;
        public ContatoPresenter()
        {
            db = new Contexto();
            db.Database.EnsureCreated();
        }
        public bool AdicionarContato(Contato novo)
        {
            db.contatos.Add(novo);
            return db.SaveChanges() > 0;
        }
    }
}
