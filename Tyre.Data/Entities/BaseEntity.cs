using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tyre.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime? CreatedDate { get; set; }
        //[JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        //[JsonIgnore]
        public DateTime? DeletedDate { get; set; }
        //[JsonIgnore]
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        public bool? IsDeleted { get; set; } = false;
        [JsonIgnore]
        public string? UpdatedBy { get; set; }
        [JsonIgnore]
        public string? DeletedBy { get; set; }
    }
}
