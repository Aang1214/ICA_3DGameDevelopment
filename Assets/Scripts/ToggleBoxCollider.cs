using UnityEngine;

public class ClickActivateCollider : MonoBehaviour
{
    [Header("Settings")]
    public int mouseButton = 0;            // Mouse button index (0 = left click, 1 = right click, etc.)
    public float disableDelay = 0.5f;      // Time in seconds before disabling the collider again

    [Header("References")]
    public BoxCollider boxCollider;        // Reference to the BoxCollider component

    private void Start()
    {
        // If no BoxCollider is manually assigned, try to get it from the same GameObject
        if (boxCollider == null)
        {
            boxCollider = GetComponent<BoxCollider>();
        }

        // Start with the collider disabled
        boxCollider.enabled = false;
    }

    private void Update()
    {
        // If the collider is not assigned, do nothing
        if (boxCollider == null) return;

        // Check if the specified mouse button was pressed this frame
        if (Input.GetMouseButtonDown(mouseButton))
        {
            // Enable the collider
            boxCollider.enabled = true;

            // Schedule it to be disabled after a short delay
            Invoke("DisableCollider", disableDelay);
        }
    }

    // Method to disable the collider, called after the delay
    private void DisableCollider()
    {
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
    }
}
