using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace LocalPass.Controls
{
    public class RandomPasswordCreator
    {
        private static Random random = new Random();
        public string DisplayedPassword;

        public RandomPasswordCreator()
        {
        }

        public static bool IsNullOrEmpty(char[] array)
        {
            return array == null || !array.Any() || array.Any(c => c == '\u0000' || c == ' ');
        }
        public static char GenerateRandomNumber()
        {
            int number = random.Next(0, 10);
            if (number >= 0 && number <= 9)
            {
                char numberAsChar = (char)('0' + number);
                return numberAsChar;
            }
            else
            {
                throw new ArgumentOutOfRangeException("number", "The generated number is not within the range of valid values.");
            }
        }


        public static char GenerateRandomLowerCaseletter()
        {
            int randomLowerCaseNumber = random.Next(97, 123);
            return Convert.ToChar(randomLowerCaseNumber);
        }
        public static char GenerateRandomUpperCaseletter()
        {

            int randomUpperCaseNumber = random.Next(65, 91);
            return Convert.ToChar(randomUpperCaseNumber);
        }

        public static char GenerateRandomSymbol()
        {
            int symbolGroup = random.Next(1, 5);
            int randomSymbolNumber = 0;
            switch (symbolGroup)
            {
                case 1:
                    randomSymbolNumber = random.Next(33, 48);
                    break;
                case 2:
                    randomSymbolNumber = random.Next(58, 65);
                    break;
                case 3:
                    randomSymbolNumber = random.Next(91, 97);
                    break;
                case 4:
                    randomSymbolNumber = random.Next(123, 127);
                    break;
            }
            return Convert.ToChar(randomSymbolNumber);
        }


        public void CreatePassword()
        {
            int passwordLength = random.Next(8, 17);
            char[] passwordCharacters = new char[passwordLength];
            int[] charactersChosen = new int[passwordCharacters.Length];

            for (int i = 0; i < passwordCharacters.Length; i++)
            {
                int characterChooser = random.Next(1, 5);
                charactersChosen[i] = characterChooser;
                char singlePasswordCharacter = 'a';


                switch (characterChooser)
                {
                    case 1:
                        singlePasswordCharacter = GenerateRandomLowerCaseletter();
                        break;
                    case 2:
                        singlePasswordCharacter = GenerateRandomUpperCaseletter();
                        break;
                    case 3:
                        singlePasswordCharacter = GenerateRandomSymbol();
                        break;
                    case 4:
                        singlePasswordCharacter = GenerateRandomNumber();
                        break;
                }

                passwordCharacters[i] = singlePasswordCharacter;

            }

            if (charactersChosen.Contains(1) && charactersChosen.Contains(2) && charactersChosen.Contains(3) && charactersChosen.Contains(4) && passwordCharacters.Length == passwordLength)
            {
                if (IsNullOrEmpty(passwordCharacters))
                {
                    CreatePassword();
                }
                else
                {

                    Password createdPassword = new Password(Guid.NewGuid(), string.Join("", passwordCharacters), DateTime.Now, PasswordCreatorServices.CurrentUser());
                    PasswordCreatorServices.AddPassword(createdPassword);
                    DisplayedPassword = createdPassword._password;
                }
            }
            else
            {
                CreatePassword();
            }
        }

        public static char GenerateRandomChracter()
        {
            char singlePasswordCharacter = 'a';
            int characterChooser = random.Next(1, 5);

            switch (characterChooser)
            {
                case 1:
                    singlePasswordCharacter = GenerateRandomLowerCaseletter();
                    break;
                case 2:
                    singlePasswordCharacter = GenerateRandomUpperCaseletter();
                    break;
                case 3:
                    singlePasswordCharacter = GenerateRandomSymbol();
                    break;
                case 4:
                    singlePasswordCharacter = GenerateRandomNumber();
                    break;
            }
            return singlePasswordCharacter;

        }


        public void DisplayPassword(Password password)
        {
            DisplayedPassword = password._password.ToString();
        }
    }
}
