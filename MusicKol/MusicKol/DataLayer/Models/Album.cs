using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Album
    {
        public int Id;
        public string Title;
        public string Artist;
        public decimal Price;

        public Album(string title, string artist, decimal price)
        {
            Title = title;
            Artist = artist;
            Price = price;
        }

        public Album() { }  
    }
}
