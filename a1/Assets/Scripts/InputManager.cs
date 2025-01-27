using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnJump = new UnityEvent(); // New event for jumping

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
        JumpHandler();
    }

    private void MovementHandler()
    {
        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }

        OnMove?.Invoke(inputVector);
    }

    private void JumpHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Detect jump input
        {
            OnJump?.Invoke(); // Trigger jump event
        }
    }
}