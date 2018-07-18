using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Core.Models
{
    public class ProductVM
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("sku")]
        public string SKU { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
