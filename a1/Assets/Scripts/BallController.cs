using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour

{

    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    [SerializeField] private Rigidbody sphereRb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 5f;
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red);

        if (isGrounded)
        {
            Debug.Log("Grounded");
        }

    }

    public void Jump()
    {
        Debug.Log("Jumping");
        if (isGrounded)
        {
            sphereRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void MoveBall(Vector2 input)
    {
        Vector3 inputXZPlane = new Vector3(input.x, 0, input.y);
        sphereRb.AddForce(inputXZPlane * speed);
    }
}
