using UnityEngine;

public class HeadController : MonoBehaviour
{
    private void Start() // Only enabled if is the local player
    {
        GetComponent<Camera>().enabled = true;
        GetComponent<AudioListener>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        transform.parent.GetComponent<SkinnedMeshRenderer>().enabled = false;
    }

    private void Update()
    {
        // Debug: show/hide mouse
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }

        // Camera rotation
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -1f, 0f, 0f));
        transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X"), 0f), Space.World);
    }
}