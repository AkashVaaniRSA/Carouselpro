using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.Cors;
using CarouselBLLibrary;
using Carouselmodel;

namespace Carousel.Controllers
{
    //[EnableCors("http://localhost:4200", "*", "GET,POST,PUT")]
    public class SoftDeleteController : ApiController
    {
        CarouselBL bl = new CarouselBL();

        //CarouselModelLibrary value = new CarouselModelLibrary();

        //static List<CarouselModelLibrary> list = new List<CarouselModelLibrary>();


        public bool Get(int carouselId)
        {
            return bl.DeleteCarouselData(carouselId);
        }

    }
}