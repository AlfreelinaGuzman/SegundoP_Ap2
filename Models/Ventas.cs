using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoP_Ap2.Models
{
    public class Ventas
        {
            [Key]
            public int VentaId { get; set; }
            public DateTime Fecha { get; set; }
            public int ClienteId { get; set; }
            public decimal Monto { get; set; }
            public decimal Balance { get; set; }

            public virtual bool Pendiente => Balance > 0;

        }
}