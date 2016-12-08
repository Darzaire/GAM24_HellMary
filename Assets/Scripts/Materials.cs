using UnityEngine;
using System.Collections;

public class Materials : MonoBehaviour
{
    public GameObject other;
    
    // Use this for initialization
    void Start()
    {
        other = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
