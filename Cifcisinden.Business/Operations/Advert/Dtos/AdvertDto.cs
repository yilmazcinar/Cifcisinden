using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Data.Enums;

namespace Cifcisinden.Business.Operations.Advert.Dtos
{
    public class AdvertDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public ServiceCategory ServiceCategory { get; set; }

        public Crop? Crop { get; set; }

        public City City { get; set; }

        public Town Town { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        
    }
}
