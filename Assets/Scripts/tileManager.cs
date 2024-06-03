using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    private Transform playerTransform;

    public GameObject[] tilePrefabs;
    private float spawnZ = -37.2f;
    private float tileLength = 37.2f;
    private int amnTilesOnScreen = 3;
    private float safeZone = 40.0f;

    private List<GameObject> activeTiles;

    private int lastPrefabIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
        for(int i = 0; i < amnTilesOnScreen; i++)
        {
            if (i < 2)
                spawnTile(0);
            else
                spawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((playerTransform.position.z-safeZone)>(spawnZ-amnTilesOnScreen*tileLength))
        {
            spawnTile();
            deleteTile();
            
        }
       
    }
    void spawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
  
        
    void deleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
