using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityProyectos : EntityBase
    {
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Perfil { get; set; }
        public string Empresa { get; set; }
        public decimal Tarifa { get; set; }
    }
}
