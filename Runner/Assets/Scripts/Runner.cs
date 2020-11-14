using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float sideStepSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private float lineDistance;
    [SerializeField] private CharacterController characterController;

    private Vector3 direction;
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
        var targetXDirection = transform.position.x > currentLine * lineDistance ? -1 : 1;

        direction.x = targetXDirection * sideStepSpeed;
    }

    private void Update()
    {
        if (!characterController.isGrounded)
            direction.y -= gravity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (Mathf.Approximately(transform.position.x, currentLine * lineDistance))
            direction.x = 0;

        characterController.Move(direction * Time.fixedDeltaTime);
    }
}
