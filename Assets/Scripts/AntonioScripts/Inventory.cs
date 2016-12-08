using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    //public List<GameObject> Slots = new List<GameObject>();
    //public List<Item> Items = new List<Item>();
    public GameObject slots;
    int x = -240;
    int y = 200;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int k = 0; k < 5; k++)
            {
                GameObject slot = (GameObject)Instantiate(slots);
                //Slots.Add(slot);
                //Items.Add(new Item());
                slots.transform.parent = this.gameObject.transform;
                slot.name = "slot" + i + "." + k;
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
               // x = x + 55;
                //if(k == 5)
               // {
                  //  x = -200;
                  //  y = y - 55;
              //  }
            }
        }
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
