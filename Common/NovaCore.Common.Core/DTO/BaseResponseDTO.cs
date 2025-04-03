using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaCore.Common.Core.DTO
{
    public class BaseResponseDTO
    {
        public BaseResponseDTO()
        {
            Excepcion = string.Empty;
            Confirmacion = false;
            Mensaje = String.Empty;
        }

        public string Excepcion { get; set; }
        public string Mensaje { get; set; }
        public bool Confirmacion { get; set; }
    }
}