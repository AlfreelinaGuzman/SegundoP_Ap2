using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoP_Ap2.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int CobroDetalleId { get; set; }
        public int CobroId { get; set; }
        public int VentaId { get; set; }
        public decimal Monto { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
    }
}