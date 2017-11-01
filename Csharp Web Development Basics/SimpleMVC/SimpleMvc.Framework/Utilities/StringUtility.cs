namespace SimpleMvc.Framework.Utilities
{
    using System.Text;

    public static class StringUtility
    {
        public static string Capitalize(string text)
        {
            StringBuilder result = new StringBuilder();

            if (!string.IsNullOrEmpty(text))
            {

                result.Append(char.ToUpper(text[0]));

                for (int i = 1; i < text.Length; i++)
                {
                    result.Append(char.ToLower(text[i]));
                }

            }

            return result.ToString();
        }
    }
}
