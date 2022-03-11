using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.FRONT.Common.Constants
{
    /// <summary>
    /// Permite seleccionar los más comunes tipos de métodos o verbos HTTP para peticiones REST
    /// </summary>
    public static class HTTPMethods
    {
        public static string Get => "GET";
        public static string Post => "POST";
        public static string Put => "PUT";
        public static string Delete => "DELETE";
    }
}
