using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_Contato
{
    public class Contatos
    {
        private List<Contato> agenda = new List<Contato>();

        public bool Adicionar(Contato c)
        {
            if (agenda.Exists(contato => contato.Equals(c)))
            {
                return false; 
            }
            agenda.Add(c);
            return true;
        }

        public Contato Pesquisar(Contato c)
        {
            return agenda.FirstOrDefault(contato => contato.Equals(c));
        }

        public bool Alterar(Contato c)
        {
            var contatoExistente = Pesquisar(c);
            if (contatoExistente != null)
            {
                contatoExistente.Nome = c.Nome;
                contatoExistente.Email = c.Email;
                contatoExistente.DtNasc = c.DtNasc;
                contatoExistente.Telefones = c.Telefones;
                return true;
            }
            return false;
        }

        public bool Remover(Contato c)
        {
            return agenda.Remove(c);
        }

        public void Listar()
        {
            foreach (var contato in agenda)
            {
                Console.WriteLine(contato.ToString());
            }
        }
    }

}
