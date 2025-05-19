using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.Behavior;


public class BuyAI : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;
    public int aiCost = 100;
    public KeyCode purchaseKey = KeyCode.E;
    public InventoryObject inventory;

    private bool isPurchased = false;

    void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
        if (!isPurchased && Input.GetKeyDown(purchaseKey))
        {
            if (inventory != null && inventory.PlayerMoney >= aiCost)
            {
                inventory.ReduceMoney(aiCost);
                isPurchased = true;
                Debug.Log("AI purchased!");
            }
        }

        
        NavMeshAgent.speed = isPurchased ? 3 : 0;
    }
}
