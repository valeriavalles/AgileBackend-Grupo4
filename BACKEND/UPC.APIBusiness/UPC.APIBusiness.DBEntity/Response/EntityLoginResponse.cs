using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityLoginResponse : EntityBase
    {
        public int IdUsuario { get; set; }
        public string Perfil { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Documento { get; set; }
        public string Correo { get; set; }
        public string token { get; set; }
    }
}
