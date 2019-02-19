using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ConnectionClass
{
    public class ConnectBDD
    {

     private string _ConnectionString;
     SqlConnection connexxion;
     public void GetConnexionString()
    {
        _ConnectionString = ConfigurationManager.ConnectionStrings["RepublicSystemConnectionString"].ConnectionString;
    }
     public void ConnectBD()
    {
        GetConnexionString();
        connexxion = new SqlConnection(_ConnectionString);
        connexxion.Open();
    }

         public string SelectStringExecuta(string consulta)
        {
            try
            {
                string cadena;
                ConnectBD();
                SqlCommand comanda = new SqlCommand(consulta, connexxion);
                cadena = (string)comanda.ExecuteScalar();
                return cadena;
            }catch (SqlException e)
            {
                return e.Message;
            }
            finally
            {
                connexxion.Close();
            }
        }

        public bool SelectExistDelivery(string consulta){
            try
            {
                ConnectBD();
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, _ConnectionString);
                DataSet dtsCli = new DataSet();
                adapter.Fill(dtsCli);
                string CodeDelivery = dtsCli.Tables[0].Rows[0]["CodeDelivery"].ToString();
                if (CodeDelivery.Length==0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            } catch (SqlException e)
            {
                return false;
            }
            finally
            {
                connexxion.Close();
            }
        }

        public DataSet PortaTaula(string nomTaula)
        {
            try
            {
                ConnectBD();
                string query = "SELECT CodeDelivery, DeliveryDate , SpaceShip  FROM " + nomTaula;
                SqlDataAdapter adapter = new SqlDataAdapter(query, _ConnectionString);
                DataSet dtsCli = new DataSet();
                adapter.Fill(dtsCli, nomTaula);
                return dtsCli;
            }
            catch (SqlException e)
            {
                return null;
            }
            finally
            {
                connexxion.Close();
            }
        }
    }
}
