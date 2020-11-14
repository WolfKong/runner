using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private CharacterController characterController;

    private Vector3 direction;

    private void Start()
    {
        MicInput.MicInputEvent += OnMicInput;
        TouchInput.UpInputEvent += OnTouchInput;
        direction = new Vector3(0, 0, speed);
    }

    private void OnDestroy()
    {
        MicInput.MicInputEvent -= OnMicInput;
        TouchInput.UpInputEvent -= OnTouchInput;
    }

    private void OnMicInput() => Jump();
    private void OnTouchInput() => Jump();

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void Update()
    {
        if (!characterController.isGrounded)
            direction.y -= gravity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }
}
