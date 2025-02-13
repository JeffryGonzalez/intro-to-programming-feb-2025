
public class Calculator
{
  public int Add(string numbers)
  {
    if (numbers == "")
    {
      return 0;
    }

    return numbers.Split(',', '\n').Select(int.Parse).Sum();

   // var splitnumbers = numbers.Split(',', '\n');
   // var numbersConverted = splitnumbers.Select(int.Parse);
   //// splitnumbers[0] = "999";
   // var sum = numbersConverted.Sum();
   // return sum;

    //if (numbers.Contains(','))
    //{
    //  var commaAt = numbers.IndexOf(',');
    //  var firstPart = numbers[..commaAt];
    //  var secondPart = numbers[(commaAt + 1)..];

    //  return int.Parse(firstPart) + int.Parse(secondPart);
    //}
   
   
  }
}
