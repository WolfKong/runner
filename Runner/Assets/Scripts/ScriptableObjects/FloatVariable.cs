using UnityEngine;

[CreateAssetMenu(fileName = "UIFloatVariable", menuName = "ScriptableObjects/UIFloatVariable")]
public class FloatVariable : ScriptableObject
{
    public float Value;

    public override string ToString()
    {
        return $"Value:{Value}";
    }
}
