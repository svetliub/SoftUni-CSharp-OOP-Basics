using System;

public class DataValidator
{
    public static void ValidateName(string value)
    {
        if (string.IsNullOrEmpty(value.Trim()))
        {
            throw new ArgumentException("A name should not be empty.");
        }
    }
}