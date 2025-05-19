using UnityEngine;

public class ClickActivateCollider : MonoBehaviour
{
    [Header("Settings")]
    public int mouseButton = 0; 
    public float disableDelay = 0.5f; 

    [Header("References")]
    public BoxCollider boxCollider;

    private void Start()
    {
        if (boxCollider == null)
        {
            boxCollider = GetComponent<BoxCollider>();
        }
        boxCollider.enabled = false; 
    }

    private void Update()
    {
        if (boxCollider == null) return;

        if (Input.GetMouseButtonDown(mouseButton))
        {
            boxCollider.enabled = true;
            Invoke("DisableCollider", disableDelay);
        }
    }

    private void DisableCollider()
    {
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
    }
}
