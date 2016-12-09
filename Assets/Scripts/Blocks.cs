using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour
{
    public FPSController arm;
    public GameObject prefab;
    public float health = 10;

    public GameObject[] blocksToPlace;
    public CraftMaster cm;

    void Awake()
    {
        arm = GameObject.Find("Toon").GetComponent<FPSController>();
        cm = GameObject.Find("CraftMenus").GetComponent<CraftMaster>();
    }

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
        if(arm.isActive && other.gameObject.name == "Arm")
        {
            health -= 1;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (!arm.isActive && other.gameObject.name == "Arm")
        {
            health = 10;
        }
    }

    public void PlaceBlock(Vector3 _point, int _cur, bool bench)
    {
        print ("PlaceBlock()");
        if (bench)
        {
            cm.Menu(true);
            print("workbench");
            //return false;
        }
        else 
        {
            print ("but");
            if ((_point.y - transform.position.y) > .48f) // top
            {
                //return true;
                Instantiate(blocksToPlace[_cur], new Vector3(transform.position.x,transform.position.y+1,transform.position.z), Quaternion.identity);
                print ("placing up");
            }
            else if ((_point.y - transform.position.y) < -.48f) // bot
            {
                //return true;
                Instantiate(blocksToPlace[_cur], new Vector3(transform.position.x,transform.position.y-1,transform.position.z), Quaternion.identity);
                print ("placing down");
            }
            else if ((_point.x - transform.position.x) < -.48f) // left
            {
                //return true;
                Instantiate(blocksToPlace[_cur], new Vector3(transform.position.x-1,transform.position.y,transform.position.z), Quaternion.identity);
                print ("placing left");
            }
            else if ((_point.x - transform.position.x) > .48f) // right
            {
                //return true;
                Instantiate(blocksToPlace[_cur], new Vector3(transform.position.x+1,transform.position.y,transform.position.z), Quaternion.identity);
                print ("placing right");
            }
            else if ((_point.z - transform.position.z) < -.48f) // back
            {
                //return true;
                Instantiate(blocksToPlace[_cur], new Vector3(transform.position.x,transform.position.y,transform.position.z-1), Quaternion.identity);
                print ("placing back");
            }
            else if ((_point.z - transform.position.z) > .48f) // front
            {
                //return true;
                Instantiate(blocksToPlace[_cur], new Vector3(transform.position.x,transform.position.y,transform.position.z+1), Quaternion.identity);
                print ("placing front");
            }
            //else return false;
        }
    }
}
