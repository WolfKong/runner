using UnityEngine;
using UnityEngine.UI;

public class UIFloatVariable : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private FloatVariable floatVar;

    private float value;

    private void Update()
    {
        if (value != floatVar.Value)
        {
            value = floatVar.Value;
            uiText.text = value.ToString();
        }
    }
}
