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
    public class AttendanceDAO
    {
        public static AttendanceDTO GetAttendanceById(int Id)
        {
            String sqlQuery = String.Format("Select * from Attendance where AttId={0}", Id);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                AttendanceDTO dto = null;
                if (reader.Read())
                {
                    dto = FillAttendanceDTO(reader);
                }
                return dto;
            }
        }

        public static AttendanceDTO GetAttendanceByStuIdAndCouId(int StuId,int CouId)
        {
            String sqlQuery = String.Format("Select * from Attendance where StuId={0} And CouId={1}", StuId,CouId);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                AttendanceDTO dto = null;
                if (reader.Read())
                {
                    dto = FillAttendanceDTO(reader);
                }
                return dto;
            }
        }
       
        public static List<AttendanceDTO> GetAttendancesByCouId(int Id)
        {
            String sqlQuery = String.Format("Select * from Attendance where CouId={0}", Id);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                List<AttendanceDTO> list = new List<AttendanceDTO>();
                AttendanceDTO dto = null;
                while (reader.Read())
                {
                    dto = FillAttendanceDTO(reader);
                    if (dto != null)
                        list.Add(dto);
                }
                return list;
            }
        }

        public static int Save(AttendanceDTO dto)
        {
            String sqlQuery = "";
            if (dto.AttId > 0)
            {
                sqlQuery = String.Format("Update Attendance set AttPresents={0}, AttAbsents={1}  where AttId={2}",
                    dto.AttPresents,dto.AttAbsents,dto.AttId);
            }
            else
            {
                int AttId = GetAutoIncerment();
                sqlQuery = String.Format("Insert into Attendance ( AttId , AttPresents , AttAbsents , StuId , CouId ) values('{0}','{1}',{2},{3},{4})",
                    AttId,dto.AttPresents,dto.AttAbsents,dto.StuId,dto.CouId);
            }
            using (DBHelper helper = new DBHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
        }

        private static AttendanceDTO FillAttendanceDTO(SqlDataReader reader)
        {
            AttendanceDTO dto = new AttendanceDTO();
            dto.AttId = reader.GetInt32(0);
            dto.AttPresents = reader.GetInt32(1);
            dto.AttAbsents = reader.GetInt32(2);
            dto.StuId = reader.GetInt32(3);
            dto.CouId = reader.GetInt32(4);
            return dto;
        }

        private static int GetAutoIncerment()
        {
            String sqlQuery = "Select Max(AttId) from Attendance";
            using (DBHelper helper = new DBHelper())
            {
                return (Convert.ToInt32(helper.ExecuteScalar(sqlQuery)) + 1);
            }
        }

    }
}
