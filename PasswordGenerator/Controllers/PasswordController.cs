using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace PasswordGenerator.Controllers
{
    public class PasswordController : Controller
    {
        private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";         //defining attributes of the class by custom set characters.

        private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";

        private const string Digits = "0123456789";

        private const string SpecialCharacters = "!@#$%^&*()_-=+|;:,.<>?";

        public IActionResult Index()
        {

            return View("Generate");
        }
        [HttpPost]
        public IActionResult Generate(int length) //Passing in length as a parameter
        {
            try
            {
                {
                    string generatedPassword = GeneratePassword(length);
                    ViewBag.Password = generatedPassword;
                    return View("Generate");
                }
                static string GeneratePassword(int length)
                {
                    StringBuilder password = new StringBuilder();      // creating an empty string builder (a safe box)

                    Random random = new Random();

                    string charCombination = Uppercase + Lowercase + Digits + SpecialCharacters;       // creating pool of characters

                    while (password.Length < length)
                    {
                        char character = charCombination[random.Next(charCombination.Length)];

                        password.Append(character);
                    }
                    return password.ToString();
                }
            }
            catch (Exception e )
            {
                throw;
            }
           
        }
    }

}
