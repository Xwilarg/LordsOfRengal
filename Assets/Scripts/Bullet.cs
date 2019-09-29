using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : NetworkBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isServer)
            return;
        if (!collision.collider.CompareTag("Player"))
        {
            Rigidbody otherRb = collision.collider.GetComponent<Rigidbody>();
            if (otherRb != null)
                otherRb.AddForce(rb.velocity, ForceMode.Impulse);
        }
        Destroy(gameObject);
    }
}
