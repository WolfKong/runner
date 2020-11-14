using UnityEngine;

public class LevelTile : MonoBehaviour
{
    [SerializeField] private MeshRenderer floor;

    public void SetData(LevelData data)
    {
        var obstacles = GetComponentsInChildren<MeshRenderer>();
        foreach (var obstacle in obstacles)
        {
            obstacle.material = data.ObstacleMaterial;
        }

        floor.material = data.FloorMaterial;
    }
}
