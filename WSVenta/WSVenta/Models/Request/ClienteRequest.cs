namespace WSVenta.Models.Request
{
    public class ClienteRequest
    {
        public long Id { get; set; }  // Usar el tipo de dato long para las llaves primarias de tipo BIGINT.
        public string Nombre { get; set; }
    }
}
