using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Models;

namespace AMS.DAL
{
    public class StudentDAO
    {        
        public static StudentDTO GetStudentByStuAndCouId(int Id,int CouId)
        {
            String sqlQuery = String.Format("Select * from Student where StuId={0}", Id);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                StudentDTO dto = null;
                if (reader.Read())
                {
                    dto = FillStudentDTO(reader);
                    AttendanceDTO attendance = AttendanceDAO.GetAttendanceByStuIdAndCouId(Id, CouId);
                    dto.StuAttendance = attendance;
                }
                return dto;
            }            
        }

        public static List<StudentDTO> GetStudentsByCouId(int CouId)
        {
            List<StudentDTO> stuList = new List<StudentDTO>();

            List<AttendanceDTO> attList= AttendanceDAO.GetAttendancesByCouId(CouId);
            foreach (AttendanceDTO item in attList)
            {
                String sqlQuery = String.Format("Select * from Student where StuId={0}", item.StuId);
                using (DBHelper helper = new DBHelper())
                {
                    var reader = helper.ExecuteReader(sqlQuery);
                    StudentDTO dto = null;
                    if (reader.Read())
                    {
                        dto = FillStudentDTO(reader);
                        //AttendanceDTO attendance = AttendanceDAO.GetAttendanceByStuIdAndCouId(Id, CouId);
                        dto.StuAttendance = item;

                        stuList.Add(dto);
                    }
                }
            }
            return stuList;
        }
        

        private static StudentDTO FillStudentDTO(SqlDataReader reader)
        {
            StudentDTO dto = new StudentDTO();
            dto.StuId = reader.GetInt32(0);
            dto.StuName = reader.GetString(1);
            dto.StuRollNo = reader.GetString(2);
            return dto;
        }
    }
}
