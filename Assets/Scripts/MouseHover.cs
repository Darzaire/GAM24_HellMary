using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour
{
	public Sprite[] itemSprites = new Sprite[12]; // assign it

	public Image sr;

	void Awake()
	{
		sr = gameObject.GetComponent<Image>();
	}

	public void GiveSprite(int _item)
	{
		sr.sprite = itemSprites[_item];
	}

	void Update()
	{
		transform.position = Input.mousePosition;
	}
}
