using UnityEngine;
using System.Collections;

public class WorldGen : MonoBehaviour
{
	public int worldWidth = 10;
	public int initialHeightVariance = 2;
	public int grows = 30;
	// public float mitigatingFactor = .25f;

	public GameObject[] surfaceChunks;
	public Material testMat;

	//int[,] 

	void Start()
	{
	// PART 1: SURFACE
		GameObject folder = new GameObject();
		folder.name = "World";

		for (int z = worldWidth; z > -worldWidth; z--)
		{
			for (int x = -worldWidth; x < worldWidth; x++)
			{
				int randChunk = Random.Range(0, surfaceChunks.Length);
				int randHVar = Random.Range(-initialHeightVariance, initialHeightVariance);
				GameObject _ch = Instantiate(surfaceChunks[randChunk], new Vector3(x,randHVar,z), Quaternion.identity) as GameObject;
				_ch.transform.parent = folder.transform;
			}
		}

		int childrenCount = 0;
		foreach (Transform child in folder.transform) {childrenCount++;}

		for (int n = 0; n < grows; n++)
		{
			int initial = Random.Range(0,childrenCount);
			int trueWidth = (worldWidth * 2);

			folder.transform.GetChild(initial).Translate(Vector3.up);

			// first row
			if (initial > trueWidth)
			{
				if ((initial % trueWidth) > 1) folder.transform.GetChild(initial-(trueWidth+1)).Translate(Vector3.up);
				folder.transform.GetChild(initial-(trueWidth)).Translate(Vector3.up);
				if ((initial % trueWidth) < trueWidth) folder.transform.GetChild(initial-(trueWidth-1)).Translate(Vector3.up);
			}

			// middle row
			if ((initial % trueWidth) > 1) folder.transform.GetChild(initial-1).Translate(Vector3.up);
			if ((initial % trueWidth) != trueWidth) folder.transform.GetChild(initial+1).Translate(Vector3.up);

			// last row
			if ((initial + trueWidth) < childrenCount)
			{
				if ((initial % trueWidth) > 1) folder.transform.GetChild(initial+(trueWidth-1)).Translate(Vector3.up);
				folder.transform.GetChild(initial+(trueWidth)).Translate(Vector3.up);
				if ((initial % trueWidth) < trueWidth) folder.transform.GetChild(initial+(trueWidth+1)).Translate(Vector3.up);
			}
		}

	// PART 2: UNDERGROUND

	}
}