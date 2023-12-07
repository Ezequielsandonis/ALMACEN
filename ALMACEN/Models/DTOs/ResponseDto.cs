namespace ALMACEN.Models.DTOs
{
    public class ResponseDto
    {
        public bool EsExitoso { get; set; }
        public object Resultado { get; set; }
        public string Mensaje { get; set; }
        public List<string> MensajesError { get; set; }

    }
}
