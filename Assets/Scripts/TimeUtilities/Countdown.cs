using UnityEngine;

namespace TimeUtilities
{
    [System.Serializable]
    public class Countdown
    {
        [SerializeField]
        protected float m_time;
        protected float m_timeLeft;
        protected bool m_elapsed = false;
        protected bool m_initialized = false;

        public Countdown(float _time)
        {
            m_time = _time;
            m_timeLeft = m_time;
            m_elapsed = false;
            m_initialized = true;
        }

        public virtual void Reset()
        {
            m_elapsed = false;
            m_timeLeft = m_time;
        }

        public virtual bool Tick(bool _useUnscaledTime = false)
        {
            if (!m_initialized)
            {
                m_timeLeft = m_time;
                m_initialized = true;
            }
            if (m_elapsed)
            {
                return false;
            }
            if (_useUnscaledTime)
            {
                if (Time.timeScale > 0)
                {
                    m_timeLeft -= Time.deltaTime / Time.timeScale;
                }
                else
                {
                    m_timeLeft -= Time.unscaledDeltaTime;
                }
            }
            else
            {
                m_timeLeft -= Time.deltaTime;
            }
            if (m_timeLeft < 0)
            {
                m_elapsed = true;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"[Countdown] {m_timeLeft}/{m_time}";
        }
    }
}