using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Configuration;
using System.Data.SqlClient;
using Google.Cloud.BigQuery.V2;

namespace samplegcpapp.Pages
{
    public class ContactModel : PageModel
    {
        public bool hasData = false;
        public string firstName = "";
        public string lastName = "";
        public string message = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            hasData = true;
            firstName = Request.Form["firstname"];
            lastName = Request.Form["lastname"];
            message = Request.Form["message"];

            var client = BigQueryClient.Create("samplegcpapp-381218");
            
            var newquery = "INSERT INTO samplegcpapp-381218.sampleappdata.contacts (firstname, lastname, msg) VALUES ('" + firstName + "', '" + lastName + "', '" + message + "');";

            client.ExecuteQuery(newquery, parameters: null);


        }
    }
}
