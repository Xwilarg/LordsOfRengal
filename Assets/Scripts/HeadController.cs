using UnityEngine;

public class HeadController : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.parent.GetComponent<SkinnedMeshRenderer>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -1f, 0f, 0f));
        transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X"), 0f), Space.World);
    }
}