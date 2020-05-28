using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Appfacultativa.Models
{
    public class clientes
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string nombre { get; set; }
        public int telefono { get; set; }
        public string cedula { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
    }
}
