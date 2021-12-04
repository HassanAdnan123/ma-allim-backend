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
        public static List<singlerow> PopulateFruits(int RecordsQty)
        {
            string constr = @"Data Source=DESKTOP-2TG2JQ0\THUNDERPC;Initial Catalog=ma-allim-portal;integrated security=true";
            List<singlerow> records = new List<singlerow>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = $"SELECT TOP {RecordsQty} * FROM SUMMARY_ATT sa";
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
                                period = (int)sdr["loggedperiod"],
                                logindate = (string)sdr["logindate"],
                                logintime = (string)sdr["logintime"],
                                name = (string)sdr["name"]
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
        public int period { get; set; }
        public string logindate { get; set; }
        public string name { get; set; }
        public string logintime { get; set; }

    }
}
