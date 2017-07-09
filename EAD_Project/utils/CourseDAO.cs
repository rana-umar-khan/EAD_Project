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
    public class CourseDAO
    {
        public static CourseDTO GetCourseById(int Id)
        {
            String sqlQuery = String.Format("Select * from Course where CouId={0}", Id);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                CourseDTO dto = null;
                if (reader.Read())
                {
                    dto = FillCourseDTO(reader);
                }
                return dto;
            }
        }

        public static List<CourseDTO> GetCoursesByTeaId(int Id)
        {
            String sqlQuery = String.Format("Select * from Course where TeaId={0}", Id);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                List<CourseDTO> list = new List<CourseDTO>();
                CourseDTO dto = null;
                while (reader.Read())
                {
                    dto = FillCourseDTO(reader);
                    if(dto!=null)
                        list.Add(dto);
                }
                return list;
            }
        }
        
        private static CourseDTO FillCourseDTO(SqlDataReader reader)
        {
            CourseDTO dto = new CourseDTO();
            dto.CouId = reader.GetInt32(0);
            dto.CouName = reader.GetString(1);
            dto.TeaId = reader.GetInt32(2);
            return dto;
        }
    }
}
