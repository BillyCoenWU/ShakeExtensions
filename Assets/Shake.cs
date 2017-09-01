using UnityEngine;
using RGSMS.Shake;

public class Shake : MonoBehaviour
{
	private void Start ()
	{
        StartCoroutine(transform.ShakePosition(0.25f, 2.0f, false));
	}
	
	private void Update ()
	{
		
	}
}
