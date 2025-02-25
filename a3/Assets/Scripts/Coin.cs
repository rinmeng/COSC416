using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100.0f;
    [SerializeField] private float levitationSpeed = 2.0f; // Speed of up/down motion
    [SerializeField] private float levitationHeight = 0.5f; // How high it moves

    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position
        startPosition = transform.position;

        // Set a random initial rotation around the Y axis
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, randomAngle, 0f);
    }

    void Update()
    {
        // Rotate the coin
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Levitate up and down using a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * levitationSpeed) * levitationHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding is the player
        if (other.CompareTag("Player"))
        {
            print("Coin collected!");

            // Get the GameManager script
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.CollectCoin(); // Call the CollectCoin method from the GameManager script
            }

            Destroy(gameObject); // Destroy the coin
        }
    }
}
