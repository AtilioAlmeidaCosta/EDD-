using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_medicamentos
{
    internal class Lote
    {
        public int Id { get; set; }
        public int Qtde {  get; set; }
        public DateTime Venc { get; set; }

        public Lote()
        {
            Id = 0;
            Qtde = 0;
            Venc = DateTime.Now;
        }
        
        public Lote(int id, int qtde, DateTime venc)
        {
            Id = id;
            Qtde = qtde;
            Venc = venc;
        }
        public override string ToString()
        {
            return (Id + "-" + Qtde + "-" + Venc);
        }

    }
}
