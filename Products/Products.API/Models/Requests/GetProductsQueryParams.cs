using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Models.Requests
{
    public class GetProductsQueryParams
    {
        [FromQuery]
        public int? categoryId { get; set; }

        [FromQuery]
        public int page { get; set; } = 0;

        [FromQuery]
        public int limit { get; set; } = 10;
    }
}
