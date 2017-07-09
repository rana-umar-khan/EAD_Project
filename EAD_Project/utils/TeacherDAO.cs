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
    public class TeacherDAO
    {
        public static int Save(TeacherDTO dto)
        {
            String sqlQuery = "";
            if (dto.TeaId > 0)
            {
                sqlQuery = String.Format("Update Teacher set TeaUsername='{0}',TeaPassword='{1}',TeaFirstName='{2}',TeaLastName='{3}',TeaEmail='{4}',TeaContactNo='{5}' where TeaId={6}",
                    dto.TeaUsername,dto.TeaPassword,dto.TeaFirstName,dto.TeaLastName,dto.TeaEmail,dto.TeaContactNo,dto.TeaId);
            }
            else
            {
                //int UserId = GetAutoIncerment();
                //sqlQuery = String.Format("Insert into Users (Username,CreatedOn,CreatedBy,IsActive,UserId,Password) values('{0}','{1}',{2},{3},{4},{5})",
                //    dto.Username, dto.CreatedOn, dto.CreatedBy, 1, UserId, dto.Password);
            }
            using (DBHelper helper = new DBHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }             
        }

        public static TeacherDTO GetTeachherByUsername(String Username)
        {
            String sqlQuery = String.Format("Select * from Teacher where TeaUsername='{0}'", Username);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                TeacherDTO dto = null;
                if (reader.Read())
                {
                    dto = FillTeacherDTO(reader);
                }
                return dto;
            }
        }

        private static TeacherDTO FillTeacherDTO(SqlDataReader reader)
        {
            TeacherDTO dto = new TeacherDTO();
            dto.TeaId = reader.GetInt32(0);
            dto.TeaUsername = reader.GetString(1);
            dto.TeaPassword = reader.GetString(2);
            dto.TeaFirstName = reader.GetString(3);
            dto.TeaLastName = reader.GetString(4);
            dto.TeaEmail=reader.GetString(5);
            dto.TeaContactNo=reader.GetString(6);
            return dto;
        }


        //Not Required
        private static int DeleteTeacher(int UserId)
        {
            /*
            String sqlQuery = String.Format("Update Users set IsActive={0} where UserId={1}", 0, UserId);
            using (DBHelper helper = new DBHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
            */
            return 0;
        }

        private static void GetTeacherById(int UserId)
        {
            /*
            String sqlQuery = String.Format("Select * from Users where UserId={0}", UserId);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                UserDTO dto = null;
                if (reader.Read())
                {
                    dto = FillDTO(reader);
                }
                return dto;
            }
            */ 
        }

        private static void GetAllUsers()
        {
            /*
            String sqlQuery = String.Format("Select * from Users where IsActive={0}", 1);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                List<UserDTO> list = new List<UserDTO>();
                while (reader.Read())
                {
                    var dto = FillDTO(reader);
                    if (dto != null)
                        list.Add(dto);
                }
                return list;
            }
             */ 
        }

        private static int GetAutoIncerment()
        {
            String sqlQuery = "Select Max(TeaId) from Teacher";
            using (DBHelper helper = new DBHelper())
            {
                return (Convert.ToInt32(helper.ExecuteScalar(sqlQuery)) + 1);
            }
        }

    }
}
