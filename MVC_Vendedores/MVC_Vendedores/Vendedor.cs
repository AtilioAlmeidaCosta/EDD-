using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Vendedores
{
    internal class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double PercComissao { get; set; }
        public Venda[] AsVendas { get; set; } = new Venda[31];

        public Vendedor(int id, string nome, double percComissao)
        {
            Id = id;
            Nome = nome;
            PercComissao = percComissao;
        }

        public void RegistrarVenda(int dia, Venda venda)
        {
            if (dia < 1 || dia > 31)
            {
                Console.WriteLine("Dia inválido. Use um número entre 1 e 31.");
                return;
            }
            AsVendas[dia - 1] = venda;
        }
        public double ValorVendas()
        {
            double total = 0;
            foreach (var venda in AsVendas)
            {
                if (venda != null)
                    total += venda.Valor;
            }
            return total;
        }

        public double ValorComissao()
        {
            return ValorVendas() * PercComissao / 100;
        }

        public double ValorMedioVendas()
        {
            int diasComVenda = 0;
            double totalVendas = 0;
            foreach (var venda in AsVendas)
            {
                if (venda != null)
                {
                    diasComVenda++;
                    totalVendas += venda.Valor;
                }
            }
            return diasComVenda > 0 ? totalVendas / diasComVenda : 0;
        }
    }
}
