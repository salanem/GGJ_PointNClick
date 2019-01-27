using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public static PlayerCharacter Get { get; private set; }

    public float m_Speed;
    public FloatRange m_Borders;

    private void Awake()
    {
        if (Get != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Get = this;
        m_sprite = GetComponent<SpriteRenderer>();
    }

    private ClickableObject m_target;
    private Vector3 m_targetPosition;
    private SpriteRenderer m_sprite;
    private bool m_gotInput;

    // Update is called once per frame
    void Update()
    {
        if (!m_gotInput)
        {
            return;
        }
        float dir = m_targetPosition.x - transform.position.x;
        m_sprite.flipX = dir < 0;
        dir = (dir / Mathf.Abs(dir)) * Time.deltaTime * m_Speed;
        transform.position += new Vector3(dir, 0, 0);
        if (transform.position.x < m_Borders.Min)
        {
            transform.position = new Vector3(m_Borders.Min, transform.position.y, transform.position.z);
        }
        if (transform.position.x > m_Borders.Max)
        {
            transform.position = new Vector3(m_Borders.Max, transform.position.y, transform.position.z);
        }
        if (Mathf.Pow(m_targetPosition.x - transform.position.x, 2) < 1.0f)
        {
            m_target?.Interact();
            m_target = null;
            m_gotInput = false;
        }
    }

    public void SetTarget(ClickableObject _target)
    {
        m_target = _target;
        m_targetPosition = _target.transform.position;
        m_gotInput = true;
    }

    public void MoveTo(Vector3 _position)
    {
        m_targetPosition = _position;
        m_gotInput = true;
    }
}
