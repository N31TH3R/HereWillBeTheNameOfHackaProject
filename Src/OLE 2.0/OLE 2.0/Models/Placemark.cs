using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OLE
{
    public class Placemark
    {
        [Key]
        public int Id { get; set; }

        public float Latitude { get; set; }

        public float Altitude { get; set; }

        public String Description { get; set; }

    }
}
