using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	public GameObject cameraStand;
	Vector3[] directions = { Vector3.forward * 30, Vector3.left * 30, Vector3.right * 30, Vector3.back * 30 };
	public int i = 0;
	
   	void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag("Player"))
		{
			cameraStand.transform.position += directions[i];
		}
	}
}
