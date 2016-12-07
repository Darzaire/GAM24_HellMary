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
		//transform.position = Vector3 (x, 0f, y);
       myTransform.LookAt(target);
       myTransform.Translate(Vector3.forward * 2 * Time.deltaTime);

	}


   

}
