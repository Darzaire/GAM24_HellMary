using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
	public enum ItemType {None, Grass, Wood, Stone, Iron, Workbench,
		PickaxeWood, PickaxeStone, PickaxeIron,
		AxeWood, AxeStone, AxeIron,
		SwordWood, SwordStone, SwordIron};

	public ItemType[] itemSlots = new ItemType[12];
	Sprite[] itemSprites = new Sprite[12];
	int[] itemCount = new int[12];

	public Text[] countText = new Text[12];
	Image[] rends = new Image[12];

	public Sprite blank;

	int selected = 0; // which slot is selected
	float[] cursorPoses = new float[12];
	public Sprite hotbarCursor;
	public int current = 0; // what is in that slot. to be read by other scripts.

	void Start()
	{
		// Assign renderers
		for (int r = 0; r < 12; r++)
		{
			rends[r] = transform.GetChild(r).gameObject.GetComponent<Image>();
		}

		// Assign counters
		Transform temp = GameObject.Find("CountTexts").transform;
		for (int t = 0; t < 12; t++)
		{
			countText[t] = temp.GetChild(t).gameObject.GetComponent<Text>();
		}

		for (int s = 0; s < 12; s++)
		{
			itemSlots[s] = ItemType.None;
			rends[s].sprite = blank;
			itemCount[s] = 0;
			countText[s].text = "";
		}
	}

	public void Pickup(int pickup)
	{
		int openslot = 0;
		bool adding = false;
		for (int s = 1; s <= 12; s++)
		{
			if ((int)itemSlots[s] == pickup)
			{
				InvPlus(s);
				adding = true;
				break;
			}
			else if (itemSlots[s] == ItemType.None && openslot == 0)
			{
				openslot = s;
			}
		}
		if (!adding && openslot != 0)
		{
			itemSlots[openslot] = (ItemType)pickup;
			rends[openslot].sprite = itemSprites[pickup];
			itemCount[openslot] = 1;
			countText[openslot].text = itemCount[openslot].ToString();
		}
	}

	void InvPlus(int slot)
	{
		itemCount[slot] += 1;
		countText[slot].text = itemCount[slot].ToString();
	}

	public void Putdown() // starting from 1
	{

	}
}
