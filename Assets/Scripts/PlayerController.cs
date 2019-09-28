using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private float speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        anim.SetBool("IsRunning", hor != 0f && ver != 0f);
        rb.velocity = new Vector3(hor * speed, rb.velocity.y, ver * speed);
    }
}
