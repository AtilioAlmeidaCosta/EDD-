using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Vendedores
{
    internal class Venda
    {
        public int Qtde { get; set; }
        public double Valor { get; set; }

        public Venda(int qtde, double valor)
        {
            Qtde = qtde;
            Valor = valor;
        }
        public double ValorMedio()
        {
            return Valor / Qtde;
        }
    }
}
