using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoP_Ap2.Models
{
    public class Clientes
        {
            [Key]
            public int ClienteId { get; set; }
            public string Nombres { get; set; }
        }
}