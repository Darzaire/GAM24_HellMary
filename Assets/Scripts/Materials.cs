using UnityEngine;
using System.Collections;

public class Materials : MonoBehaviour
{
    public GameObject other;

    public float dist;
    public float maxDist = 2.0f;
    public bool isNear = false;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider gameObject)
    {
        if(other.name == "Toon")
        {
            Destroy(this.gameObject);
        }
    }
}
