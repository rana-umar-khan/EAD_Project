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
    public class AttendanceHistoryDAL
    {
        public static AttendanceHistoryDTO GetAttendanceHistoryById(int Id)
        {
            String sqlQuery = String.Format("Select * from AttendanceHistory where HisId={0}", Id);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                AttendanceHistoryDTO dto = null;
                if (reader.Read())
                {
                    dto = FillAttendanceHistoryDTO(reader);
                }
                return dto;
            }
        }

        public static List<AttendanceHistoryDTO> GetAttendanceHistorysByAttId(int Id)
        {
            String sqlQuery = String.Format("Select * from AttendanceHistory where AttId={0}", Id);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                List<AttendanceHistoryDTO> list = new List<AttendanceHistoryDTO>();
                AttendanceHistoryDTO dto = null;
                while (reader.Read())
                {
                    dto = FillAttendanceHistoryDTO(reader);
                    if (dto != null)
                        list.Add(dto);
                }
                return list;
            }
        }

        public static int Save(AttendanceHistoryDTO dto)
        {
            String sqlQuery = "";
            int isPresent=0;
            if(dto.HisIsPresent)
                isPresent=1;
            if (dto.HisId > 0)
            {
                sqlQuery = String.Format("Update AttendanceHistory set HisDateTime='{0}' , HisIsPresent={1} , AttId={2}  where HisId={3}",
                 dto.HisDateTime, isPresent, dto.AttId ,dto.HisId);
            }
            else
            {
                int HisId = GetAutoIncerment();
                sqlQuery = String.Format("Insert into AttendanceHistory (HisId, HisDateTime , HisIsPresent , AttId ) values({0},'{1}',{2},{3} )",
                    HisId, dto.HisDateTime, isPresent, dto.AttId);
            }
            using (DBHelper helper = new DBHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
        }

        private static AttendanceHistoryDTO FillAttendanceHistoryDTO(SqlDataReader reader)
        {
            AttendanceHistoryDTO dto = new AttendanceHistoryDTO();
            dto.HisId = reader.GetInt32(0);
            dto.HisDateTime = reader.GetDateTime(1);
            dto.HisIsPresent = reader.GetBoolean(2);
            dto.AttId = reader.GetInt32(3);
            return dto;
        }

        private static int GetAutoIncerment()
        {
            String sqlQuery = "Select Max(HisId) from AttendanceHistory";
            using (DBHelper helper = new DBHelper())
            {
                return (Convert.ToInt32(helper.ExecuteScalar(sqlQuery)) + 1);
            }
        }
    }
}
