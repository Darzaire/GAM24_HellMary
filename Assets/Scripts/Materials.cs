using UnityEngine;
using System.Collections;

public class Materials : MonoBehaviour
{
    public GameObject other;
    public float maxDist = 1;
    public float dist;
    Rigidbody rb;
    public Transform target;
    public Transform myTransform;

    // Use this for initialization
    void Start()
    {
        other = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = other.gameObject.transform.position.x;

        if(dist <= maxDist)
        {
            myTransform.LookAt(target);
            myTransform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
