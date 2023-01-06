using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductToReturnDto
    {
      public string ProductName { get; set; }
      public int Stock { get; set; }
      public int Price { get; set; }
      [JsonIgnore]
      public string Company { get; set; }
    //   public string Camponyname { get; set; }
      
    
    }
}