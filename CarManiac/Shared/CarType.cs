using System.Collections.Generic;

namespace CarManiac.Shared
{
    public class CarType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CarData> Cars { get; set; }
    }
}