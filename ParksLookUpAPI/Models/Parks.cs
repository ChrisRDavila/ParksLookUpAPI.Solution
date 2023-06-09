using System.ComponentModel.DataAnnotations;
using ParksLookUpAPI.Models;
using System.Collections.Generic;

namespace ParksLookUpAPI.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string Name { get; set; }
    public string State { get; set; }
    public string Features { get; set; }
    public int Rating { get; set; }

  }
}