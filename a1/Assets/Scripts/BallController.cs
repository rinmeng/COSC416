using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour

{

    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    [SerializeField] private Rigidbody sphereRb;
    [SerializeField] private float speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {



    }

    public void MoveBall(Vector2 input)
    {
        Vector3 inputXZPlane = new Vector3(input.x, 0, input.y);
        sphereRb.AddForce(inputXZPlane * speed);
    }
}
