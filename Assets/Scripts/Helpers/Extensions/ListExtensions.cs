using System.Collections.Generic;
using NullReferenceException = System.NullReferenceException;

public static class ListExtensions
{
    public static bool AddUnique<T>(this List<T> _list, T _element)
    {
        if (_list == null)
        {
            throw new NullReferenceException();
        }
        if (_list.Contains(_element))
        {
            return false;
        }
        _list.Add(_element);
        return true;
    }

    public static T At<T>(this List<T> _list, int _index)
    {
        if (_list == null)
        {
            throw new NullReferenceException();
        }
        int index = _index;
        if (_index < 0)
        {
            index = _list.Count + _index;
        }
        if (_list.Count <= _index)
        {
            throw new System.IndexOutOfRangeException();
        }
        return _list[index];
    }

    public static T Last<T>(this List<T> _list)
    {
        if (_list == null)
        {
            throw new NullReferenceException();
        }
        if (_list.Count == 0)
        {
            return default(T);
        }
        return _list[_list.Count - 1];
    }

    public static T Random<T>(this List<T> _list)
    {
        if (_list == null)
        {
            throw new NullReferenceException();
        }
        if (_list.Count == 0)
        {
            return default;
        }
        return _list[UnityEngine.Random.Range(0, _list.Count)];
    }
}
