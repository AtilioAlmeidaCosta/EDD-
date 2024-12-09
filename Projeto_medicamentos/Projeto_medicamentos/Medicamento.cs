using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_medicamentos
{
    internal class Medicamento
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public string Laboratorio {  get; set; }
        public Queue<Lote> Lotes { get; set; }
        public Medicamento() { 
            Lotes = new Queue<Lote>();
        }
        public Medicamento(int id, string nome, string laboratorio) 
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
            Lotes = new Queue<Lote>();
        }
        public int QtdeDisponivel()
        {
            int totalQtde = 0;
            foreach (var lote in Lotes)
            {
                totalQtde += lote.Qtde;
            }
            return totalQtde;
        }
        public void Comprar(Lote lote)
        {
           Lotes.Enqueue(lote);
        }
        public bool Vender(int qtde)
        {
            int qtdeRestante = qtde;

            while (qtdeRestante > 0 && Lotes.Count > 0)
            {
                var loteAtual = Lotes.Peek();

                if (loteAtual.Qtde >= qtdeRestante)
                {
                    loteAtual.Qtde -= qtdeRestante;
                    qtdeRestante = 0;
                    if (loteAtual.Qtde == 0)
                    {
                        Lotes.Dequeue();
                    }
                }
                else
                {
                    qtdeRestante -= loteAtual.Qtde;
                    Lotes.Dequeue();
                }
            }
            return qtdeRestante == 0;
        }

        public override string ToString()
        {
            return ( Id + "-" + Nome + "-" + Laboratorio + "-" + this.QtdeDisponivel());
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Medicamento))
            {
                return false;
            }

            Medicamento other = (Medicamento)obj;
            return Id == other.Id;
        }
    }
}
