using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private LevelData data;
    [SerializeField] private Transform tilePrefab;
    [SerializeField] private float tileSize;

    private int tileCount = 0;
    private List<Transform> tiles = new List<Transform>();

    void Start()
    {
        CreateTile();
        CreateTile();
        CreateTile();
    }

    float time;
    void Update()
    {
        time += Time.deltaTime;
        if (time > 5)
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
