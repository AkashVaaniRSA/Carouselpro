using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carouselmodel;
using CarouselDAL;



namespace CarouselBLLibrary
{
    public class CarouselBL
    {
        CarouselDALLibrary dal;
        public CarouselBL()
        {
            dal = new CarouselDALLibrary();
        }

        public List<CarouselModelLibrary> GetCarouselData()
        {
            return dal.GetCarouselData();
        }

        public bool InsertCarouselData(CarouselModelLibrary saveData)
        {

            return dal.InsertCarouselData(saveData);
        }
       
        public bool UpdateCarouselData(int carouselId, CarouselModelLibrary value)
        {
            return dal.UpdateCarouselData(carouselId, value);
        }

        public bool DeleteCarouselData(int carouselId)
        {
            return dal.DeleteCarouselData(carouselId);
        }
    }
}

    
