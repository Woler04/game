using UnityEngine;
using System.Collections;

public class WallDestruction : MonoBehaviour
{
    private void Start()
    {
		StartCoroutine(LateStart(0.01f));
    }

    private void CheckForCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (Collider collider in hitColliders)
        {
			if (collider.CompareTag("DestructableWall") && hitColliders.Length > 1)
            {
                DestroyWall(collider);
            }
        }
    }

    private void DestroyWall(Collider wall)
    {
        wall.gameObject.SetActive(false);
		gameObject.SetActive(false);
    }
	
	IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
		CheckForCollisions();
    }

}