using UnityEngine;
using RGSMS.Shake;

public enum SHAKE_TYPE
{
    POSITION = 0,
    ROTATION,
    SCALE,
    EU_LER_ANGLES
}

public abstract class Shake : MonoBehaviour
{
    public float durantion = 1.0f;

    public AXIS axis = AXIS.X_Y_Z;

    public SHAKE_TYPE type = SHAKE_TYPE.POSITION;

    protected abstract void ShakeThis();
}
