using UnityEngine;
using RGSMS.SHAKE;

public class ShakeTeste : MonoBehaviour
{
    private ShakesManager.Shake m_shake = null;

	private void Start ()
	{
        m_shake = ShakesManager.Instance.CreateShake(transform.ShakePositionXY(1.0f, 1.0f, 5.0f));
	}
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(!m_shake.running)
            {
                m_shake.Start();
            }
            else
            {
                m_shake.Stop();
            }
        }
    }
}
