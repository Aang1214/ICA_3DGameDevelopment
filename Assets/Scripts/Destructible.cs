using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyObject;
    public string playerTag = "Player";
    public float destroyObjectLifetime = 3f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            GameObject obj = Instantiate(destroyObject, transform.position, transform.rotation);
            Destroy(obj, destroyObjectLifetime);
            Destroy(gameObject);
        }
    }

}
