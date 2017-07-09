using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentDTO
    {
        public int StuId { get; set; }
        public string StuName { get; set; }
        public string StuRollNo { get; set; }
        public AttendanceDTO StuAttendance { get; set; }
    }
}
