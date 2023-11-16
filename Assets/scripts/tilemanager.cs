using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numofTiles = 3;
    public Transform playertransform;
    private List<GameObject> activetiles = new List<GameObject>();

    void Start()
    {
      for (int i=0; i < numofTiles; i++)
        {
            if (i == 0) { spawntiles(0); }
            else
            {
                spawntiles(Random.Range(0, tilePrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playertransform.position.z-31>zSpawn - (numofTiles * tileLength))
        {
            spawntiles(Random.Range(0, tilePrefabs.Length));
            deletetile();
        }

        
    }
    public void spawntiles(int tileIndex)
    {

        Vector3 spawnPosition = new Vector3(1.6f, 0, zSpawn);
        GameObject go =  Instantiate(tilePrefabs[tileIndex], spawnPosition, transform.rotation);
        activetiles.Add(go);
        zSpawn += tileLength;
    }
    private void deletetile()
    {
        Destroy(activetiles[0]);
        activetiles.RemoveAt(0);
    }
    public void DestroyObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
    }


}
