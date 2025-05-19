using UnityEngine;
using Unity.Cinemachine; // Ensure you're using the correct Cinemachine namespace
//AI was used to write comments for the code
public class CameraSwitcher : MonoBehaviour
{
    // References to the Cinemachine cameras
    public CinemachineCamera FirstPerson;
    public CinemachineCamera ThirdPerson;

    // Tracks the current camera state (true if using first-person)
    private bool isFirstPerson = false;

    void Update()
    {
        // Listen for the V key press to toggle cameras
        if (Input.GetKeyDown(KeyCode.V)) // Example key to switch cameras
        {
            // Toggle the camera state
            isFirstPerson = !isFirstPerson;

            if (isFirstPerson)
            {
                // Set higher priority for the first-person camera
                FirstPerson.Priority = 11;
                ThirdPerson.Priority = 10;
            }
            else
            {
                // Set higher priority for the third-person camera
                FirstPerson.Priority = 10;
                ThirdPerson.Priority = 11;
            }
        }
    }
}
