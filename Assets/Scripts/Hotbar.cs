using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
	enum ItemType {None, Grass, Wood, Stone, Iron, Meat, Workbench,
		PickaxeWood, PickaxeStone, PickaxeIron,
		AxeWood, AxeStone, AxeIron,
		SwordWood, SwordStone, SwordIron};

	ItemType[] itemSlots = new ItemType[12];
	public Sprite[] itemSprites = new Sprite[12];
	int[] itemCount = new int[12];

	Text[] countText = new Text[12];
	Image[] rends = new Image[12];

	public Sprite blank;

	int selected = 0; // which slot is selected
	float[] cursorPoses = new float[12];
	public Transform hotbarCursor;

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

		// Finds cursor positions
		int _index = 0;
		foreach (Transform child in transform)
		{
			cursorPoses[_index] = child.position.x;
			_index++;
		}

		// Initialize
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
		int openslot = 0; // 0 if no slots open
		bool adding = false;

		// first check if we already have one of those
		for (int s = 0; s < 12; s++)
		{
			print ((int)itemSlots[s]);
			if ((int)itemSlots[s] == pickup) // if so, add one
			{
				itemCount[s] += 1;
				countText[s].text = itemCount[s].ToString();
				adding = true;
				break;
			}
			else if (itemSlots[s] == ItemType.None && openslot == 0) // grabs the first empty slot
			{
				openslot = s;
			}
		}
		if (!adding && openslot != 0) // if we don't have one, put one in the first empty slot
		{
			itemSlots[openslot] = (ItemType)pickup;
			rends[openslot].sprite = itemSprites[pickup];
			itemCount[openslot] = 1;
			countText[openslot].text = itemCount[openslot].ToString();
		}
	}

	public void Putdown() 
	{
		itemCount[selected] -= 1;
		countText[selected].text = itemCount[selected].ToString();

		if (itemCount[selected] <= 0)
		{
			itemCount[selected] = 0; // catches errors. just in case.
			countText[selected].text = "";
			itemSlots[selected] = ItemType.None;
			rends[selected].sprite = itemSprites[0];
		}
	}

	public int Current()
	{
		return (int)itemSlots[selected];
	}

	void Update()
	{
		// hitting numbers to select
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			selected = 0;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			selected = 1;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			selected = 2;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			selected = 3;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			selected = 4;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}
		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			selected = 5;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}
		if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			selected = 6;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}
		if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			selected = 7;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}
		if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			selected = 8;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}
		if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			selected = 9;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			selected = 10;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			selected = 11;
			hotbarCursor.position = new Vector2 (cursorPoses[selected],25.5f);
		}

		// for testing purposes
		if (Input.GetKeyDown(KeyCode.P))
		{
			Pickup(2);
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			Pickup(5);
		}
	}
}
