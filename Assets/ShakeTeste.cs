#region Namespaces
using UnityEngine;
using RGSMS.SHAKE;
#endregion

#region Enums

public enum COMPONENT_TYPE
{
    TRANSFORM = 0,
    RIGIDBODY,
    RIGIDBODY2D,
    RECTTRANSFORM
}

#endregion

public class ShakeTeste : MonoBehaviour
{
    #region Variables

    private ShakesManager.Shake m_shake = null;

    [SerializeField]
    private AXIS m_axis = AXIS.X_Y_Z;

    [SerializeField]
    private SHAKE_TYPE m_type = SHAKE_TYPE.MOVE;

    [SerializeField]
    private COMPONENT_TYPE m_component = COMPONENT_TYPE.TRANSFORM;

    [SerializeField]
    private float m_speed = 1.0f;

    [SerializeField]
    private float m_duration = 1.0f;

    [SerializeField]
    private float m_intesity = 1.0f;

    [SerializeField]
    private Vector3 m_multiIntesity = Vector3.one;

    [SerializeField]
    private bool m_moreThanOneIntensity = false;

    #endregion

    #region Basics_Methods

    private void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (m_shake == null)
            {
                CreateShake();
            }
            else
            {
                if(!m_shake.running)
                {
                    CreateShake();
                }
            }
        }
    }

    private void CreateShake ()
    {
        switch(m_component)
        {
            case COMPONENT_TYPE.TRANSFORM:
                ShakeTransform();
                break;

            case COMPONENT_TYPE.RIGIDBODY:
                ShakeRigidbody();
                break;

            case COMPONENT_TYPE.RIGIDBODY2D:
                ShakeRigidbody2D();
                break;

            case COMPONENT_TYPE.RECTTRANSFORM:
                ShakeRectTransform();
                break;
        }
    }

    #endregion

    #region Transform

    private void ShakeTransform ()
    {
        if(m_type == SHAKE_TYPE.MOVE)
        {
            switch(m_axis)
            {
                default:
                    if (!m_moreThanOneIntensity)
                    {
                        m_shake = ShakesManager.Instance.CreateShake(transform.ShakePosition(m_intesity, m_speed, m_duration));
                    }
                    else
                    {
                        m_shake = ShakesManager.Instance.CreateShake(transform.ShakePosition(m_multiIntesity, m_speed, m_duration));
                    }
                    break;
            }
        }
        else if (m_type == SHAKE_TYPE.SCALE)
        {

        }
        else if (m_type == SHAKE_TYPE.ROTATION)
        {

        }
    }

    #endregion

    #region Rigidbody

    private void ShakeRigidbody()
    {

    }

    #endregion

    #region Rigidboy2D

    private void ShakeRigidbody2D()
    {

    }

    #endregion

    #region RectTransform

    private void ShakeRectTransform()
    {

    }

    #endregion
}
