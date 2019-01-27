using UnityEngine;

[System.Serializable]
public struct IntRange
{
    public int Min
    {
        get
        {
            return m_min;
        }
    }

  
    public int Max
    {
        get
        {
            return m_max;
        }
    }

    [SerializeField]
    private int m_min;
    [SerializeField]
    private int m_max;

    public IntRange(int _min, int _max)
    {
        m_min = _min;
        m_max = _max;
    }
    public int RandomIntInRange()
    {
        return Random.Range(Min, Max);
    }

    public override bool Equals(object _other)
    {
        if ((_other == null) || !(_other is IntRange))
        {
            return false;
        }
        return this == (IntRange)_other;
    }

    public static bool operator ==(IntRange _left, IntRange _right)
    {
        return Mathf.Approximately(_left.Min, _right.Min)
            && Mathf.Approximately(_left.Max, _right.Max);
    }

    public static bool operator !=(IntRange _left, IntRange _right)
    {
        return !(_left == _right);
    }

    public override int GetHashCode()
    {
        return m_min << 2 ^ m_max << 4;
    }

    public override string ToString()
    {
        return $"[IntRange] from {m_min} to {m_max}";
    }
}
