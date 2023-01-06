using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public bool IsVerified  { get; set; } = false;
        [JsonConverter(typeof(TimeConverter))]
        public DateTime permissionStartDate { get; set; }
        [JsonConverter(typeof(TimeConverter))]
        public DateTime permissionEndDate { get; set; }
        
        [JsonIgnore]
        public List<Product> Products { get; set; }
        [JsonIgnore]
        public List<Order> Orders { get; set; }

    }
}