using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    

    public class AttendanceDTO
    {
       
        public int AttId { get; set; }
        public int AttPresents { get; set; }
        public int AttAbsents { get; set; }
        public int StuId { get; set; }
        public int CouId { get; set; }
    }
}
