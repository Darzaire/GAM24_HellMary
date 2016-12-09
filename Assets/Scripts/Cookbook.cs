using UnityEngine;
using System.Collections;

public class Cookbook : MonoBehaviour
{
	public bool workbench = false;

	public CraftBox resultBox;

	int[] curr;
	CraftBox[] boxes;

	void Start()
	{
		if (!workbench)
		{
			boxes = new CraftBox[4];
			curr = new int[4];
			for (int p = 0; p < 4; p++)
			{
				boxes[p] = transform.GetChild(p).gameObject.GetComponent<CraftBox>();
			}
		}
		else 
		{
			boxes = new CraftBox[9];
			curr = new int[9];
			for (int w = 0; w < 9; w++)
			{
				boxes[w] = transform.GetChild(w).gameObject.GetComponent<CraftBox>();
			}
		}
	}

	void Update()
	{
		resultBox.ResultPreview(0);

		for (int i = 0; i < boxes.Length; i++)
		{
			curr[i] = boxes[i].thisItem;
		}

		// player crafting
		if (!workbench)
		{
			bool benchCheck = true;
			for (int p = 0; p < 4; p++)
			{
				if (curr[p] != 2)
				{
					benchCheck = false;
					break;
				}
			}

			if (benchCheck) resultBox.ResultPreview(5);
		}

		// workbench crafting 		//   0 1 2
		else 						//   3 4 5
		{							//   6 7 8
			// pickaxe wood 		
			if (curr[7] == 2 && curr[4] == 2 && curr[0] == 2 && curr[1] == 2 && curr[2] == 2)
				resultBox.ResultPreview(6);
			// pickaxe stone 		
			if (curr[7] == 2 && curr[4] == 2 && curr[0] == 3 && curr[1] == 3 && curr[2] == 3)
				resultBox.ResultPreview(7);
			// pickaxe iron 		
			if (curr[7] == 2 && curr[4] == 2 && curr[0] == 4 && curr[1] == 4 && curr[2] == 4)
				resultBox.ResultPreview(8);

			// axe wood 		
			if (curr[7] == 2 && curr[4] == 2 && curr[3] == 2 && curr[1] == 2 && curr[0] == 2)
				resultBox.ResultPreview(9);
			// axe stone 		
			if (curr[7] == 2 && curr[4] == 2 && curr[3] == 3 && curr[1] == 3 && curr[0] == 3)
				resultBox.ResultPreview(10);
			// axe iron 		
			if (curr[7] == 2 && curr[4] == 2 && curr[3] == 4 && curr[1] == 4 && curr[0] == 4)
				resultBox.ResultPreview(11);
		}
	}
}
