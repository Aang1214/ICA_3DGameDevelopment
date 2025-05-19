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
    
    void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(purchaseKey))
        {
            NavMeshAgent.speed = 3;
        }
        else  
        {
            NavMeshAgent.speed = 0;
        }
    }
}
