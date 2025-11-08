public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // create an array to hold the multiples. 
        double[] result = new double[length];
        
        // loop through each position in the array.
        for (int i = 0; i < length; i++)
        {

        // calculate the multiple by multiplying the number by (index + 1).
        //store the multiple in the current position of the array.
            result[i] = number * (i + 1);
        }

        // return the array.
        return result; 
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // handle small or empty lists.
        if (data.Count == 0 || data.Count ==1) return;

        // normalize the amount incase its equalto or larger than list size.
        amount = amount % data.Count;

        // if amount is 0, no rotation needed.
        if (amount == 0) return;

        // get the last amount of items from tail of the list.
        List<int> tailItems = data.GetRange(data.Count - amount, amount);

        // get the remaining items at the head of the list.
        List<int> headItems = data.GetRange(0, data.Count - amount);

        // clear original list and rebuild it in rotated order.
        data.Clear();
        data.AddRange(tailItems);
        data.AddRange(headItems);

    }
}
