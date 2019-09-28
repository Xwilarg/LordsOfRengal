using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : NetworkBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private HeadController hc;
    private float speed = 5f;

    private void Start()
    {
        if (!isLocalPlayer)
            return;
        GetComponentInChildren<HeadController>().enabled = true;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        hc = GetComponentInChildren<HeadController>();
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;
        // Movements and animations
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        anim.SetBool("IsRunning", hor != 0f || ver != 0f);
        Vector3 movement = hc.transform.forward * ver * speed;
        movement += hc.transform.right * hor * speed;
        movement.y = 0f;
        rb.velocity = movement;
    }
}
