namespace WebAPI.Services
{
    public class StringProcessorService : IStringProcessorService
    {
        public string ProcessString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            if (input.Length % 2 == 0)
            {
                int mid = input.Length / 2;
                string firstHalf = Reverse(input.Substring(0, mid));
                string secondHalf = Reverse(input.Substring(mid));
                return firstHalf + secondHalf;
            }
            else
            {
                string reversed = Reverse(input);
                return reversed + input;
            }
        }

        private string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
