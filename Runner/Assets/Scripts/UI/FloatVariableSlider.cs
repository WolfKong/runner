using UnityEngine;
using UnityEngine.UI;

public class FloatVariableSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private FloatVariable floatVariable;

    private void Start()
    {
        slider.value = floatVariable.Value;
        slider.onValueChanged.AddListener(OnSliderEvent);
    }

    private void OnSliderEvent(float sliderValue)
    {
        floatVariable.Value = sliderValue;
    }
}
