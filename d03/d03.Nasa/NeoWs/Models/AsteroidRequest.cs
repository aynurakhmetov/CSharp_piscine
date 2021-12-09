using System;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace d03.Nasa.Lib
{
    public class AsteroidRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ResultCount { get; set; }
    }
}
