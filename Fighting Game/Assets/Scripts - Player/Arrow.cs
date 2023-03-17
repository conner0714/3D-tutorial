using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float torque;

    [SerializeField] private Rigidbody rigidbody;

    private string enemyTag;
    
    private bool didHit;

    public bool explosiveArrows = false;

    public Transform attackPoint;
    public float attackRange = 3f;
    private string trackTag = "Enemy Head";

    public void SetEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void Fly(Vector3 force)
    {
        Debug.Log(force);
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }
    void OnTriggerEnter(Collider collider)
        {
            if(explosiveArrows)
            {
                Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position, attackRange);
                foreach (var hitCollider in hitColliders)
                {       
                    if (hitCollider.CompareTag(trackTag))
                    {
                        hitCollider.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
                    };
                }
            }

            if(didHit) return;
            didHit = true;

            if(enemyTag == null) return;

            if (collider.CompareTag(enemyTag))
            {
                collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }

            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.isKinematic = true;
            //transform.SetParent(collider.transform);
        }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
} 
