using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OLE
{
    public class Placemark
    {
        [Key]
        public int Id { get; set; }

        public String Type { get; set; }

        public String GeometryType { get; set; }

        public float XCoordinate { get; set; }

        public float YCoordinate { get; set; }

        public String BalloonContent { get; set; }

        public String ClusterCaption { get; set; }

        public String HintContent { get; set; }

        public String Options { get; set; }

    }
}
