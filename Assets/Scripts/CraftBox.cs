using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftBox : MonoBehaviour
{
	public enum ClickType{Hotbar, Recipe, Result};

	public ClickType boxType; // just assign it in the inspector
	public CraftMaster cm;

	public int thisItem = 0;
	public Sprite[] resultSprites;

	public Image sr;

	void Awake()
	{
		sr = gameObject.GetComponent<Image>();
	}

	void OnMouseDown()
	{
		print ("mousedown");
		switch(boxType) {
			case (ClickType.Hotbar):
				cm.HotbarClick(this, thisItem);
				break;
			case (ClickType.Recipe):
				cm.RecipeClick(this);
				break;
			case (ClickType.Result):
				cm.ResultClick();
				break;
			default:
				print ("invalid boxType");
				break; }
	}

	public void ResultPreview(int _item)
	{
		thisItem = _item;
		sr.sprite = resultSprites[_item];
	}
}
