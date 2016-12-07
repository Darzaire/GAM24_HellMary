using UnityEngine;
using System.Collections;

public class CollectTest : MonoBehaviour
{
    public GameObject material;
    public float playerPosition;
    public float maxDist = 2.0f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerPosition = transform.position.x;
    }

    void OnTriggerEnter(Collider gameObject)
    {
        if(material.gameObject.tag == "Material")
        {
            print("Is Digging");
        }
    }
}
