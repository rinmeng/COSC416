using Unity.Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private InputManager inputManager;
    private Rigidbody playerRb;

    // Movement variables
    [SerializeField] private float moveSpeed = 5.0f;
    // A higher value (e.g., 10f - 20f) makes movement snappier.
    // A lower value(e.g., 2f - 5f) makes movement more gradual and floaty.=
    [SerializeField] private float lerpFactor = 20.0f;
    [SerializeField] private float dashForce = 20.0f;
    private Vector3 lastMoveDirection = Vector3.forward;

    // Jump variables
    private bool isGrounded = true;
    private int jumpCount = 0;
    private int airJumpCount = 1;
    [SerializeField] private float jumpForce = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(Jump);
        inputManager.OnMove.AddListener(Move);
        inputManager.OnDashPressed.AddListener(Dash);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            isGrounded = true;
            jumpCount = 0;
        }
        else
        {
            isGrounded = false;
        }

        RotateCharacter();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Move(Vector3 direction)
    {
        if (direction.magnitude > 0.1f) // Only move if input is detected
        {
            Vector3 camForward = Camera.main.transform.forward;
            Vector3 camRight = Camera.main.transform.right;
            camForward.y = 0;
            camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            // Convert movement to camera-relative direction
            Vector3 moveDirection = (camForward * direction.z + camRight * direction.x).normalized;

            // Store this direction for dashing
            lastMoveDirection = moveDirection;

            // Apply movement
            Vector3 targetVelocity = moveDirection * moveSpeed;
            playerRb.linearVelocity = Vector3.Lerp(playerRb.linearVelocity, new Vector3(targetVelocity.x, playerRb.linearVelocity.y, targetVelocity.z), lerpFactor * Time.deltaTime);
        }
        else
        {
            playerRb.linearVelocity = Vector3.Lerp(playerRb.linearVelocity, new Vector3(0, playerRb.linearVelocity.y, 0), lerpFactor * Time.deltaTime);
        }
    }

    private void RotateCharacter()
    {
        // Get the forward direction of the camera (ignoring vertical tilt)
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0; // Keep it on the horizontal plane
        camForward.Normalize();

        // Rotate the player smoothly to face the camera's forward direction
        Quaternion targetRotation = Quaternion.LookRotation(camForward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * lerpFactor);
    }

    private void Jump()
    {
        if (isGrounded || jumpCount < airJumpCount)
        {
            playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, 0, playerRb.linearVelocity.z); // Reset Y velocity to prevent floatiness
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }

    private void Dash()
    {
        Vector3 dashDirection = lastMoveDirection.magnitude > 0.1f ? lastMoveDirection : transform.forward;

        // Reset the vertical component of velocity before dashing
        playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, 0, playerRb.linearVelocity.z);

        // Apply the dash force
        playerRb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
    }

}
