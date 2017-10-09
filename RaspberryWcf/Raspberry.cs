using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaspberryWcf
{
    public class Raspberry
    {
        public int Id { get; set; }
        public int Lys { get; set; }
        public DateTime Time { get; set; }

        public Raspberry()
        {
            
        }

        public Raspberry(int id, int lys, DateTime time)
        {
            Id = id;
            Lys = lys;
            Time = time;
        }
    }
}