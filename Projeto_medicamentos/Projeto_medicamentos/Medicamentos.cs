using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_medicamentos
{
    internal class Medicamentos
    {
        public List<Medicamento> ListaMedicamentos { get; set; }
        public Medicamentos()
        {
            ListaMedicamentos = new List<Medicamento>();
        }
        public void Adicionar(Medicamento medicamento)
        {
            ListaMedicamentos.Add(medicamento);
        }
        public bool Deletar(Medicamento medicamento)
        {
            if (medicamento.QtdeDisponivel() == 0)
            {
                ListaMedicamentos.Remove(medicamento);
                return true;
            }
            return false;
        }
        public Medicamento Pesquisar(Medicamento medicamento)
        {
            return ListaMedicamentos.Find(m => m.Id == medicamento.Id);
        }
        public void ListarMedicamentos()
        {
            foreach (var medicamento in ListaMedicamentos)
            {
                Console.WriteLine(medicamento.ToString());
            }
        }
    }
}
