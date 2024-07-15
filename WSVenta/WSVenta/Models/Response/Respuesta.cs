namespace WSVenta.Models.Response
{
    // Esta clase se crea para que sea como un "molde" para las posibles respuestas que recibirá nuestra app.
    public class Respuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }

        public Respuesta() { 
            this.Exito = 0;
        }
    }
}
