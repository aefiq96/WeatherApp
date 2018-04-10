using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class weatherForcast{
        public city city { get; set; }
        public List<list> list { get; set; }
    }

    public class city {
        public string name { get; set; }
    }
    public class list {
        public double dt { get; set; } //day in milli seconds
        public double pressure { get; set; } //pressure hpa
        public double humidity { get; set; }//humidity %
        public double speed { get; set; }//wind speed km/h


    }
}
