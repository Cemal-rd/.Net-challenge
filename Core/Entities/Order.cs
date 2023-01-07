using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order : BaseEntity
    {
        public string OrderOwnerName { get; set; }
       
       
        
        public DateTime OrderDate { get; set; }
        [JsonIgnore]
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        [JsonIgnore]
        
     
        public Product Product { get; set; }
        public int ProductId { get; set; }
        
    }
}