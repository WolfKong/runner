using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 2)]
[Serializable]
public class CharacterData : ScriptableObject
{
    public float ForwardSpeed;
    public float SideStepSpeed;
    public float JumpForce;
    public float Gravity;

    public override string ToString()
    {
        return $"Speed:{ForwardSpeed} SideSpeed:{SideStepSpeed} Jump:{JumpForce} Gravity: {Gravity}";
    }
}
