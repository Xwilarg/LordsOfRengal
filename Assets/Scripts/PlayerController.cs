using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private HeadController hc;
    private float speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        hc = GetComponentInChildren<HeadController>();
    }

    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        anim.SetBool("IsRunning", hor != 0f || ver != 0f);
        Vector3 movement = hc.transform.forward * ver * speed;
        movement += hc.transform.right * hor * speed;
        movement.y = 0f;
        rb.velocity = movement;
    }
}
