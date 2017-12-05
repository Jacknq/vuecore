using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace bVue.code.controllers
{
    public class testcontroller: Controller
    {
   
    public async Task<string> hello(string search)
    {
            // Make an assignment..
            // Access to the DB, web request, etc.
            await Task.Delay(10);
            return "some test";      
    }


    }
}