using System.Collections.Generic;
using UnityEngine;
using NullReferenceException = System.NullReferenceException;

public static class MonoBehaviourExtensions
{
    public static T GetComponentInParentOnly<T>(this MonoBehaviour _component)
    {
        if (_component == null)
        {
            throw new NullReferenceException();
        }
        if (_component.transform.parent == null)
        {
            throw new NullReferenceException();
        }
        return _component.transform.parent.GetComponent<T>();
    }

    public static T[] GetComponentsInParentOnly<T>(this MonoBehaviour _component)
    {
        if (_component == null)
        {
            throw new NullReferenceException();
        }
        if (_component.transform.parent == null)
        {
            throw new NullReferenceException();
        }
        return _component.transform.parent.GetComponents<T>();
    }

    public static T GetComponentInChildrenOnly<T>(this MonoBehaviour _component)
    {
        if (_component == null)
        {
            throw new NullReferenceException();
        }
        int childCount = _component.transform.childCount;
        T foundComponent;
        for (int i = 0; i < childCount; i++)
        {
            foundComponent = _component.transform.GetChild(i).GetComponent<T>();
            if (foundComponent != null)
            {
                return foundComponent;
            }
        }
        return default;
    }

    public static T[] GetComponentsInChildrenOnly<T>(this MonoBehaviour _component)
    {
        if (_component == null)
        {
            throw new NullReferenceException();
        }
        int childCount = _component.transform.childCount;
        List<T> foundComponents = new List<T>();
        for (int i = 0; i < childCount; i++)
        {
            foundComponents.AddRange(_component.transform.GetChild(i).GetComponents<T>());
        }
        if (foundComponents.Count == 0)
        {
            return null;
        }
        return foundComponents.ToArray();
    }
}
