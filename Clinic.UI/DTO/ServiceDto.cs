namespace Clinic.UI.DTO
{
    public class ServiceDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        // public double Price { get; set; }
        
        //foreign key for prescription to know who it belongs to and who prescribed it
        // public int PrescriptionId { get; set; }
    }
}