using System.Net;

namespace AcademiaOnline.Application.Common.ManejadorError
{
    public class ManejadorExcepcion : Exception
    {
        public HttpStatusCode Codigo { get; }
        public List<string> Errores { get; }

        public ManejadorExcepcion(HttpStatusCode codigo, object errores = null!)
        {
            Codigo = codigo;
            Errores = errores is string mensaje
                ? new List<string> { mensaje }
                : errores as List<string> ?? new List<string>();
        }

        public object ObtenerRespuesta()
        {
            return new
            {
                Codigo = (int)Codigo,
                Mensaje = "Se produjo un error en la solicitud.",
                Errores
            };
        }
    }
    //public class ManejadorExepcion : Exception
    //{
    //    public HttpStatusCode Codigo { get; }
    //    public object Errores { get; }

    //    public ManejadorExepcion(HttpStatusCode codigo, object errores = null!)
    //    {
    //        Codigo = codigo;
    //        Errores = errores;
    //    }
    //}
}
