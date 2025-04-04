﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity;

public partial class Contact
{
    public int ContactId { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public string Name { get; set; }

    public string Email { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string Message { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeleteAt { get; set; }
}