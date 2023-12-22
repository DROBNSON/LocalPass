using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPass.Controls
{
    public class CustomPasswordCreator
    {
        public static string DisplayedPassword;
        private string customName;
        private int customPasswordLength;
        private string customKeyword;
        private string customCode;


        public string Name { get => customName; set => customName = value; }
        public int PasswordLength { get => customPasswordLength; set => customPasswordLength = value; }
        public string Keyword { get => customKeyword; set => customKeyword = value; }
        public string Code { get => customCode; set => customCode = value; }
        public static Random rand = new Random();

        public CustomPasswordCreator(string name, int passwordLength, string keyword, string code)
        {
            customName = name;
            customPasswordLength = passwordLength;
            customKeyword = keyword;
            customCode = code;
        }


        public static bool IsNullOrEmpty(char[] array)
        {
            return array == null || !array.Any() || array.Any(c => c == '\u0000' || c == ' ');
        }


        public static char[] WordSplit(string word)
        {
            string[] tempWordArray = word.Split();
            string singleString = string.Join("", tempWordArray);
            char[] singleStringToChars = singleString.ToCharArray();
            return singleStringToChars;
        }

        public void CreateCustomPassword()
        {
            char[] passwordCharacters = new char[PasswordLength];
            int availableOptions = 0;
            int startingIndex = 0;
            int endingIndex = PasswordLength;
            char[] nameCharacters = WordSplit(Name);
            char[] keywordCharacters = WordSplit(Keyword);
            int characterChooser = 0;


            List<string> options = new List<string>
            {
                "randomChar"
            };

            if (Code != null || Code != "")
            {

                char[] codeCharacters = WordSplit(customCode);
                int frontOrBack = rand.Next(0, 2);
                switch (frontOrBack)
                {
                    case 0:
                        for (int i = 0; i < codeCharacters.Length; i++)
                        {
                            passwordCharacters[i] = codeCharacters[i];
                        }
                        startingIndex = codeCharacters.Length;
                        break;
                    case 1:
                        for (int i = 0, codeIndex = passwordCharacters.Length - codeCharacters.Length; i < codeCharacters.Length; i++, codeIndex++)
                        {
                            passwordCharacters[codeIndex] = codeCharacters[i];
                        }
                        endingIndex = passwordCharacters.Length - codeCharacters.Length;
                        break;
                }
            }
            if (!IsNullOrEmpty(nameCharacters))
            {
                availableOptions++;
                options.Add("name");
            }
            if (!IsNullOrEmpty(keywordCharacters))
            {
                availableOptions++;
                options.Add("keyword");

            }

            for (int i = 0; startingIndex < endingIndex; startingIndex++, i++)
            {
                int passwordCharacterChooser = rand.Next(0, availableOptions + 1);
                switch (options[passwordCharacterChooser])
                {
                    case "randomChar":
                        passwordCharacters[startingIndex] = RandomPasswordCreator.GenerateRandomChracter();
                        break;
                    case "name":
                        characterChooser = rand.Next(0, nameCharacters.Length);
                        passwordCharacters[startingIndex] = nameCharacters[characterChooser];
                        break;
                    case "keyword":
                        characterChooser = rand.Next(0, keywordCharacters.Length);
                        passwordCharacters[startingIndex] = keywordCharacters[characterChooser];
                        break;

                }

            }


            Password createdPassword = new Password(Guid.NewGuid(), string.Join("", passwordCharacters), DateTime.Now, PasswordCreatorServices.CurrentUser());
            PasswordCreatorServices.AddPassword(createdPassword);
            DisplayedPassword = createdPassword._password;




        }








    }
}
