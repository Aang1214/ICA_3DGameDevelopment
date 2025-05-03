using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineCamera FirstPerson;
    public CinemachineCamera ThirdPerson;

    private bool isFirstPerson = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) // Example key
        {
            isFirstPerson = !isFirstPerson;
            if (isFirstPerson)
            {
                FirstPerson.Priority = 11;
                ThirdPerson.Priority = 10;
            }
            else
            {
                FirstPerson.Priority = 10;
                ThirdPerson.Priority = 11;
            }
        }
    }
}
