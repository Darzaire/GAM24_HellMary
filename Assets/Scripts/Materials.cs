using UnityEngine;
using System.Collections;

public class Materials : MonoBehaviour
{
    public GameObject other;
    public Transform target;
    public Transform myTransform;
    Rigidbody rb;

    public float dist;
    public float maxDist = 2.0f;

    public bool isNear;

    // Use this for initialization
    void Start()
    {
        other = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        target = other.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (other != null)
        {
            dist = Vector3.Distance(other.transform.position, transform.position);
            DistanceReader();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    void DistanceReader()
    {
        if (dist <= maxDist)
        {
            isNear = true;
            if (isNear)
            {
                myTransform.LookAt(target);
                myTransform.Translate(Vector3.forward * 2 * Time.deltaTime);
            }
        }
        else if (dist > maxDist)
        {
            isNear = false;
            if (!isNear)
            {
                
            }
        }
    }
}
