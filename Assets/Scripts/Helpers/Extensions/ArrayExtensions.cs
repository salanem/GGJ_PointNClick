using NullReferenceException = System.NullReferenceException;
using IndexOutOfRangeException = System.IndexOutOfRangeException;

public static class ArrayExtensions
{
    public static T At<T>(this T[] _array, int _index)
    {
        if (_array == null)
        {
            throw new NullReferenceException();
        }
        int index = _index;
        if (_index < 0)
        {
            index = _array.Length + _index;
        }
        if (_array.Length <= _index)
        {
            throw new IndexOutOfRangeException();
        }
        return _array[index];
    }

    public static T Last<T>(this T[] _array)
    {
        if (_array == null)
        {
            throw new NullReferenceException();
        }
        if (_array.Length == 0)
        {
            throw new IndexOutOfRangeException();
        }
        return _array[_array.Length - 1];
    }

    public static T[] Cut<T>(this T[] _array, int _length)
    {
        if (_array == null)
        {
            throw new NullReferenceException();
        }

        T[] returnValue = new T[_length];
        for (int i = 0; i < _length; i++)
        {
            returnValue[i] = _array[i];
        }

        return returnValue;
    }

    public static T[] Cut<T>(this T[] _array, int _start, int _length)
    {
        if (_array == null)
        {
            throw new NullReferenceException();
        }

        T[] returnValue = new T[_length];
        for (int i = 0; i < _length; i++)
        {
            returnValue[i] = _array[i + _start];
        }

        return returnValue;
    }

    public static T Random<T>(this T[] _array)
    {
        if (_array == null)
        {
            throw new NullReferenceException();
        }
        if (_array.Length == 0)
        {
            return default;
        }
        return _array[UnityEngine.Random.Range(0, _array.Length)];
    }
}
