﻿using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour
{
    public GameObject prefab;
    public float health = 10;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
       if(health <= 0)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Arm")
        {
            health -= 1;
        }
    }
}
