using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject[] lvl1Bricks;
    public GameObject[] lvl1SpawnLocations;
    public GameObject[] lvl2SpawnLocations;
    public int brickCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        fillLvl();
    }

    // Update is called once per frame
    void Update()
    {
        if (brickCount == 0)
        {
            fillLvl();
        }
    }

    private void fillLvl()
    {
        int rand = Random.Range(1, 3);
        GameObject[] bricksLocation;
        GameObject[] bricks;


        if (rand == 1)
        {
            bricks = lvl1Bricks;
            bricksLocation = lvl1SpawnLocations;
        }
        else
        {
            bricks = lvl1Bricks;
            bricksLocation = lvl2SpawnLocations;
        }
        

        foreach (GameObject spawnBrick in bricksLocation)
        {
            int i = Random.Range(0, bricks.Length);
            GameObject spawn = Instantiate(bricks[i], spawnBrick.transform.position, Quaternion.identity);
            brickCount++;
        }

    }



    public int numOfBricks()
    { return brickCount; }




}


    



