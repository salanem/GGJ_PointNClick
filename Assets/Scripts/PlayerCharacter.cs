using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public static PlayerCharacter Get { get; private set; }

    public float m_Speed;

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
    private SpriteRenderer m_sprite;

    // Update is called once per frame
    void Update()
    {
        if (m_target == null)
        {
            return;
        }
        float dir = m_target.transform.position.x - transform.position.x;
        m_sprite.flipX = dir < 0;
        dir = (dir / Mathf.Abs(dir)) * Time.deltaTime * m_Speed;
        transform.position += new Vector3(dir, 0, 0);

        if (Mathf.Pow(m_target.transform.position.x - transform.position.x, 2) < 1.0f)
        {
            m_target.Interact();
            m_target = null;
        }
    }

    public void SetTarget(ClickableObject _target)
    {
        m_target = _target;
    }
}
