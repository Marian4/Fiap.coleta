using Fiap.coleta.Data;

namespace Fiap.coleta.Models
{
    public class AddressModel
    {
        public int id { get; set; }
        public string cep { get; set; }
        public string street { get; set; }
        public string neighborhood { get; set; }
        public int number { get; set; }
        public char? complement { get; set; } = '-';
        public string city { get; set; }
        public string state { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
