using UnityEngine;

namespace TimeUtilities
{
    [System.Serializable]
    public class RepeatingCountdown : Countdown
    {
        public RepeatingCountdown(float _time) : base(_time)
        { }

        public override bool Tick(bool _useUnscaledTime = false)
        {
            if (!m_initialized)
            {
                m_timeLeft = m_time;
                m_initialized = true;
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
                m_timeLeft += m_time;
                return true;
            }
            return false;
        }
    }
}