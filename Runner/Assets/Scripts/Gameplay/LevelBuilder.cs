using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private CharacterData characterData;
    [SerializeField] private float tileSize;

    private int tileCount = 0;
    private float time;
    private float spawnInterval;
    private List<GameObject> tiles = new List<GameObject>();

    void Start()
    {
        levelData = GameProgress.CurrentLevel ?? levelData;

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

        var position = new Vector3(0, 0, tileCount * tileSize);
        var levelTiles = levelData.LevelTiles;
        var prefab = levelTiles[Random.Range(0, levelTiles.Length)];

        var tile = Instantiate(prefab, position, Quaternion.identity, transform);
        tile.SetData(levelData);
        tiles.Add(tile.gameObject);

        if (tiles.Count > 5)
        {
            Destroy(tiles[0]);
            tiles.RemoveAt(0);
        }
    }
}
