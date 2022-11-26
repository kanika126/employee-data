using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace firstclass.Pages
{
    public class ContactModel : PageModel
    {
        public bool hasData = false;
        public string firstname = "";
        public string lastname = "";
        public string message = "";

  
        public void OnGet()
        {
        }

        public void Onpost()
        {
            hasData= true;
            firstname = Request.Form["firstname"];
            lastname = Request.Form["lastname"];
            message = Request.Form["message"];

        }
    }
}
