using UnityEngine;

public class RandomInsideCircleTeste : MonoBehaviour
{
    private void Update ()
    {
		if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(Random.insideUnitCircle);
        }
	}
}
