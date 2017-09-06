using UnityEngine;
using RGSMS.Shake;

public class ShakeWithDistinctIntensity : Shake
{
    public Vector3 intensity = Vector3.one;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShakeThis();
        }
    }

    protected override void ShakeThis()
    {
        if (type == SHAKE_TYPE.POSITION)
        {
            if (axis == AXIS.X_Y_Z)
            {
                StartCoroutine(transform.ShakePosition(intensity, durantion, false));
            }
            else if (axis == AXIS.X)
            {
                StartCoroutine(transform.ShakePositionX(intensity.x, durantion, false));
            }
            else if (axis == AXIS.Y)
            {
                StartCoroutine(transform.ShakePositionY(intensity.y, durantion, false));
            }
            else if (axis == AXIS.Z)
            {
                StartCoroutine(transform.ShakePositionZ(intensity.z, durantion, false));
            }
            else if (axis == AXIS.X_Y)
            {
                StartCoroutine(transform.ShakePositionXY(intensity, durantion, false));
            }
            else if (axis == AXIS.X_Z)
            {
                StartCoroutine(transform.ShakePositionXZ(intensity, durantion, false));
            }
            else if (axis == AXIS.Y_Z)
            {
                StartCoroutine(transform.ShakePositionYZ(intensity, durantion, false));
            }
        }
        else if (type == SHAKE_TYPE.ROTATION)
        {
            if (axis == AXIS.X_Y_Z)
            {
                StartCoroutine(transform.ShakeRotation(intensity, durantion, false));
            }
            else if (axis == AXIS.X)
            {
                StartCoroutine(transform.ShakeRotationX(intensity.x, durantion, false));
            }
            else if (axis == AXIS.Y)
            {
                StartCoroutine(transform.ShakeRotationY(intensity.y, durantion, false));
            }
            else if (axis == AXIS.Z)
            {
                StartCoroutine(transform.ShakeRotationZ(intensity.z, durantion, false));
            }
            else if (axis == AXIS.X_Y)
            {
                StartCoroutine(transform.ShakeRotationXY(intensity, durantion, false));
            }
            else if (axis == AXIS.X_Z)
            {
                StartCoroutine(transform.ShakeRotationXZ(intensity, durantion, false));
            }
            else if (axis == AXIS.Y_Z)
            {
                StartCoroutine(transform.ShakeRotationYZ(intensity, durantion, false));
            }
        }
        else if (type == SHAKE_TYPE.SCALE)
        {
            if (axis == AXIS.X_Y_Z)
            {
                StartCoroutine(transform.ShakeScale(intensity, durantion, false));
            }
            else if (axis == AXIS.X)
            {
                StartCoroutine(transform.ShakeScaleX(intensity.x, durantion, false));
            }
            else if (axis == AXIS.Y)
            {
                StartCoroutine(transform.ShakeScaleY(intensity.y, durantion, false));
            }
            else if (axis == AXIS.Z)
            {
                StartCoroutine(transform.ShakeScaleZ(intensity.z, durantion, false));
            }
            else if (axis == AXIS.X_Y)
            {
                StartCoroutine(transform.ShakeScaleXY(intensity, durantion, false));
            }
            else if (axis == AXIS.X_Z)
            {
                StartCoroutine(transform.ShakeScaleXZ(intensity, durantion, false));
            }
            else if (axis == AXIS.Y_Z)
            {
                StartCoroutine(transform.ShakeScaleYZ(intensity, durantion, false));
            }
        }
        else if (type == SHAKE_TYPE.EU_LER_ANGLES)
        {
            if (axis == AXIS.X_Y_Z)
            {
                StartCoroutine(transform.ShakeEuLerAngles(intensity, durantion, false));
            }
            else if (axis == AXIS.X)
            {
                StartCoroutine(transform.ShakeEuLerAnglesX(intensity.x, durantion, false));
            }
            else if (axis == AXIS.Y)
            {
                StartCoroutine(transform.ShakeEuLerAnglesY(intensity.y, durantion, false));
            }
            else if (axis == AXIS.Z)
            {
                StartCoroutine(transform.ShakeEuLerAnglesZ(intensity.z, durantion, false));
            }
            else if (axis == AXIS.X_Y)
            {
                StartCoroutine(transform.ShakeEuLerAnglesXY(intensity, durantion, false));
            }
            else if (axis == AXIS.X_Z)
            {
                StartCoroutine(transform.ShakeEuLerAnglesXZ(intensity, durantion, false));
            }
            else if (axis == AXIS.Y_Z)
            {
                StartCoroutine(transform.ShakeEuLerAnglesYZ(intensity, durantion, false));
            }
        }
    }
}
