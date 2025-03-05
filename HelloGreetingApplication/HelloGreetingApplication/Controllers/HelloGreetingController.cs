using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using BusinessLayer.Interface;
using NLog;

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

        [HttpPost]
        [Route("save")]
        public IActionResult SaveGreeting([FromBody] GreetingModel greetingModel)
        {
            var result = _greetingBL.SaveGreeting(greetingModel);

            var response = new ResponseModel<object>
            {
                Success = true,
                Message = "Greeting created",
                Data = result
            };
            return Created("Greeting Created", response);

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

        [HttpGet("GetGreetingById/{id}")]
        public IActionResult GetGreetingById(int id)
        {
            var response = new ResponseModel<GreetingModel>();
            try
            {   
                
                var result = _greetingBL.GetGreetingById(id);
                if (result != null)
                {
                    response.Success = true;
                    response.Message = "Greeting Message Found";
                    response.Data = result;
                    return Ok(response);
                }
                response.Success = false;
                response.Message = "Greeting Message Not Found";
                return NotFound(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, response);
            }
        }
        /// <summary>
        /// Get All Greetings
        /// </summary>
        /// <returns>returns all the greeting messages</returns>

        [HttpGet("GetAllGreetings")]
        public IActionResult GetAllGreetings()
        {
            ResponseModel<List<GreetingModel>> response = new ResponseModel<List<GreetingModel>>();
            try
            {
                var result = _greetingBL.GetAllGreetings();
                if (result != null && result.Count > 0)
                {
                    response.Success = true;
                    response.Message = "Greeting Messages Found";
                    response.Data = result;
                    return Ok(response);
                }
                response.Success = false;
                response.Message = "No Greeting Messages Found";
                return NotFound(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, response);
            }
        }

    }
}