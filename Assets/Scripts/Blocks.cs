using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour
{
    public enum BlockTypes { Grass, Stone , Sand, Gravel, Water, Coal, Iron, Gold, Diamond };

    public Material[] blockmats;

    public BlockTypes thisBlockType;
    int health;

    void Start ()
    {
        health = 2;

        thisBlockType = BlockTypes.Grass;
	}
	
	public void SetBlock(int toSet)
    {
        thisBlockType = (BlockTypes)toSet;
        gameObject.GetComponent<Renderer>().material = blockmats[toSet];
    }
}
