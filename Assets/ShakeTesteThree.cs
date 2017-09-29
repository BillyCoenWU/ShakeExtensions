using UnityEngine;
using RGSMS.SHAKE;

public class ShakeTesteThree : MonoBehaviour
{
    private Rigidbody2D m_rigidBody2D = null;
    public Rigidbody2D _rigidbody2D
    {
        get
        {
            if(m_rigidBody2D == null)
            {
                m_rigidBody2D = GetComponent<Rigidbody2D>();
            }

            return m_rigidBody2D;
        }
    }

    private ShakesManager.Shake m_shake = null;

    private void Start()
    {
    }

    private void Update()
    {

    }
}
