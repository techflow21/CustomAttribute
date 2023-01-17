namespace CustomAttribute
{
    public class ValidateEmail
    {
        [EmailPattern(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }

        public bool EmailValidate()
        {
            EmailPatternAttribute attr = (EmailPatternAttribute) Attribute.GetCustomAttribute(GetType().GetProperty("Email"), typeof(EmailPatternAttribute));
            bool result = attr.Validate(Email);

            return result;
        }
    }
}
