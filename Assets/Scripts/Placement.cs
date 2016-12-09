using UnityEngine;
using System.Collections;

public class Placement : MonoBehaviour
{
	public Hotbar hb;

	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			if (hb.Current() == 15) hb.Eat();
			else if (hb.Current() > 0 && hb.Current() <= 5)
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position, this.transform.forward, out hit))
				{
					print ("raycast hit");
					if (hit.transform.gameObject.tag == "Block")
					{
						print ("got a block");
						bool _temp = false;
						if (hit.transform.gameObject.name == "Workbench(Clone)") _temp = true;
						print (_temp);
						hit.transform.gameObject.GetComponent<Blocks>().PlaceBlock(hit.point, hb.Current(), _temp);
						
					}
				}
			}
		}
	}
}
