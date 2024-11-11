using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Vendedores
{
    internal class Vendedores
    {
        public Vendedor[] OsVendedores { get; set; } = new Vendedor[10];  
        public int Qtde { get; set; } = 0;

        public bool AddVendedor(Vendedor v)
        {
            if (Qtde >= 10) return false;
            OsVendedores[Qtde++] = v;
            return true;
        }

        public bool DelVendedor(int id)
        {
            for (int i = 0; i < Qtde; i++)
            {
                if (OsVendedores[i].Id == id)
                {
                    bool temVendas = OsVendedores[i].ValorVendas() > 0;
                    if (temVendas) return false;

                    for (int j = i; j < Qtde - 1; j++)
                    {
                        OsVendedores[j] = OsVendedores[j + 1];
                    }
                    OsVendedores[Qtde - 1] = null;
                    Qtde--;
                    return true;
                }
            }
            return false;
        }

        public Vendedor SearchVendedor(int id)
        {
            foreach (var v in OsVendedores)
            {
                if (v != null && v.Id == id)
                    return v;
            }
            return null;
        }

        public double ValorVendas()
        {
            double total = 0;
            foreach (var v in OsVendedores)
            {
                if (v != null)
                    total += v.ValorVendas();
            }
            return total;
        }

        public double ValorComissao()
        {
            double total = 0;
            foreach (var v in OsVendedores)
            {
                if (v != null)
                    total += v.ValorComissao();
            }
            return total;
        }

        public void ListarVendedores()
        {
            double totalVendas = 0;
            double totalComissao = 0;
            foreach (var v in OsVendedores)
            {
                if (v != null)
                {
                    Console.WriteLine($"ID: {v.Id}, Nome: {v.Nome}, Vendas: {v.ValorVendas():C2}, Comissão: {v.ValorComissao():C2}");
                    totalVendas += v.ValorVendas();
                    totalComissao += v.ValorComissao();
                }
            }
            Console.WriteLine($"Total de Vendas: {totalVendas:C2}");
            Console.WriteLine($"Total de Comissões: {totalComissao:C2}");
        }
    }
}
