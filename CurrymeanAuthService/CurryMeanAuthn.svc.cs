using CurrymeanAuthService.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data;
namespace CurrymeanAuthService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CurryMeanAuthn" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CurryMeanAuthn.svc or CurryMeanAuthn.svc.cs at the Solution Explorer and start debugging.
    public class CurryMeanAuthn : ICurryMeanAuthn
    {
        public Employee JSONData(string id, string password)
        {
            Employee em = new Employee();
            return em;
        }



        public List<Employee> GetDetails(string userName, string password)
        {
            SqlDataReader rdr = null;
            var connectionStrings = System.Configuration.ConfigurationManager.ConnectionStrings["DBDetails"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionStrings);
            SqlCommand cmd = new SqlCommand("spsGetUserAuth", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@userName",SqlDbType.VarChar).Value = userName;
            conn.Open();
            rdr = cmd.ExecuteReader();
            
            List<Employee> empArray = new List<Employee>();
            while (rdr.Read())
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(rdr["Id"]);
                emp.UserName = rdr["UserName"].ToString();
                emp.UserMail = rdr["UserMail"].ToString();
                emp.Social = Convert.ToInt32(rdr["Social"]);
                empArray.Add(emp);
            }
            conn.Close();
            return empArray;
            //Employee em = new Employee();
            //em.address = 
            //em.code = "code2";
            //em.id = "code2";
            //em.name = "sandeep2";
            //return em;     //sample
        }
        public bool NewUser(Employee arr)
        {
            bool res = true;
            try
            {
                var connectionStrings = System.Configuration.ConfigurationManager.ConnectionStrings["DBDetails"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionStrings);
                SqlCommand cmd = new SqlCommand("spiUserDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = arr.UserName;
                cmd.Parameters.Add("@userMail", SqlDbType.VarChar).Value = arr.UserMail;
                cmd.Parameters.Add("@passWord", SqlDbType.VarChar).Value = arr.Password;
                cmd.Parameters.Add("@Social", SqlDbType.VarChar).Value = arr.Social;
                conn.Open();
                cmd.ExecuteNonQuery();
                res = true;
            }
            catch
            {
                res = false;
            }

            return res;
        }
        /// <summary>
        /// this is a sample service creation for tree view for danesh
        /// </summary>
        /// <returns></returns>
        public List<Tree> getData() {
            List<Tree> treeList = new List<Tree>();
            Tree tr = new Tree();
            tr.id = 1;
            tr.text = "root node";
            tr.children = new List<Tree>();
            Tree tr1 = new Tree();
            tr1.id = 2;
            tr1.text = "child1 node";
            tr1.children = new List<Tree>();
            tr.children.Add(tr1);
            Tree tr2 = new Tree();
            tr2.id = 3;
            tr2.text = "child2 node";
            tr2.children = new List<Tree>();
            tr.children.Add(tr2);
            treeList.Add(tr);
            return treeList;     
        }
    }
      

}
