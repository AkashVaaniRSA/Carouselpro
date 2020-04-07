using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Carouselmodel;
using System.Data.SqlClient;
using System.Data;

namespace CarouselDAL
{
    public class CarouselDALLibrary
       {
        
            SqlConnection conn;
        SqlCommand cmdGetCarouselData, cmdInsertCarouselData, cmdUpdateCarouselData, cmdDeleteCarouselData;

            public CarouselDALLibrary()
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conUser"].ConnectionString);
            }

        public List<CarouselModelLibrary> GetCarouselData()
        {
            conn.Open();
            List<CarouselModelLibrary> list = new List<CarouselModelLibrary>();
            cmdGetCarouselData = new SqlCommand("spGetCarouselData", conn);
            cmdGetCarouselData.CommandType = CommandType.StoredProcedure;
            CarouselModelLibrary GetCarouselData;
            SqlDataReader dataReader = cmdGetCarouselData.ExecuteReader();
            try
            {
                while (dataReader.Read())

                {
                    GetCarouselData = new CarouselModelLibrary();
                    GetCarouselData.CarouselId = Convert.ToInt32(dataReader[0].ToString());
                    GetCarouselData.ApplicationName = (dataReader[1].ToString());
                    GetCarouselData.UserName = (dataReader[2].ToString());
                    GetCarouselData.CarouselData = (dataReader[3].ToString());

                    list.Add(GetCarouselData);
                }
            }
            catch (Exception Io)
            {
                Console.WriteLine("Exception");
            }

            conn.Close();
            return list;
        }


    
       

        public bool InsertCarouselData(CarouselModelLibrary saveData)
        {
            bool carouselStatus = false;
            conn.Open();
            cmdInsertCarouselData = new SqlCommand("SpInsert", conn);
            cmdInsertCarouselData.Parameters.AddWithValue("@applicationName", saveData.ApplicationName);
            cmdInsertCarouselData.Parameters.AddWithValue("@userName", saveData.UserName);
            cmdInsertCarouselData.Parameters.AddWithValue("@carouselData", saveData.CarouselData);
            cmdInsertCarouselData.Parameters.AddWithValue("@validFrom", saveData.ValidFrom);
            cmdInsertCarouselData.Parameters.AddWithValue("@validTo", saveData.ValidTo);
            cmdInsertCarouselData.CommandType = CommandType.StoredProcedure;


            if (cmdInsertCarouselData.ExecuteNonQuery() > 0)
            {
                return carouselStatus = true;
            }
            conn.Close();
            return carouselStatus;
        }


        public bool UpdateCarouselData(int carouselId, CarouselModelLibrary data)
        {

            bool carouselStatus = false;
            conn.Open();
            try
            {
                cmdUpdateCarouselData = new SqlCommand("spUpdate", conn);
                cmdUpdateCarouselData.Parameters.Add("@carouselId", SqlDbType.Int);
                cmdUpdateCarouselData.Parameters.Add("@applicationName", SqlDbType.NVarChar, 150);
                cmdUpdateCarouselData.Parameters.Add("@userName", SqlDbType.NVarChar, 150);
                cmdUpdateCarouselData.Parameters.Add("@carouselData", SqlDbType.NVarChar);
                cmdUpdateCarouselData.Parameters.Add("@validFrom", SqlDbType.DateTime);
                cmdUpdateCarouselData.Parameters.Add("@validTo", SqlDbType.DateTime);


                cmdUpdateCarouselData.Parameters[0].Value = carouselId;
                cmdUpdateCarouselData.Parameters[1].Value = data.ApplicationName;
                cmdUpdateCarouselData.Parameters[2].Value = data.UserName;
                cmdUpdateCarouselData.Parameters[3].Value = data.CarouselData;
                cmdUpdateCarouselData.Parameters[4].Value = data.ValidFrom;
                cmdUpdateCarouselData.Parameters[5].Value = data.ValidTo;


                cmdUpdateCarouselData.CommandType = CommandType.StoredProcedure;
                if (cmdUpdateCarouselData.ExecuteNonQuery() > 0)
                {
                    return carouselStatus = true;
                }
            }
            catch (Exception IO)
            {
                Console.WriteLine("update");
            }
            conn.Close();
            return carouselStatus;
        }

        public bool DeleteCarouselData(int carouselId)
        {
            bool carouselStatus = false;
            conn.Open();
            cmdDeleteCarouselData = new SqlCommand("spSoftDelete", conn);
            cmdDeleteCarouselData.Parameters.AddWithValue("@carouselId", carouselId);
            cmdDeleteCarouselData.CommandType = CommandType.StoredProcedure;




            if (cmdDeleteCarouselData.ExecuteNonQuery() > 0)
            {
                return carouselStatus = true;
            }
            conn.Close();
            return carouselStatus;
        }

    }

}

