public static class StringExtensions
{
    public static string ConvertSnakeCaseToCamelCase(this string _string)
    {
        if (string.IsNullOrWhiteSpace(_string))
        {
            return _string;
        }
        string returnValue = "";
        bool upper = true;
        string inputString = _string.Trim().Trim('_');
        for (int i = 0; i < inputString.Length; i++)
        {
            if (inputString[i] == '_')
            {
                upper = true;
                continue;
            }
            if (upper)
            {
                returnValue += char.ToUpper(inputString[i]);
                upper = false;
            }
            else
            {
                returnValue += char.ToLower(inputString[i]);
            }
        }
        return returnValue;
    }

    public static char Last(this string _string)
    {
        if (string.IsNullOrEmpty(_string))
        {
            return default;
        }
        return _string[_string.Length - 1];
    }
}
