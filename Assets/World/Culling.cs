using UnityEngine;
using System.Collections;

public class Culling : MonoBehaviour
{
	public float drawDist = 50;

	Transform cam = Camera.main.transform;
	Renderer rend;

	void Awake()
	{
		rend = gameObject.GetComponent<Renderer>();
	}

	void Update()
	{
		RaycastHit[] hits = Physics.RaycastAll(transform.position, cam.transform.position-transform.position, drawDist);
		{
			if (hits.Length > 1)
			{
				if (hits[0].transform == cam || hits[1].transform == cam)
					rend.enabled = true;
				else 
					rend.enabled = false;
			}
			else if (hits.Length == 1)
			{
				rend.enabled = true;
			}
			else 
				rend.enabled = false;
		}
	}
}
