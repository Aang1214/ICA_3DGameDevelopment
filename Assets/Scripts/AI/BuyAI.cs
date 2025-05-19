using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.Behavior; // Ensure this is a valid namespace in your project
//AI was used to write comments for the code
public class BuyAI : MonoBehaviour
{
    // Reference to the NavMeshAgent component for movement
    public NavMeshAgent NavMeshAgent;

    // The cost to "purchase" this AI
    public int aiCost = 100;

    // The key the player presses to purchase the AI
    public KeyCode purchaseKey = KeyCode.E;

    // Reference to the player's inventory for accessing money
    public InventoryObject inventory;

    // Tracks whether this AI has been purchased
    private bool isPurchased = false;

    void Start()
    {
        // Get the NavMeshAgent component on this GameObject if not already assigned
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check for purchase input only if the AI hasn't been bought yet
        if (!isPurchased && Input.GetKeyDown(purchaseKey))
        {
            // If the player has enough money, reduce the amount and mark the AI as purchased
            if (inventory != null && inventory.PlayerMoney >= aiCost)
            {
                inventory.ReduceMoney(aiCost);
                isPurchased = true;
                Debug.Log("AI purchased!");
            }
        }

        // Set AI movement speed based on whether it's purchased
        NavMeshAgent.speed = isPurchased ? 3 : 0;
    }
}
