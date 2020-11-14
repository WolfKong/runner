using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private LevelData data;
    [SerializeField] private CharacterData characterData;
    [SerializeField] private Transform tilePrefab;
    [SerializeField] private float tileSize;

    private int tileCount = 0;
    private float time;
    private float spawnInterval;
    private List<Transform> tiles = new List<Transform>();

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
        tile.localPosition = new Vector3(0, 0, tileCount * tileSize);
        tiles.Add(tile);

        if (tiles.Count > 5)
        {
            Destroy(tiles[0].gameObject);
            tiles.RemoveAt(0);
        }
    }
}
