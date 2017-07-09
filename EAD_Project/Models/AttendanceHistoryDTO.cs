using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AttendanceHistoryDTO
    {
        public int HisId { get; set; }
        public DateTime HisDateTime { get; set; }
        public bool HisIsPresent { get; set; }
        public int AttId { get; set; }
    }
}
