using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // get the rigidbody of the ball
        Rigidbody ballRB = other.GetComponent<Rigidbody>();
        // get the velocity of the ball
        float velocityMagnitude = ballRB.linearVelocity.magnitude;


        // reset the ball movement
        ballRB.linearVelocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;

        ballRB.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
