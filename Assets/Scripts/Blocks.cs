using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour {

    public enum BlockTypes { Grass, Stone , Sand, Gravel, Water, Coal, Iron, Gold, Diamond /*,Cloud*/  };

    public Material[] blockmats;

    public BlockTypes thisBlockType;
    int health;
    // Use this for initialization
    void Start () {
        health = 2;

        thisBlockType = BlockTypes.Sand;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
