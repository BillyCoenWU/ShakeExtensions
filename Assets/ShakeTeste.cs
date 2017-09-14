using UnityEngine;
using RGSMS.SHAKE;

public class ShakeTeste : MonoBehaviour
{
    private ShakesManager.Shake m_shake = null;

	private void Start ()
	{
        m_shake = ShakesManager.Instance.CreateShake(transform.ShakePosition(1.0f, 10.0f, false));
        m_shake.Start();
	}
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!m_shake.paused)
            {
                m_shake.Pause();
            }
            else
            {
                m_shake.Resume();
            }
        }
    }
}
