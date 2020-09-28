using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManiac.Shared
{
    public class CarData
    {
        public int Id { get; set; }
        public CarBrand Brand { get; set; }
        public CarType Type { get; set; }
        public string FullName { get; set; }
        public List<string> Nicknames { get; set; }
        public List<EngineData> AvailableEngines { get; set; }
        public List<int> YearsOfProduction { get; set; }
        public List<string> Images { get; set; }
    }
}
