using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Appfacultativa.Models
{
    public class prestamos
    {
        [PrimaryKey, AutoIncrement]
        public int IDPrestamo { get; set; }
        public decimal monto { get; set; }
        public decimal montoTotal { get; set; }
        public int meses { get; set; }
        public string cliente { get; set; }
        public decimal saldorest { get; set; }
        public decimal saldopagado { get; set; }
        public int porceninteres { get; set; }
        public decimal interes { get; set; }
        public decimal cuota { get; set; }
        public DateTime fechaprestamo { get; set; }

    }
}
