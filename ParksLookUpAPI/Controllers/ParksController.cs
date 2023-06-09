using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookUpAPI.Models;
using System;

namespace ParksLookUpAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksLookUpAPIContext _db;

    public ParksController(ParksLookUpAPIContext db)
    {
      _db = db;
    }
  }
}    
