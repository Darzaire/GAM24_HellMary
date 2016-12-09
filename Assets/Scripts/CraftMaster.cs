using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CraftMaster : MonoBehaviour
{
	public CraftBox[] hotbarBoxes;
	public CraftBox[] playerCraftBoxes;
	public CraftBox[] workbenchCraftBoxes;
	public CraftBox resultBox;

	public GameObject playerUI;
	public GameObject workbenchUI;
	public GameObject resultUI;
	public MouseHover mouseHover;
	public int current = 0;

	public int menu = 0; // 0 - no menu / 1 - player crafting / 2 - workbench crafting //

	public Hotbar hbCont;

	void Update()
	{
		// keybinding: open craft menu
		if (Input.GetKeyDown(KeyCode.Tab))		 Menu(false);
		if (Input.GetKeyDown(KeyCode.BackQuote)) Menu(true);

		// keybinding: hotbar
		if (Input.GetKeyDown(KeyCode.U))		 HotbarClick(hotbarBoxes[0], (int)hbCont.itemSlots[0]);
		if (Input.GetKeyDown(KeyCode.I))		 HotbarClick(hotbarBoxes[1], (int)hbCont.itemSlots[1]);
		if (Input.GetKeyDown(KeyCode.O))		 HotbarClick(hotbarBoxes[2], (int)hbCont.itemSlots[2]);
		if (Input.GetKeyDown(KeyCode.P))		 HotbarClick(hotbarBoxes[3], (int)hbCont.itemSlots[3]);
		if (Input.GetKeyDown(KeyCode.J))		 HotbarClick(hotbarBoxes[4], (int)hbCont.itemSlots[4]);
		if (Input.GetKeyDown(KeyCode.K))		 HotbarClick(hotbarBoxes[5], (int)hbCont.itemSlots[5]);
		if (Input.GetKeyDown(KeyCode.L))		 HotbarClick(hotbarBoxes[6], (int)hbCont.itemSlots[6]);
		if (Input.GetKeyDown(KeyCode.Semicolon)) HotbarClick(hotbarBoxes[7], (int)hbCont.itemSlots[7]);
		if (Input.GetKeyDown(KeyCode.M))		 HotbarClick(hotbarBoxes[8], (int)hbCont.itemSlots[8]);
		if (Input.GetKeyDown(KeyCode.Comma))	 HotbarClick(hotbarBoxes[9], (int)hbCont.itemSlots[9]);
		if (Input.GetKeyDown(KeyCode.Period))	 HotbarClick(hotbarBoxes[10], (int)hbCont.itemSlots[10]);
		if (Input.GetKeyDown(KeyCode.Slash))	 HotbarClick(hotbarBoxes[11], (int)hbCont.itemSlots[11]);

		// keybinding: player craft (2x2)
		if (menu == 1)
		{
			if (Input.GetKeyDown(KeyCode.Keypad7)) RecipeClick(playerCraftBoxes[0]);
			if (Input.GetKeyDown(KeyCode.Keypad8)) RecipeClick(playerCraftBoxes[1]);
			if (Input.GetKeyDown(KeyCode.Keypad4)) RecipeClick(playerCraftBoxes[2]);
			if (Input.GetKeyDown(KeyCode.Keypad5)) RecipeClick(playerCraftBoxes[3]);

			if (Input.GetKeyDown(KeyCode.KeypadPlus)) ResultClick();
		}

		// keybinding: workbench craft (3x3)
		else if (menu == 2)
		{
			if (Input.GetKeyDown(KeyCode.Keypad7)) RecipeClick(workbenchCraftBoxes[0]);
			if (Input.GetKeyDown(KeyCode.Keypad8)) RecipeClick(workbenchCraftBoxes[1]);
			if (Input.GetKeyDown(KeyCode.Keypad9)) RecipeClick(workbenchCraftBoxes[2]);
			if (Input.GetKeyDown(KeyCode.Keypad4)) RecipeClick(workbenchCraftBoxes[3]);
			if (Input.GetKeyDown(KeyCode.Keypad5)) RecipeClick(workbenchCraftBoxes[4]);
			if (Input.GetKeyDown(KeyCode.Keypad6)) RecipeClick(workbenchCraftBoxes[5]);
			if (Input.GetKeyDown(KeyCode.Keypad1)) RecipeClick(workbenchCraftBoxes[6]);
			if (Input.GetKeyDown(KeyCode.Keypad2)) RecipeClick(workbenchCraftBoxes[7]);
			if (Input.GetKeyDown(KeyCode.Keypad3)) RecipeClick(workbenchCraftBoxes[8]);

			if (Input.GetKeyDown(KeyCode.KeypadPlus)) ResultClick();
		}
	}

	void Menu(bool bench)
	{
		if (bench) menu = 2;
		else 
		{
			if (menu == 0)	menu = 1;
			else menu = 0;
		}

		switch (menu) {
			case (0): // turn menu off
				playerUI.SetActive(false);
				workbenchUI.SetActive(false);
				resultUI.SetActive(false);
				foreach (CraftBox cb in hotbarBoxes) {cb.gameObject.SetActive(false);}
				//foreach (CraftBox cb in playerCraftBoxes) {cb.gameObject.SetActive(false);}
				//foreach (CraftBox cb in workbenchCraftBoxes) {cb.gameObject.SetActive(false);}
				resultBox.gameObject.SetActive(false);
				break;
			case (1): // turn on player menu
				playerUI.SetActive(true);
				resultUI.SetActive(true);
				foreach (CraftBox cb in hotbarBoxes) {cb.gameObject.SetActive(true);}
				//foreach (CraftBox cb in playerCraftBoxes) {cb.gameObject.SetActive(true);}
				resultBox.gameObject.SetActive(true);
				break;
			case (2): // turn on workbench menu
				workbenchUI.SetActive(true);
				resultUI.SetActive(true);
				foreach (CraftBox cb in hotbarBoxes) {cb.gameObject.SetActive(true);}
				//foreach (CraftBox cb in workbenchCraftBoxes) {cb.gameObject.SetActive(true);}
				resultBox.gameObject.SetActive(true);
				break;
			default:
				print ("invalid menu");
				break; }
	}

	public void HotbarClick(CraftBox cb, int _item)
	{
		int clickedSlot = 0;
		for (int c = 0; c < 12; c++)
		{
			if (cb == hotbarBoxes[c])
			{
				clickedSlot = c;
				break;
			}
		}

		if (current == 0) // picking up
		{
			current = hbCont.CraftingPickup(clickedSlot);
			//mouseHover.gameObject.SetActive(true);
			mouseHover.GiveSprite(current);
		}
		else // dropping off
		{
			hbCont.Pickup(current);
			current = 0;
			mouseHover.GiveSprite(current);
		}
	}

	public void RecipeClick(CraftBox cb)
	{
		//print (cb.gameObject.name);
		//print (_item);
		if (current == 0) // picking up
		{
			current = cb.thisItem;
			cb.gameObject.GetComponent<Image>().sprite = mouseHover.sr.sprite;
			mouseHover.GiveSprite(cb.thisItem);
			cb.thisItem = 0;
		}
		else // dropping off
		{
			cb.thisItem = current;
			cb.gameObject.GetComponent<Image>().sprite = mouseHover.sr.sprite;
			mouseHover.GiveSprite(0);
			current = 0;
		}
	}

	public void ResultClick()
	{
		if (resultBox.thisItem != 0 && current == 0)
		{
			for (int p = 0; p < 4; p++)
			{
				workbenchCraftBoxes[p].sr.sprite = mouseHover.sr.sprite;
				workbenchCraftBoxes[p].thisItem = 0;
			}
			for (int w = 0; w < 9; w++)
			{
				workbenchCraftBoxes[w].sr.sprite = mouseHover.sr.sprite;
				workbenchCraftBoxes[w].thisItem = 0;
			}
			
			current = resultBox.thisItem;
			resultBox.gameObject.GetComponent<Image>().sprite = mouseHover.sr.sprite;
			resultBox.thisItem = 0;
			mouseHover.GiveSprite(current);
		}
	}
}
