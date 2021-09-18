namespace Cars.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Puertas { get; set; }
        public int OwnerModelId { get; set; }
    }
}