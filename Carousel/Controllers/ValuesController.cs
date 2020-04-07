using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CarouselBLLibrary;
using Carouselmodel;


namespace Carousel.Controllers
{
     //[EnableCors("http://localhost:4200", "*", "GET,POST,PUT")]
    public class ValuesController : ApiController
    {
        // GET api/values
        CarouselModelLibrary value = new CarouselModelLibrary();

        static List<CarouselModelLibrary> list = new List<CarouselModelLibrary>();

        CarouselBL bl = new CarouselBL();
        // GET api/values/5

        public IEnumerable<CarouselModelLibrary> Get()
        {
            return bl.GetCarouselData();
        }

        // POST api/values
        public bool Post([FromBody]CarouselModelLibrary value)
        {
            return bl.InsertCarouselData(value);

        }

        // PUT api/values/5
        public bool Put(int carouselId, [FromBody]CarouselModelLibrary value)
        {
            return bl.UpdateCarouselData(carouselId, value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}

