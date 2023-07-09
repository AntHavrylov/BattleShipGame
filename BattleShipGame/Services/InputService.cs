using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleShipGame.Services
{
    public interface IInputService 
    {
        bool ValidateInput(string input, out int x, out int y);
    }

    public class InputService : IInputService
    {
        public bool ValidateInput(string input, out int x, out int y)
        {
            x = -1;
            y = -1;

            var regex = new Regex(@"^([A-J])([1-9]|10)$");
            if (!regex.IsMatch(input))
            {
                Console.WriteLine("Invalid input format. Please provide a capital letter A to J followed by a number from 1 to 10.");
                return false;
            }

            Match match = regex.Match(input);
            x = match.Groups[1].Value[0] - 'A';
            y = int.Parse(match.Groups[2].Value) - 1;
            return true;
        }
    }
}
