using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private LevelData data;
    [SerializeField] private CharacterData characterData;
    [SerializeField] private LevelTile tilePrefab;
    [SerializeField] private float tileSize;

    private int tileCount = 0;
    private float time;
    private float spawnInterval;
    private List<GameObject> tiles = new List<GameObject>();

    void Start()
    {
        spawnInterval = tileSize / characterData.ForwardSpeed;

        CreateTile();
        CreateTile();
        CreateTile();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > spawnInterval)
        {
            time = 0;
            CreateTile();
        }
    }

    private void CreateTile()
    {
        tileCount++;

        var tile = Instantiate(tilePrefab, transform);
        tile.SetData(data);
        tile.transform.localPosition = new Vector3(0, 0, tileCount * tileSize);
        tiles.Add(tile.gameObject);

        if (tiles.Count > 5)
        {
            Destroy(tiles[0]);
            tiles.RemoveAt(0);
        }
    }
}
