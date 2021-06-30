using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoP_Ap2.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Observaciones { get; set; }
        public decimal Monto { get; private set; }

        [ForeignKey("CobroId")]
        public virtual List<CobrosDetalle> Detalle { get; set; } = new List<CobrosDetalle>();

        private void CalcularMonto()
        {
            Monto = 0m;
            foreach (var cobroDetalle in Detalle)
            {
                Monto += cobroDetalle.Monto;
            }
        }

        public decimal ObtenerMonto()
        {
            CalcularMonto();
            return Monto;
        }
    }
}