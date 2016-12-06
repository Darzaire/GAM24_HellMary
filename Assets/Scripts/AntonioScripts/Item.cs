using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public string itemName;
    public int itemID;
    public string itemDesc;
    public Sprite itemIcon;
    public GameObject itemModel;
    public int itemValue;
    public ItemType itemType;

    public enum ItemType
    {
        dirt,
        stone,
        wood,
        pickax,
        ax,
        sword,
        meat
    }

    public Item(string name, int id, string desc, int value, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemValue = value;
        itemType = type;
        itemIcon = Resources.Load<Sprite>("" + name);
    }

    public Item()
    {

    }
}
