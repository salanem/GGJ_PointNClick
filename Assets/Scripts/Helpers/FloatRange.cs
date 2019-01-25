using UnityEngine;

[System.Serializable]
public struct FloatRange
{
    public float Min
    {
        get
        {
            return m_min;
        }
    }

    public float Max
    {
        get
        {
            return m_max;
        }
    }

    [SerializeField]
    private float m_min;
    [SerializeField]
    private float m_max;

    public FloatRange(float _min, float _max)
    {
        m_min = _min;
        m_max = _max;
    }

    public float RandomFloatInRange()
    {
        return Random.Range(Min, Max);
    }

    public override bool Equals(object _other)
    {
        if ((_other == null) || !(_other is FloatRange))
        {
            return false;
        }
        return this == (FloatRange)_other;
    }

    public static bool operator ==(FloatRange _left, FloatRange _right)
    {
        return Mathf.Approximately(_left.Min, _right.Min)
            && Mathf.Approximately(_left.Max, _right.Max);
    }

    public static bool operator !=(FloatRange _left, FloatRange _right)
    {
        return !(_left == _right);
    }

    public override int GetHashCode()
    {
        return m_min.GetHashCode() << 2 ^ m_max.GetHashCode() << 4;
    }

    public override string ToString()
    {
        return $"[FloatRange] from {m_min} to {m_max}";
    }
}
