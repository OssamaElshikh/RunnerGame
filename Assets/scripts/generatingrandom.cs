using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject[] itemsToGenerate; // An array of item prefabs
    public float spawnInterval = 2f;     // Interval between spawning items

    private float nextSpawnTime = 0f;
    public Transform player;
    private List<Vector3> usedPositions = new List<Vector3>();
    private float currentZ = 0.0f; // Initial Z value

    private List<Vector3> obstaclePositionsOnZ = new List<Vector3>(); // Moved here

    private void Update()
    {
 
        if (Time.time > nextSpawnTime)
        {
         
            SpawnItem();
            DeleteObjectsWithZLessThanPlayer();
            nextSpawnTime = (Time.time + spawnInterval);

            //myz = player.position.z + 10;
            //nextz = myz + 30;
        }
    }

    void SpawnItem()
    {
        int playerZInt = Mathf.RoundToInt(player.position.z);
        int generationRange = 60; // Increase this range to accommodate faster player speed

        for (int z = playerZInt + 20; z < playerZInt + generationRange; z += 10)
        {
            if (z % 5 == 0)
            {
                // Generate for the first lane
                GenerateItemAtLane(z, -2.8f);

                // Generate for the second lane
                GenerateItemAtLane(z, 0f);

                // Generate for the third lane
                GenerateItemAtLane(z, 2.9f);
            }
        }
    }
    //void GenerateItemAtLane(float z, float x)
    //{
    //    int luck = Random.Range(0, 6);
    //    int luck2 = Random.Range(0, 4);
    //    int itemIndex = Random.Range(0, itemsToGenerate.Length);
    //    GameObject itemPrefab = itemsToGenerate[itemIndex];
    //    Vector3 newspawnPosition;
    //    Vector3 obstaclePosition;
    //    GameObject obstacle = itemsToGenerate[3];
    //    obstaclePosition = new Vector3(x, -4.8f, z);

    //    if (itemIndex != 3)
    //    {
    //        // Check if there's an obstacle at the desired position
    //        Collider[] obstacleColliders = Physics.OverlapSphere(obstaclePosition, 2.0f);
    //        if (obstacleColliders.Length == 0)
    //        {
    //            // Check if there's any other item at the desired position
    //            Collider[] itemColliders = Physics.OverlapSphere(obstaclePosition, 2.0f);
    //            if (itemColliders.Length == 0)
    //            {
    //                if (luck != 0)
    //                {
    //                    if (itemIndex == 0)
    //                    {
    //                        newspawnPosition = new Vector3(x, -4.0f, z);
    //                        Instantiate(itemPrefab, newspawnPosition, Quaternion.Euler(0, 180, 0));
    //                    }
    //                    else if (itemIndex == 1)
    //                    {
    //                        newspawnPosition = new Vector3(x, -4.3f, z);
    //                        Instantiate(itemPrefab, newspawnPosition, Quaternion.Euler(0, 0, 0));
    //                    }
    //                    else if (itemIndex == 2)
    //                    {
    //                        newspawnPosition = new Vector3(x, -4.3f, z);
    //                        Instantiate(itemPrefab, newspawnPosition, Quaternion.Euler(0, 0, 0));
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    if (itemIndex == 3)
    //    {
    //        for (float obstacleZ = z + 10; obstacleZ <= z + 40; obstacleZ += 30)
    //        {
    //            int countObstaclesAtZ = 0;

    //            for (int i = 0; i < obstaclePositionsOnZ.Count; i++)
    //            {
    //                if (Mathf.Approximately(obstaclePositionsOnZ[i].z, obstacleZ))
    //                {
    //                    countObstaclesAtZ++;
    //                }
    //            }

    //            if (countObstaclesAtZ < 2 && luck2 != 0)
    //            {
    //                obstaclePosition = new Vector3(x, -4.8f, obstacleZ);
    //                Instantiate(obstacle, obstaclePosition, Quaternion.Euler(-90, 0, 0));
    //                obstaclePositionsOnZ.Add(obstaclePosition);
    //            }
    //        }
    //    }
    //}

    void GenerateItemAtLane(float z, float x)
    {
        int luck = Random.Range(0, 2);
        int luck2 = Random.Range(0, 4);
        int itemIndex = Random.Range(0, itemsToGenerate.Length);
        GameObject itemPrefab = itemsToGenerate[itemIndex];
        Vector3 newspawnPosition;
        Vector3 obstaclePosition;
        GameObject obstacle = itemsToGenerate[3];
        obstaclePosition = new Vector3(x, -4.8f, z);
        if (itemIndex == 1)
        {

            newspawnPosition = new Vector3(x, -4.0f, z);
        }
        else
        {
            newspawnPosition = new Vector3(x, -4.3f, z);
        }

        Collider[] colliders = Physics.OverlapSphere(newspawnPosition, 2.0f);
        if (colliders.Length == 1)
        {
            if (luck == 0)
            {
                if (itemIndex == 0)
                {
                    Instantiate(itemPrefab, newspawnPosition, Quaternion.Euler(0, 180, 0));
                }
                else if (itemIndex == 1)
                {
                    Instantiate(itemPrefab, newspawnPosition, Quaternion.Euler(0, 0, 0));
                }
                else if (itemIndex == 2)
                {
                    Instantiate(itemPrefab, newspawnPosition, Quaternion.Euler(0, 0, 0));
                }
            }
        }

        if (itemIndex == 3)
        {
            for (float obstacleZ = z + 10; obstacleZ <= z + 40; obstacleZ += 30)
            {
                int countObstaclesAtZ = 0;

                for (int i = 0; i < obstaclePositionsOnZ.Count; i++)
                {
                    if (Mathf.Approximately(obstaclePositionsOnZ[i].z, obstacleZ))
                    {
                        countObstaclesAtZ++;
                    }
                }

                if (countObstaclesAtZ < 2 && luck2 != 0)
                {
                    obstaclePosition = new Vector3(x, -4.8f, obstacleZ);
                    Instantiate(obstacle, obstaclePosition, Quaternion.Euler(-90, 0, 0));
                    obstaclePositionsOnZ.Add(obstaclePosition);
                }
            }
        }
    }

    void DeleteObjectsWithZLessThanPlayer()
    {
        float playerZ = player.position.z;
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if ((obj.transform.position.z < playerZ - 5) &&
                (obj.CompareTag("obstacle") || obj.CompareTag("redcoins") || obj.CompareTag("bluecoins") || obj.CompareTag("coins")))
            {
                Destroy(obj);
            }
        }
    }
}

