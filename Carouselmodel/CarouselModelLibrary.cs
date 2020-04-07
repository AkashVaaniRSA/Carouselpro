using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carouselmodel
{
    public class CarouselModelLibrary
    {
        int carouselId;
        string applicationName,userName,carouselData;
        DateTime validFrom, validTo;

        public int CarouselId{ get => carouselId; set => carouselId = value; }
        public string ApplicationName { get => applicationName; set => applicationName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string CarouselData { get => carouselData; set => carouselData = value; }
        public DateTime ValidFrom { get => validFrom; set => validFrom = value; }
        public DateTime ValidTo { get => validTo; set => validTo = value; }

    }
}
