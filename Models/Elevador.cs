using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WsElevadores.Models
{
    public class Elevador
    {
        public int andar { get; set; }
        public string elevador { get; set; }
        public string turno { get; set; }
    }
}