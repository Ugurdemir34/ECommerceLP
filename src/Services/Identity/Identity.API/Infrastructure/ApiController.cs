using MediatR;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Identity.API.Infrastructure
{
    public class ApiController:ControllerBase
    {
        protected ISender Sender { get; }
        protected ApiController(ISender sender) => Sender = sender;
        protected IActionResult BadRequest(string error) => BadRequest("Hata");
        protected new IActionResult Ok(object value) => base.Ok(value);
        protected new IActionResult NotFound() => NotFound("The requested resource was not found.");
    }
}
