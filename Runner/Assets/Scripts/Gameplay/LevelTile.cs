using UnityEngine;

public class LevelTile : MonoBehaviour
{
    [SerializeField] private MeshRenderer floor;

    public void SetData(LevelData data)
    {
        floor.material = data.FloorMaterial;

        foreach (Transform child in transform)
        {
            if (child.tag == "Obstacle")
                child.GetComponent<MeshRenderer>().material = data.ObstacleMaterial;
            else if (child.tag == "Enemy")
                child.GetComponent<MeshRenderer>().material = data.EnemyMaterial;
        }
    }
}
