using UnityEngine;
using UnityEngine.UI;

public class FloatVariableSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private FloatVariable floatVariable;

    private void Start()
    {
        var value = PlayerPrefs.GetFloat(floatVariable.name, slider.value);
        floatVariable.Value = value;

        slider.value = value;
        slider.onValueChanged.AddListener(OnSliderEvent);
    }

    private void OnSliderEvent(float sliderValue)
    {
        floatVariable.Value = sliderValue;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(floatVariable.name, floatVariable.Value);

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(floatVariable);
#endif
    }
}
