using System.Collections.Generic;
using NullReferenceException = System.NullReferenceException;

public static class StackExtensions
{
    public static Stack<T> Copy<T>(this Stack<T> _stack)
    {
        if (null == _stack)
        {
            throw new NullReferenceException();
        }
        Stack<T> tmp = new Stack<T>(_stack);
        Stack<T> returnValue = new Stack<T>(tmp);

        return returnValue;
    }
}
