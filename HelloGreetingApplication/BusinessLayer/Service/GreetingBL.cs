using System;
using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        private readonly IGreetingRL _greetingRL;

        public GreetingBL(IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL;
        }

        public string GetGreeting(string firstName = "", string lastName = "")
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return $"Hello {firstName} {lastName}";
            }
            else if (!string.IsNullOrEmpty(firstName))
            {
                return $"Hello {firstName}";
            }
            else if (!string.IsNullOrEmpty(lastName))
            {
                return $"Hello {lastName}";
            }
            else
            {
                return "Hello World";
            }
        }

        public GreetingResponseModel SaveGreeting(GreetingModel greetingModel)
        {
            var result = _greetingRL.SaveGreeting(greetingModel);

            GreetingResponseModel response = new GreetingResponseModel();
            response.Id = result.Id;
            response.Greeting = result.Greeting;

            return response;
        }

        public GreetingModel GetGreetingById(int id)
        {
            return _greetingRL.GetGreetingById(id);
        }

        public List<GreetingModel> GetAllGreetings()
        {
            return _greetingRL.GetAllGreetings();
        }

        public GreetingModel EditGreeting(int id, GreetingModel greetingModel)
        {
            return _greetingRL.UpdateGreeting(id, greetingModel);
        }

        public bool DeleteGreeting(int id)
        {
            return _greetingRL.DeleteGreeting(id);
        }
    }
}