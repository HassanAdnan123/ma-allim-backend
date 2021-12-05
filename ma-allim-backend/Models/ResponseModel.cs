using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ma_allim_backend.Models
{
    public class ResponseModel
    {
        public static List<singlerow> PopulateAttendanceData(RequestModel RecordsQty)
        {
            string constr = @"Data Source=DESKTOP-2TG2JQ0\THUNDERPC;Initial Catalog=ma-allim-portal;integrated security=true";
            List<singlerow> records = new List<singlerow>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = $"SELECT LOGINTIME, PERIODSTART, PERIOD, USERID, DateLogged, Minutes_Late, Status, Name FROM MONTH_ATTENDANCE({RecordsQty.userID},{RecordsQty.month},{RecordsQty.year}) GROUP BY USERID, DATELOGGED, PERIOD, LOGINTIME, MINUTES_LATE,STATUS, PERIODSTART, NAME;";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            records.Add(new singlerow
                            {
                                period = Convert.ToString(sdr["period"]),
                                logintime = Convert.ToString(sdr["logintime"]),
                                datelogged = Convert.ToDateTime(sdr["datelogged"]).ToString("dddd, dd MMMM yyyy"),
                                name = Convert.ToString(sdr["name"]),
                                minuteslate = Convert.ToString(sdr["minutes_late"]),
                                status = Convert.ToString(sdr["status"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return records;
        }
    }
    
    public class singlerow
    {
        public string name { get; set; }
        public string datelogged { get; set; }
        public string logintime { get; set; }
        public string period { get; set; }
        public string minuteslate { get; set; }
        public string status { get; set; }
    }
}
