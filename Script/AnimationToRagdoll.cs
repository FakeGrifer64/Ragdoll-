using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationToRagdoll : MonoBehaviour
{

    [SerializeField] Collider myCollider;
    [SerializeField] float respawnTime = 30f;
    Rigidbody[] rigidbodies;
    bool bIsRagdoll = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        ToggleRagdoll(true);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Colisão detectada com:" + $"{collision.gameObject.name}" + $"- Tag:{collision.gameObject.tag}-bIsRagdoll:" + $"{bIsRagdoll}");

        if (collision.gameObject.CompareTag("Projectile") && !bIsRagdoll)
        {
            Debug.Log("Colidiu com projétil!");
            ToggleRagdoll(false);
           StartCoroutine(GetBackUp()); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Colisão detectada com:" + $"{other.gameObject.name}" + $"- Tag:{other.gameObject.tag}-bIsRagdoll:" + $"{bIsRagdoll}");

        if (other.gameObject.CompareTag("Projectile") && !bIsRagdoll)
        {
            Debug.Log("Colidiu com projétil!");
            ToggleRagdoll(false);
            StartCoroutine(GetBackUp());
        }
    }
    private IEnumerator GetBackUp()
    {
        yield return new WaitForSeconds(respawnTime);
        ToggleRagdoll(true);
    }
    
    private void ToggleRagdoll(bool bisAnimating)
    {
        bIsRagdoll = !bisAnimating;
        myCollider.enabled = bisAnimating;

        //foreach(Rigidbody ragdollBone in rigidbodies)
        //{
        //    Debug.Log($"{ragdollBone.name}isKinematic=" + $"{ragdollBone.isKinematic}");

        //}
        foreach (Rigidbody ragdollBone in rigidbodies)
        {
            ragdollBone.isKinematic = bisAnimating;
        }
        GetComponent<Animator>().enabled = bisAnimating;
        if (bisAnimating) 
        { 
            RandomAnimation();
        }
    }

    void RandomAnimation()
    {
        int randomNum = UnityEngine.Random.Range(0, 2);
        Debug.Log(randomNum);
        Animator animator = GetComponent<Animator>();

        if(randomNum == 0)
        {
            animator.SetTrigger("Walk");
        }
        else
        {
            animator.SetTrigger("Idle");
            animator.SetTrigger("Get Up");
        
        }

    }
}


