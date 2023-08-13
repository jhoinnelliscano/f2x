
using System.Text.Json.Serialization;

namespace F2x.EntityDomain.Domain
{
    public class Vehicle
    {
        private DateTime _date { get; set; }
        private string _quantity { get; set; }
        private string _tabulatedValue { get; set; }

        public string Station { get; set; }
        public string Direction { get; set; }
        public int Hour { get; set; }
        public string Category { get; set; }

        [JsonIgnore]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        [JsonPropertyName("date")]
        public string DateFormated
        {
            get { return _date.ToString("yyyy-MM-dd"); }
        }

        public int Quantity { get; set; }
        public decimal TabulatedValue { get; set; }

        public string QuantityFormated 
        {
            get { return Quantity.ToString("0.##"); }
        }

        public string TabulatedValueFormated
        {
            get { return TabulatedValue.ToString("0.00"); }
        }


    }
}
