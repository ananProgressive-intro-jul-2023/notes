

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }

            if( numbers.Length >= 2 && numbers.Substring(0, 2) == "//")
            {
                char newDelimiter = numbers.ToCharArray()[2];
                var additionalDelimiter = new[] { newDelimiter, '\n' };

                string numbersSub = numbers.Substring(4);
                return numbersSub.Split(additionalDelimiter).Select(int.Parse).Sum();

            }

            var delimiters = new[]{',', '\n'};
      
            return numbers.Split(delimiters).Select(int.Parse).Sum();
        }
            
    }
}
