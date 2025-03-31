﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public string FullName { get; set; }

    public string Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeleteAt { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<NewsEvent> NewsEvents { get; set; } = new List<NewsEvent>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
}