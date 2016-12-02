using UnityEngine;
using System.Collections;

public class CritterMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    float walkTime;

    void NewDirection()
    {
        float temp = Random.Range(0f, 360f);
        transform.eulerAngles = new Vector3(0, temp, 0);

        walkTime = Random.Range(5f, 10f);
    }
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (walkTime > 0)
        {
            walkTime -= Time.deltaTime;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
	}
}
