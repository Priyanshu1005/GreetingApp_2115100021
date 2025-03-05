using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interface
{
    public interface IGreetingRL
    {
        string Greet(string message);
        GreetingEntity SaveGreeting(GreetingModel greetingModel);

        public GreetingModel GetGreetingById(int id);

        public List<GreetingModel> GetAllGreetings();

        public GreetingModel UpdateGreeting(int id, GreetingModel greetingModel);
    }
}