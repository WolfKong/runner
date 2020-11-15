using UnityEngine;
using UnityEngine.SceneManagement;

public class Runner : MonoBehaviour
{
    [SerializeField] private GameplayData gameplayData;

    [SerializeField] private float lineDistance;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private MeshRenderer meshRenderer;

    private CharacterData characterData;
    private Vector3 direction;
    private float targetXPosition;
    private int targetXDirection;
    private int currentLine;

    private void Start()
    {
        characterData = gameplayData.CharacterData;
        meshRenderer.material = characterData.Material;
        direction = new Vector3(0, 0, characterData.ForwardSpeed);
        currentLine = 0;

        MicInput.MicInputEvent += OnMicInput;
        TouchInput.UpInputEvent += OnUpInput;
        TouchInput.LeftInputEvent += OnLeftInput;
        TouchInput.RightInputEvent += OnRightInput;
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

        SceneManager.LoadScene("GameOver");
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
            direction.y = characterData.JumpForce;
    }

    private void ChangeLine()
    {
        targetXPosition = currentLine * lineDistance;
        targetXDirection = transform.position.x > targetXPosition ? -1 : 1;

        direction.x = targetXDirection * characterData.SideStepSpeed;
    }

    private void Update()
    {
        if (!characterController.isGrounded)
            direction.y -= characterData.Gravity * Time.deltaTime;
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
