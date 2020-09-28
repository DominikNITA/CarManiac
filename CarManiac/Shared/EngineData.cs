using System.Collections.Generic;

namespace CarManiac.Shared
{
    public class EngineData
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Manufacturer { get; set; }
        public float HorsePower { get; set; }
        public List<CarData> Cars { get; set; }
        public EngineData()
        {

        }
    }
}