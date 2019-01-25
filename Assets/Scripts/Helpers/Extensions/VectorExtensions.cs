using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 Clamp(this Vector2 _vector, Vector2 _minValue, Vector2 _maxValue)
    {
        return new Vector2(Mathf.Clamp(_vector.x, _minValue.x, _maxValue.x),
                            Mathf.Clamp(_vector.y, _minValue.y, _maxValue.y));
    }

    public static Vector2 FixIfNaN(this Vector2 _vector)
    {
        Vector2 returnValue = _vector;
        if (float.IsNaN(_vector.x))
        {
            returnValue.x = 0;
        }
        if (float.IsNaN(_vector.y))
        {
            returnValue.y = 0;
        }

        return returnValue;
    }

    public static Vector3 Clamp(this Vector3 _vector, Vector3 _minValue, Vector3 _maxValue)
    {
        return new Vector3(Mathf.Clamp(_vector.x, _minValue.x, _maxValue.x),
                            Mathf.Clamp(_vector.y, _minValue.y, _maxValue.y),
                            Mathf.Clamp(_vector.z, _minValue.z, _maxValue.z));
    }

    public static Vector3 FixIfNaN(this Vector3 _vector)
    {
        Vector3 returnValue = _vector;
        if (float.IsNaN(_vector.x))
        {
            returnValue.x = 0;
        }
        if (float.IsNaN(_vector.y))
        {
            returnValue.y = 0;
        }
        if (float.IsNaN(_vector.z))
        {
            returnValue.z = 0;
        }

        return returnValue;
    }

    public static Vector4 Clamp(this Vector4 _vector, Vector4 _minValue, Vector4 _maxValue)
    {
        return new Vector4(Mathf.Clamp(_vector.x, _minValue.x, _maxValue.x),
                            Mathf.Clamp(_vector.y, _minValue.y, _maxValue.y),
                            Mathf.Clamp(_vector.z, _minValue.z, _maxValue.z),
                            Mathf.Clamp(_vector.w, _minValue.w, _maxValue.w));
    }

    public static Vector4 FixIfNaN(this Vector4 _vector)
    {
        Vector4 returnValue = _vector;
        if (float.IsNaN(_vector.x))
        {
            returnValue.x = 0;
        }
        if (float.IsNaN(_vector.y))
        {
            returnValue.y = 0;
        }
        if (float.IsNaN(_vector.z))
        {
            returnValue.z = 0;
        }
        if (float.IsNaN(_vector.w))
        {
            returnValue.w = 0;
        }

        return returnValue;
    }
}
