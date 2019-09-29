using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Rigidbody otherRb = collision.collider.GetComponent<Rigidbody>();
            if (otherRb != null)
                otherRb.AddForce(rb.velocity, ForceMode.Impulse);
        }
        Destroy(gameObject);
    }
}
