using UnityEngine;

public class Destructible : MonoBehaviour
{
    // Prefab to instantiate when this object is destroyed (e.g., explosion, debris)
    public GameObject destroyObject;

    // Tag used to identify the player object
    public string playerTag = "Player";

    // How long the instantiated destroyObject should exist before being destroyed
    public float destroyObjectLifetime = 3f;

    // Called when this GameObject collides with another collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the specified player tag
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Instantiate the destruction effect at this object's position and rotation
            GameObject obj = Instantiate(destroyObject, transform.position, transform.rotation);

            // Destroy the destruction effect after the specified lifetime
            Destroy(obj, destroyObjectLifetime);

            // Destroy this destructible object
            Destroy(gameObject);
        }
    }
}
