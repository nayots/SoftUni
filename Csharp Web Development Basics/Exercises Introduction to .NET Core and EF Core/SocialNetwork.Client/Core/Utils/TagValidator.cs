using System.Text.RegularExpressions;

namespace SocialNetwork.Client.Core.Utils
{
    public static class TagValidator
    {
        public static bool ValidateTag(string tag)
        {
            string pattern = @"^#([a-zA-Z0-9]{1,19})$";

            Regex rgx = new Regex(pattern);

            if (rgx.IsMatch(tag))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}