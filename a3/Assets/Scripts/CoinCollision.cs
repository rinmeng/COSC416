using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding is the player
        if (other.CompareTag("Player"))
        {
            print("Coin collected!");
            Destroy(gameObject); // Destroy the coin
        }
    }

}
