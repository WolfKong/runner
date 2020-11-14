﻿using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float sideStepSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private float lineDistance;
    [SerializeField] private CharacterController characterController;

    private Vector3 direction;
    private float targetXPosition;
    private int targetXDirection;
    private int currentLine;

    private void Start()
    {
        MicInput.MicInputEvent += OnMicInput;
        TouchInput.UpInputEvent += OnUpInput;
        TouchInput.LeftInputEvent += OnLeftInput;
        TouchInput.RightInputEvent += OnRightInput;
        direction = new Vector3(0, 0, forwardSpeed);
        currentLine = 0;
    }

    private void OnDestroy()
    {
        MicInput.MicInputEvent -= OnMicInput;
        TouchInput.UpInputEvent -= OnUpInput;
        TouchInput.LeftInputEvent -= OnLeftInput;
        TouchInput.RightInputEvent -= OnRightInput;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Don't die when hitting from above
        if (hit.moveDirection.y < -0.3)
            return;

        Debug.LogWarning($"PV-GAME OVER");
    }

    private void OnMicInput() => Jump();
    private void OnUpInput() => Jump();

    private void OnLeftInput()
    {
        if (currentLine > -1)
        {
            currentLine--;
            ChangeLine();
        }
    }

    private void OnRightInput()
    {
        if (currentLine < 1)
        {
            currentLine++;
            ChangeLine();
        }
    }

    private void Jump()
    {
        if (characterController.isGrounded)
            direction.y = jumpForce;
    }

    private void ChangeLine()
    {
        targetXPosition = currentLine * lineDistance;
        targetXDirection = transform.position.x > targetXPosition ? -1 : 1;

        direction.x = targetXDirection * sideStepSpeed;
    }

    private void Update()
    {
        if (!characterController.isGrounded)
            direction.y -= gravity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (direction.x != 0)
        {
            var deltaX = transform.position.x - targetXPosition;
            if (Mathf.Approximately(deltaX, 0) ||
                (targetXDirection > 0 && deltaX > 0) ||
                (targetXDirection < 0 && deltaX < 0))
                direction.x = 0;
        }

        characterController.Move(direction * Time.fixedDeltaTime);
    }
}
