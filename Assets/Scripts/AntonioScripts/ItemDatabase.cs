using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

	// Use this for initialization
	void Start ()
    {
        items.Add(new Item("wood", 3," blockofWood", 1, Item.ItemType.wood));
        items.Add(new Item("stone", 2, " blockofStone", 1, Item.ItemType.stone));
        items.Add(new Item("dirt", 1, " blockofDirt", 1, Item.ItemType.dirt));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
