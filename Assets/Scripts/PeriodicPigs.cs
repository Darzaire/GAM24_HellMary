using UnityEngine;
using System.Collections;

public class PeriodicPigs : MonoBehaviour
{
	public float timeToSpawn = 30;
	public float timer;

	public GameObject pig;

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= timeToSpawn)
		{
			timer = 0;
			Instantiate(pig, new Vector3(8.8f+Random.Range(-5f,5f), 6.9f, 7.3f+Random.Range(-5f,5f)), Quaternion.identity);
		}
	}
}
