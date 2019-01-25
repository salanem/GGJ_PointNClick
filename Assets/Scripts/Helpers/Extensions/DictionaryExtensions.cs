using System.Collections.Generic;
using NullReferenceException = System.NullReferenceException;

public static class DictionaryExtensions
{
    public static bool AddUnique<K, V>(this Dictionary<K, V> _dictionary, K _keyToAdd, V _valueToAdd)
    {
        if (_dictionary == null)
        {
            throw new NullReferenceException();
        }
        if (_dictionary.ContainsKey(_keyToAdd))
        {
            return false;
        }
        _dictionary.Add(_keyToAdd, _valueToAdd);
        return true;
    }
   
    public static bool AddUnique<K, V>(this Dictionary<K, V> _dictionary, KeyValuePair<K, V> _pair)
    {
        if (_dictionary == null)
        {
            throw new NullReferenceException();
        }
        return _dictionary.AddUnique(_pair.Key, _pair.Value);
    }
}
