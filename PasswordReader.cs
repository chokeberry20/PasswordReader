using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace PassswordReader
{
    public class PassswordReader
    {
        public List<string> Read(string path)
        {
            var validPasswords = new List<string>();

            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int bottomBorder = Convert.ToInt32(line[2].ToString());
                    int topBorder = Convert.ToInt32(line[4].ToString());

                    char targetElement = line[0];

                    string password = line.Substring(7);

                    if(PasswordValidationCheck(bottomBorder, topBorder, password, targetElement))
                    {
                        validPasswords.Add(password);
                    }
                }
            }
            return validPasswords;
        }

        public bool PasswordValidationCheck(int bottomBorder, int topBorder, string password, char targetElement)
        {
            string pattern = Regex.Escape(targetElement.ToString());
            int count = Regex.Matches(password, pattern).Count;

            if (count >= bottomBorder && count <= topBorder) 
                return true;

            return false;
        }
    }
}