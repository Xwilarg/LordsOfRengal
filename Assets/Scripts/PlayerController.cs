using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private GameObject gunEnd;
    [SerializeField]
    private GameObject bulletPrefab;

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
        if (isLocalPlayer)
        {
            // Movements and animations
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, hc.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z); // Rotate towards where the head is looking
            hc.transform.rotation = Quaternion.Euler(hc.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, hc.transform.rotation.eulerAngles.z);
            Vector3 movement = transform.forward * ver * speed;
            movement += transform.right * hor * speed;
            movement.y = 0f;
            rb.velocity = movement;

            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = Instantiate(bulletPrefab, gunEnd.transform.position, gunEnd.transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(gunEnd.transform.forward * 40f, ForceMode.Impulse);
                Destroy(bullet, 2000f); // 2sec
                NetworkServer.Spawn(bullet);
            }
        }
        anim.SetBool("IsRunning", rb.velocity != Vector3.zero);
    }
}
