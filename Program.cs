namespace CustomAttribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValidateEmail validateEmail = new ValidateEmail();

            Console.WriteLine("Enter Your Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Your Name: ");
            string name = Console.ReadLine();

            validateEmail.Email = email;

            bool result = validateEmail.EmailValidate();

            if (result)
            {
                Console.WriteLine("Email is valid!");
            }
            else
            {
                Console.WriteLine("Email is not valid");
            }

            VerifyNameLength(name);


            Console.ReadLine();
        }

        [NameLength(2, 10)]
        public static void VerifyNameLength(string name)
        {
            var method = typeof(Program).GetMethod(nameof(VerifyNameLength));

            var attr = (NameLengthAttribute)Attribute.GetCustomAttribute(method, typeof(NameLengthAttribute));

            if (name.Length < attr.MinLength || name.Length > attr.MaxLength)
            {
                Console.WriteLine("Name must have a length between {0} and {1} characters!", attr.MinLength, attr.MaxLength);
            }
            else
            {
                Console.WriteLine("Name is correct!");
            }
        }
    }
}
