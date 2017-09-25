using System.Linq;

namespace SocialNetwork.Client.Core.Utils
{
    public static class TagTransformer
    {
        public static string Transform(string tag)
        {
            if (tag.Contains(" "))
            {
                tag = tag.Replace(" ", string.Empty);
            }

            if (tag.Any(c => !char.IsLetterOrDigit(c)))
            {
                var specialChars = tag
                    .Where(c => !char.IsLetterOrDigit(c))
                    .Select(c => c.ToString());

                foreach (var ch in specialChars)
                {
                    tag = tag.Replace(ch, string.Empty);
                }
            }

            if (!tag.StartsWith("#"))
            {
                tag = "#" + tag;
            }

            if (tag.Length > 20)
            {
                tag = tag.Substring(0, 20);
            }

            return tag;
        }
    }
}