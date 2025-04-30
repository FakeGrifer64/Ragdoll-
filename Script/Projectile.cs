using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void OnTriggerEnter(Collider Collision)
    {
        
        if (Collision.CompareTag("Player"))
        {
            gameObject.transform.SetParent(Collision.transform);

            GetComponent<Collider>().enabled = false;
            GetComponent<ConstantForce>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
