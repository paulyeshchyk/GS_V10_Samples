﻿using System.ComponentModel.DataAnnotations;

namespace _7_1.Entities
{
  public class RefEmployee
  {
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Surname { get; set; }
    public int? Age { get; set; }
  }
}