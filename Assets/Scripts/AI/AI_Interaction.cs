using static InventoryObject; // Import static members from InventoryObject
using System.Collections;
using UnityEngine;

public class AI_Interaction : MonoBehaviour
{
    [Header("Settings")]
    public float pauseTime = 2f;           // Time to pause after interaction before allowing more
    public string targetTag = "General";   // Tag of objects this AI should interact with
    public int moneyPerItem = 10;          // Amount of money added per interaction

    [Header("References")]
    public InventoryObject inventory;      // Reference to the player

    private bool _isActive = true;         // Determines whether the AI is currently ready to interact

    void Start()
    {
        // Ensure this object has a trigger collider
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true; // Set collider to trigger mode
        }
        else
        {
            Debug.LogError("No Collider component found!", this);
        }
    }

    // Called when another collider enters this trigger
    void OnTriggerEnter(Collider other)
    {
        // Exit if this AI is inactive or the object doesn't have the target tag
        if (!_isActive || !other.CompareTag(targetTag))
            return;

        // Try to disable the CapsuleCollider on the target object
        CapsuleCollider capsule = other.GetComponent<CapsuleCollider>();
        if (capsule != null)
        {
            capsule.enabled = false;
        }
        else
        {
            // If no CapsuleCollider, disable the whole GameObject as a fallback
            other.gameObject.SetActive(false);
            Debug.LogWarning("No CapsuleCollider found - disabled entire GameObject instead");
        }

        // Add money to the inventory
        if (inventory != null)
        {
            inventory.AddMoney(moneyPerItem);
            Debug.Log($"Added {moneyPerItem} money. Total: {inventory.PlayerMoney}");
        }

        // Start cooldown before next interaction
        StartCoroutine(PauseInteraction());
    }

    // Coroutine to pause interactions temporarily
    IEnumerator PauseInteraction()
    {
        //_isActive = false; // Uncomment to disable interaction during pause
        yield return new WaitForSeconds(pauseTime);
        //_isActive = true;  // Uncomment to re-enable interaction after pause
    }
}
