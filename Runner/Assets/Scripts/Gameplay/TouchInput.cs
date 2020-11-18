using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform rectTransform;

    public static event Action UpInputEvent;
    public static event Action RightInputEvent;
    public static event Action LeftInputEvent;

    private float screenMiddle;

    private void Start()
    {
        screenMiddle = Screen.width / 2;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            UpInputEvent?.Invoke();

        if (Input.GetKeyDown(KeyCode.Space))
            UpInputEvent?.Invoke();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.position.x > screenMiddle)
            RightInputEvent?.Invoke();
        else
            LeftInputEvent?.Invoke();
    }
}
