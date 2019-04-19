using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform PlayerTransform;
    private float spawnZ = -2.5f;
    private float safeZone = 80.0f;

    private float TileLength = 45.0f;
    private int amnTilesOnScreen = 40;
    private int LastPrefabeIndex = 0;
    private List<GameObject> activeTiles;
    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnTilesOnScreen; i++)
        {   if(i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * TileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    private void SpawnTile(int perfIndex = -1)
    {
        GameObject go;
        if(perfIndex == -1 )
            go = Instantiate(tilePrefabs[RandomPrefabeIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[perfIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += TileLength;
        activeTiles.Add(go);
    }
    
    private void DeleteTile(int perfIndex = -1)
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    
    private int RandomPrefabeIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int RandomIndex = LastPrefabeIndex;
        while(RandomIndex == LastPrefabeIndex)
        {
            RandomIndex = Random.Range(0, tilePrefabs.Length);
        }
        LastPrefabeIndex = RandomIndex;
        return RandomIndex;
    }

}
