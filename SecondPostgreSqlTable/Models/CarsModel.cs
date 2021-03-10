using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondPostgreSqlTable.Models
{
    public class CarsModel
    {
        public long Id { get; set; }

        public DateTime Tm { get; set; }

        public int V { get; set; }

        public string VN { get; set; }

        public double Cf { get; set; }

        public int VT { get; set; }

        public string Img { get; set; }

        public string FImg { get; set; }
    }
}
