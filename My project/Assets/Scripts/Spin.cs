using UnityEngine;

public class Spin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the y-axis
        transform.Rotate(Vector3.up, 1);
    }
}
