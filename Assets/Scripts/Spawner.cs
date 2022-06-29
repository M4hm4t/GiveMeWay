using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public string spawnPointTag = "sometag";
    public bool alwaysSpawn = true;

    public List<GameObject> prefabsToSpawn;
    public int[] positions;
    // Start is called before the first frame update
    void Start()
    {
        positions =DataManager.GetInt("level");
        
        if (positions.Length == 0)
        {
            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnPointTag);

            // random üret
            positions = new int[spawnPoints.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = Random.Range(0, prefabsToSpawn.Count);
            }
        }
        GenerateLevel(positions);
    }
    void GenerateLevel(int[] levels)
    {
        DataManager.SetInt("level", levels);
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnPointTag);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject spawnPoint = spawnPoints[i];
            int randomPrefab = levels[i];
            GameObject pts = Instantiate(prefabsToSpawn[randomPrefab]);
            pts.transform.position = spawnPoint.transform.position;
        }

    }
  



}
