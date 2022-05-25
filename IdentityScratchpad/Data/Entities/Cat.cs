using IdentityScratchpad.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityScratchpad.Data.Entities
{
    public class Cat
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string Color { get; set; }

        [ForeignKey(nameof(Owner))]
        public string? OwnerId { get; set; }

        public CustomUser? Owner { get; set; }
    }
}
