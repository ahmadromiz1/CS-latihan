using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodeHaveD4Quiz.Servis
{
    internal class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }

        public Movie(int no, string name, decimal rating)
        {
            ID = no;
            Name = name;
            Rating = rating;
        }
    }
}
