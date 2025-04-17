using System;
using System.Collections.Generic;

namespace WebApplication2.Models.Domain;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Birth { get; set; }

    public bool Gender { get; set; }

    public string ImgUrl { get; set; } = null!;

    public string Mssv { get; set; } = null!;

    public string? Decription { get; set; }
}
