using Eccomerce_Full_Stack.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eccomerce_Full_Stack.Controllers;

public class DropDownController: Controller
{
    public ActionResult Index()
    {
        var dropdown = new DropdownModels();

        // Populate the list with sample data
        dropdown.Models.Add(new ListModels { Href = "/home", Label = "Home" });
        dropdown.Models.Add(new ListModels { Href = "/products", Label = "Products" });

        return View(dropdown);
    }

}