using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers;

public class ProfileController : Controller
{
    
    // GET
    public  IActionResult Index()
    {
       return   View("Profile");
    }

   
}