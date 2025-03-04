using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using BusinessLayer.Interface;
using NLog;
using RepositoryLayer.Service;

namespace HelloGreetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private readonly IGreetingBL _greetingBL;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public HelloGreetingController(IGreetingBL greetingBL)
        {
            _greetingBL = greetingBL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            logger.Info("HTTP GET request called");
            var greeting = _greetingBL.GetGreeting();
            var data = new
            {
                Message = greeting
            };

            var response = new ResponseModel<object>()
            {
                Success = true,
                Message = "Greeting Message",
                Data = data
            };

            return Ok(response);
        }
        [HttpPost]
        public IActionResult Post([FromBody] RequestModel requestModel)
        {
            logger.Info("HTTP POST request called");
            var greeting = _greetingBL.GetGreeting(requestModel.FirstName, requestModel.LastName);
            var data = new
            {
                Message = greeting
            };
            var response = new ResponseModel<object>()
            {
                Success = true,
                Message = "Greeting Message",
                Data = data
            };
            return Ok(response);
        }
        [HttpPut]
        public IActionResult Put([FromBody] RequestModel requestModel)
        {
            logger.Info("HTTP PUT request called");
            var greeting = _greetingBL.GetGreeting(requestModel.FirstName, requestModel.LastName);
            var data = new
            {
                Message = greeting
            };
            var response = new ResponseModel<object>()
            {
                Success = true,
                Message = "Greeting Message",
                Data = data
            };
            return Ok(response);
        }
        [HttpPatch]
        public IActionResult Patch([FromBody] RequestModel requestModel)
        {
            logger.Info("HTTP PATCH request called");
            var greeting = _greetingBL.GetGreeting(requestModel.FirstName, requestModel.LastName);
            var data = new
            {
                Message = greeting
            };
            var response = new ResponseModel<object>()
            {
                Success = true,
                Message = "Greeting Message",
                Data = data
            };
            return Ok(response);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] RequestModel requestModel)
        {
            logger.Info("HTTP DELETE request called");
            var greeting = _greetingBL.GetGreeting(requestModel.FirstName, requestModel.LastName);
            var data = new
            {
                Message = greeting
            };
            var response = new ResponseModel<object>()
            {
                Success = true,
                Message = "Greeting Message",
                Data = data
            };
            return Ok(response);
        }
    }
}