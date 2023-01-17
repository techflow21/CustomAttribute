using System.Text.RegularExpressions;

namespace CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailPatternAttribute : Attribute
    {
        private string _pattern;

        public EmailPatternAttribute(string pattern)
        {
            _pattern = pattern;
        }

        public bool Validate(string email)
        {
            Regex regex = new Regex(_pattern);
            return regex.IsMatch(email);
        }
    }


    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class NameLengthAttribute : Attribute
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public NameLengthAttribute(int minLength, int maxLength)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }
    }
}
