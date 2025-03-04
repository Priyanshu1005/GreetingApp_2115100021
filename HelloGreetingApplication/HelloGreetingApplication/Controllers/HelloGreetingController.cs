using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using BusinessLayer.Service;
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
            logger.Info("GET request received.");
            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Hello to Greeting App API Endpoint",
                Data = "Hello World"
            };
            logger.Info("GET response: {@Response}", responseModel);
            return Ok(responseModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RequestModel requestModel)
        {
            logger.Info($"POST request received: Key={requestModel.Key}, Value={requestModel.Value}");

            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Request received successfully",
                Data = $"Key: {requestModel.Key}, Value: {requestModel.Value}"
            };

            logger.Info("POST response: {@Response}", responseModel);
            return Ok(responseModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] RequestModel requestModel)
        {
            logger.Info($"PUT request received: Key={requestModel.Key}, Value={requestModel.Value}");

            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Data Updated Successfully",
                Data = $"Key: {requestModel.Key}, Value: {requestModel.Value}"
            };

            logger.Info("PUT response: {@Response}", responseModel);
            return Ok(responseModel);
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] RequestModel requestModel)
        {
            logger.Info($"PATCH request received: Key={requestModel.Key}, Value={requestModel.Value}");

            var data = new
            {
                key = string.IsNullOrWhiteSpace(requestModel.Key) ? "Not updated" : requestModel.Key,
                value = string.IsNullOrWhiteSpace(requestModel.Value) ? "Not updated" : requestModel.Value
            };

            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Data Updated Successfully",
                Data = $"Key: {data.key}, Value: {data.value}"
            };

            logger.Info("PATCH response: {@Response}", responseModel);
            return Ok(responseModel);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] RequestModel requestModel)
        {
            logger.Info($"DELETE request received: Key={requestModel.Key}, Value={requestModel.Value}");

            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Data Deleted Successfully",
                Data = $"Key: {requestModel.Key}, Value: {requestModel.Value}"
            };

            logger.Info("DELETE response: {@Response}", responseModel);
            return Ok(responseModel);
        }


        [HttpGet("Greetings")]

        public IActionResult Greeting()
        {
            logger.Info("GET request received.");

            var response = _greetingBL.Greet("Hello World");

            logger.Info("GET response: {@Response}", response);

            return Ok(response);
        }
    }
}