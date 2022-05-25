using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdentityScratchpad.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace IdentityScratchpad.Areas.Identity.Data;

// Add profile data for application users by adding properties to the CustomUser class
public class CustomUser : IdentityUser
{
    public List<Cat> Cats { get; set; } = default!;

    [PersonalData]
    public string? FavoriteColor { get; set; }

    [DataType(DataType.Date)]
    [ProtectedPersonalData]
    public DateTime? BirthDate { get; set; }
}

