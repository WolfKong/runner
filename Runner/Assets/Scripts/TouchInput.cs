using System;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public static event Action UpInputEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            UpInputEvent?.Invoke();

        if (Input.GetKeyDown(KeyCode.Space))
            UpInputEvent?.Invoke();
    }
}
