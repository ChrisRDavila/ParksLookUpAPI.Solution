using System.ComponentModel.DataAnnotations;
using ParksLookUpAPI.Models;
using System.Collections.Generic;

namespace ParksLookUpAPI.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required(ErrorMessage = "The parks's name can't be empty!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "The park's state can't be empty!")]
    public string State { get; set; }
    [Required(ErrorMessage = "The park's features can't be empty!")]
    public string Features { get; set; }
    [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
    public int Rating { get; set; }

  }
}