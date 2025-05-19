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

        
        CapsuleCollider capsule = other.GetComponent<CapsuleCollider>();
        if (capsule != null)
        {
            capsule.enabled = false;
        }
        else
        {
            
            other.gameObject.SetActive(false);
            Debug.LogWarning("No CapsuleCollider found - disabled entire GameObject instead");
        }

        
        if (inventory != null)
        {
            inventory.AddMoney(moneyPerItem);
            Debug.Log($"Added {moneyPerItem} money. Total: {inventory.PlayerMoney}");
        }

        
        StartCoroutine(PauseInteraction());
    }

    IEnumerator PauseInteraction()
    {
        _isActive = false;
        yield return new WaitForSeconds(pauseTime);
        _isActive = true;
    }
}
