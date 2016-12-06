using UnityEngine;
using System.Collections;

public class WorldGen : MonoBehaviour
{
	public int worldWidth = 10;
	public int initialHeightVariance = 2;
	public int grows = 30;
	public int chunkSize = 16;
	//public float mitigatingFactor = 4; // over 16

	public GameObject[] surfaceChunks;
	public GameObject[] ugChunks; // in order: quarry, iron, gold, diamond
	public Material testMat;

	//int[,] heights;

	void Start()
	{
		int trueWidth = (worldWidth * 2);
		//heights = new int[worldWidth, worldWidth];

		GameObject folder = new GameObject();
		folder.name = "World";

	// PART 1: SURFACE - the topmost chunks
		GameObject folderSurface = new GameObject();
		folderSurface.transform.parent = folder.transform;
		folderSurface.name = "Surface";

		// Generates the topmost surface chunks
		for (int z = worldWidth; z > -worldWidth; z--)
		{
			for (int x = -worldWidth; x < worldWidth; x++)
			{
				int randChunk = Random.Range(0, surfaceChunks.Length); // biome? may need removal
				int randHVar = Random.Range(-initialHeightVariance, initialHeightVariance);
				GameObject _ch = Instantiate(surfaceChunks[randChunk], new Vector3(x*chunkSize,randHVar,z*chunkSize), Quaternion.identity) as GameObject;
				_ch.transform.parent = folderSurface.transform;
				// set chunk type to surface
			}
		}

		// Counts up how many chunks there are
		int childrenCount = 0;
		foreach (Transform child in folderSurface.transform) {childrenCount++;}

		// Moves the surface chunks up/down to create some terrain
		for (int n = 0; n < grows; n++)
		{
			int initial = Random.Range(0,childrenCount);

			folderSurface.transform.GetChild(initial).Translate(Vector3.up);

			// first row
			if (initial > trueWidth)
			{
				if ((initial % trueWidth) > 1) folderSurface.transform.GetChild(initial-(trueWidth+1)).Translate(Vector3.up);
				folderSurface.transform.GetChild(initial-(trueWidth)).Translate(Vector3.up);
				if ((initial % trueWidth) < trueWidth) folderSurface.transform.GetChild(initial-(trueWidth-1)).Translate(Vector3.up);
			}

			// middle row
			if ((initial % trueWidth) > 1) folderSurface.transform.GetChild(initial-1).Translate(Vector3.up);
			if ((initial % trueWidth) != (trueWidth-1)) folderSurface.transform.GetChild(initial+1).Translate(Vector3.up);

			// last row
			if ((initial + trueWidth) < childrenCount)
			{
				if ((initial % trueWidth) > 1) folderSurface.transform.GetChild(initial+(trueWidth-1)).Translate(Vector3.up);
				folderSurface.transform.GetChild(initial+(trueWidth)).Translate(Vector3.up);
				if ((initial % trueWidth) < trueWidth) folderSurface.transform.GetChild(initial+(trueWidth+1)).Translate(Vector3.up);
			}
		}

	// PART 2: QUARRY - fills the space under the high surfaces with chunks with basic stone, coal, and gravel
		int baseUL = -initialHeightVariance - 1;



	// PART 3: UNDERGROUND - creates a layer of each kind of material, down to the bedrock

		// iron
		GameObject folderUGiron = new GameObject();
		folderUGiron.transform.parent = folder.transform;
		folderUGiron.name = "UG Iron";

		for (int z = worldWidth; z > -worldWidth; z--)
		{
			for (int x = -worldWidth; x < worldWidth; x++)
			{
				GameObject _ch = Instantiate(ugChunks[1], new Vector3(x*chunkSize,baseUL,z*chunkSize), Quaternion.identity) as GameObject;
				_ch.transform.parent = folderUGiron.transform;
			}
		}

		// gold
		GameObject folderUGgold = new GameObject();
		folderUGgold.transform.parent = folder.transform;
		folderUGgold.name = "UG Gold";

		for (int z = worldWidth; z > -worldWidth; z--)
		{
			for (int x = -worldWidth; x < worldWidth; x++)
			{
				GameObject _ch = Instantiate(ugChunks[2], new Vector3(x*chunkSize,baseUL-1,z*chunkSize), Quaternion.identity) as GameObject;
				_ch.transform.parent = folderUGgold.transform;
			}
		}

		// diamond
		GameObject folderUGdiamond = new GameObject();
		folderUGdiamond.transform.parent = folder.transform;
		folderUGdiamond.name = "UG Diamond";

		for (int z = worldWidth; z > -worldWidth; z--)
		{
			for (int x = -worldWidth; x < worldWidth; x++)
			{
				GameObject _ch = Instantiate(ugChunks[3], new Vector3(x*chunkSize,baseUL-2,z*chunkSize), Quaternion.identity) as GameObject;
				_ch.transform.parent = folderUGdiamond.transform;
			}
		}

		// TODO: bedrock
	}
}