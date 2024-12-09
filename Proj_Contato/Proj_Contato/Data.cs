using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_Contato
{
    public class Data
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public void setData(int dia, int mes, int ano)
        {
            this.Dia = dia;
            this.Mes = mes;
            this.Ano = ano;
        }

        public override string ToString()
        {
            return $"{Dia:D2}/{Mes:D2}/{Ano}";
        }
    }

}
