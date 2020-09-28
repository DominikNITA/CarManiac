using System.Collections.Generic;

namespace CarManiac.Shared
{
    public class CarBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int CreationYear { get; set; }
        public ICollection<CarData> Cars {get; set;}
        //TODO: maybe add owned brands and reputation/opinions/score
    }
}