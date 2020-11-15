using UnityEngine;
using UnityEngine.UI;

public class UIFloatVariable : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private FloatVariable floatVariable;

    private float value;

    private void Update()
    {
        if (value != floatVariable.Value)
        {
            value = floatVariable.Value;
            uiText.text = value.ToString();
        }
    }
}
