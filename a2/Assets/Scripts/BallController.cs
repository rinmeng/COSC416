using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float force = 1f;
    private Rigidbody ballRB;
    private bool isBallLaunched = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LaunchBall(){
        if (isBallLaunched) return;
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force,  ForceMode.Impulse);
    }
}
