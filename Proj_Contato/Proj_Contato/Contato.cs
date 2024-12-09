using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_Contato
{

    public class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Data DtNasc { get; set; }
        public List<Telefone> Telefones { get; set; }

        public Contato(string nome, string email, Data dtNasc)
        {
            Nome = nome;
            Email = email;
            DtNasc = dtNasc;
            Telefones = new List<Telefone>();
        }

        public void AdicionarTelefone(Telefone t)
        {
            Telefones.Add(t);
        }

        public string GetTelefonePrincipal()
        {
            var telefonePrincipal = Telefones.FirstOrDefault(t => t.Principal);
            return telefonePrincipal?.Numero ?? "Nenhum telefone principal";
        }

        public override string ToString()
        {
            var telefonePrincipal = GetTelefonePrincipal();
            return $"Nome: {Nome}, Email: {Email}, Nascimento: {DtNasc}, Telefone Principal: {telefonePrincipal}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Contato contato)
            {
                return this.Email == contato.Email; 
            }
            return false;
        }

        public int GetIdade()
        {
            var idade = DateTime.Now.Year - DtNasc.Ano;
            if (DateTime.Now.Month < DtNasc.Mes || (DateTime.Now.Month == DtNasc.Mes && DateTime.Now.Day < DtNasc.Dia))
            {
                idade--;
            }
            return idade;
        }
    }

}
