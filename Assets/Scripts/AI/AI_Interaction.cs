using UnityEngine;
using UnityEngine.AI;
using static InventoryObject;
using System.Collections;

public class AI_Interaction : MonoBehaviour
{
    [Header("Settings")]
    public float pauseTime = 2f;
    public string targetTag = "General";
    public int moneyPerItem = 10;

    [Header("References")]
    public InventoryObject inventory;

    private bool _isActive = true;

    void Start()
    {
        // Ensure this object's collider is set to trigger
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true;
        }
        else
        {
            Debug.LogError("No Collider component found!", this);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!_isActive || !other.CompareTag(targetTag))
            return;

        // 1. Disable the Capsule Collider of the object we hit
        CapsuleCollider capsule = other.GetComponent<CapsuleCollider>();
        if (capsule != null)
        {
            capsule.enabled = false;
        }
        else
        {
            // Fallback to disabling the whole object if no capsule found
            other.gameObject.SetActive(false);
            Debug.LogWarning("No CapsuleCollider found - disabled entire GameObject instead");
        }

        // 2. Add money directly to inventory
        if (inventory != null)
        {
            inventory.AddMoney(moneyPerItem);
            Debug.Log($"Added {moneyPerItem} money. Total: {inventory.PlayerMoney}");
        }

        // 3. Pause logic
        StartCoroutine(PauseInteraction());
    }

    IEnumerator PauseInteraction()
    {
        _isActive = false;
        yield return new WaitForSeconds(pauseTime);
        _isActive = true;
    }
}
