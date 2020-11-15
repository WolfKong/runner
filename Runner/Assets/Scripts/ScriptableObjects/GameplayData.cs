using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayData", menuName = "ScriptableObjects/GameplayData")]
[Serializable]
public class GameplayData : ScriptableObject
{
    public LevelData LevelData;
    public CharacterData CharacterData;

    public override string ToString()
    {
        return $"{name}, Level:{LevelData.name}, Character:{CharacterData.name}";
    }
}
