using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OLE.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public int PlacemarkId { get; set; }

        [ForeignKey("PlacemarkId")]
        public Placemark Placemark { get; set; }
    }
}
