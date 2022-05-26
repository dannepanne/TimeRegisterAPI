﻿using System.ComponentModel.DataAnnotations;

namespace TimeRegisterAPI.DTO.ProjDTO;

public class UpdateProjectDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    [Required(ErrorMessage = "Projektnamn måste anges")]

    public string Name { get; set; }
    [Required(ErrorMessage = "Timpris måste anges")]

    public int PricePerHour { get; set; }
    public bool Active { get; set; }
}