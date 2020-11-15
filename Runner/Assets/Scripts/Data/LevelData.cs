using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
[Serializable]
public class LevelData : ScriptableObject
{
    public int TargetScore;
    public Sprite MenuImage;
    public Material FloorMaterial;
    public Material ObstacleMaterial;
    public Material EnemyMaterial;
    public LevelTile[] LevelTiles;

    public override string ToString()
    {
        return $"{name}, Score {TargetScore}, Floor:{FloorMaterial} Obstacle:{ObstacleMaterial} Enemy:{EnemyMaterial}";
    }
}
