using UnityEngine;
using System.Collections;

public class ChunkGen : MonoBehaviour
{
	public int chunkSize = 16;
	public int minGrows = 5;
	public int maxGrows = 20;

	public GameObject block;

	GameObject[,,] initialBlocks;

	void Start()
	{
		initialBlocks = new GameObject[chunkSize, (chunkSize/4)*3, chunkSize];

		// Generate the blocks
		for (int x = -(chunkSize/2); x < (chunkSize/2); x++)
		{
			for (int z = -(chunkSize/2); z < (chunkSize/2); z++)
			{
				for (int y = -(chunkSize/2); y < (chunkSize/4); y++)
				{
					GameObject _block = Instantiate(block, new Vector3(transform.position.x+x,transform.position.y+y,transform.position.z+z), Quaternion.identity) as GameObject;
					if (y > 0)	_block.GetComponent<Blocks>().SetBlock(0); // Grass
					else 		_block.GetComponent<Blocks>().SetBlock(1); // Stone

					_block.transform.parent = transform;
					_block.name = "Block " + x + "," + y + "," + z;
					initialBlocks[x+chunkSize/2, y+chunkSize/2, z+chunkSize/2] = _block;
				}
			}
		}

		// Move some up or down
		int grows = Random.Range(minGrows,maxGrows);

		for (int n = 0; n < grows; n++)
		{
			//int initial = Random.Range(0,chunkSize*chunkSize); // middle of the 'seed'
			Vector2 initial = new Vector2(Random.Range(2,chunkSize-2), Random.Range(2,chunkSize-2));
			int expand = Random.Range(0,2); // sometimes a 3x3, somtimes a 5x5
			int sink = Random.Range(0,2); // sometimes go up, sometimes go down
			if (sink == 0) sink = -1;

			//transform.GetChild(initial).Translate(Vector3.up);
			/*for (int dx = -1-expand; dx <= 1+expand; dx++)
			{
				for (int dz = -1-expand; dz <= 1+expand; dz++)
				{
					for (int dy = -(chunkSize/2); dy < (chunkSize/4); dy++)
					{
						//print ("moving up " + dx + "," + dy + "," + dz);
						print (initial + "   " + expand);
						if (Mathf.Abs((int)initial.x+dx) < chunkSize/2 && Mathf.Abs((int)initial.y+dz) < chunkSize/2)
						{
							print ("raising " + dx + "," + dy + "," + dz);
							initialBlocks[(int)initial.x+dx,dy,(int)initial.y+dz].transform.Translate(Vector3.up);
						}
					}
				}
			}*/

			//float iy = initialBlocks[0,0,0].transform.position.y;

			for (int dx = -1-expand; dx < 2+expand; dx++)
			{
				for (int dz = -1-expand; dz < 2+expand; dz++)
				{
					for (int dy = 0; dy < initialBlocks.GetLength(1); dy++)
					{
						initialBlocks[(int)initial.x+dx,dy,(int)initial.y+dz].transform.Translate(Vector3.up*sink);

						// To keep chunk bounds, add or remove blocks at the bottom
						// I couldn't immediately get it to work and decided it wasn't worth the time
						/*
						if (sink > 0)
						{
							GameObject _block = Instantiate(block, new Vector3((int)initial.x+dx,0,(int)initial.y+dz), Quaternion.identity) as GameObject;
							_block.GetComponent<Blocks>().SetBlock(1);
							_block.transform.parent = transform;
						}
						else 
							Destroy(initialBlocks[(int)initial.x+dx,0,(int)initial.y+dz]);
						*/
					}
				}
			}
		}
	}
}
