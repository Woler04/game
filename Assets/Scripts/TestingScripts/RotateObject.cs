using UnityEngine;

public class RotateObject : MonoBehaviour
{
	public float speed;
	
    void FixedUpdate()
	{
		transform.Rotate(0f, speed * Time.fixedDeltaTime, 0.0f, Space.Self);
	}
}
