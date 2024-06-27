namespace Fiap.coleta.Models
{
    public class ResidentModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int address_id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public AddressModel Address { get; set; }
    }
}
