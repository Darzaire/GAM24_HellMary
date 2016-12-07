using UnityEngine;
using System.Collections;

public class Materials : MonoBehaviour
{
    public GameObject other;
    
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Toon")
        {
            Destroy(this.gameObject);
        }
    }
}
