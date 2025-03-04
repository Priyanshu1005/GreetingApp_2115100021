using System;
using BusinessLayer.Interface;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        public string GetGreeting(string firstName = "", string lastName = "")
        {
            // Both first and last name are present
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return $"Hello {firstName} {lastName}";
            }
            // Only first name given
            else if (!string.IsNullOrEmpty(firstName))
            {
                return $"Hello {firstName}";
            }
            // Only last name given
            else if (!string.IsNullOrEmpty(lastName))
            {
                return $"Hello {lastName}";
            }
          
            else
            {
                return "Hello World";
            }
        }
    }
}