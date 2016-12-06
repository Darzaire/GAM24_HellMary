using UnityEngine;
using System.Collections;

public class ChunkCutter : MonoBehaviour
{
	// was an idea. since scrapped.

	public int chunkSize = 16;
	public GameObject block;

	GameObject[,] topmost;

	void Start()
	{
		topmost = new GameObject[chunkSize,chunkSize];

		for (int x = -(chunkSize/2); x < (chunkSize/2); x++)
		{
			for (int z = -(chunkSize/2); z < (chunkSize/2); z++)
			{
				for (int y = -(chunkSize/2); y < (chunkSize/4); y++)
				{
					GameObject _block = Instantiate(block, new Vector3(x,y,z), Quaternion.identity) as GameObject;
					if (z > 3)	_block.GetComponent<Blocks>().SetBlock(0); // Grass
					else 		_block.GetComponent<Blocks>().SetBlock(1); // Stone

					if (z == (chunkSize/4)-1) topmost[x,z] = _block;
				}
			}
		}
	}

	public void Cut()
	{
		float _radius = Random.Range(5f, 12f);
		Vector2 _origin = new Vector2(Random.Range(-5f, 5f),Random.Range(-5f,5f));

		
	}
}
