using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public Transform target;
    public Transform myTransform;
    void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        myTransform.LookAt(target);
        myTransform.Translate(Vector3.forward * 5 * Time.deltaTime);
	}

   

}
