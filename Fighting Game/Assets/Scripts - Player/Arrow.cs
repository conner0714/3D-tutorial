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

    public void SetEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void Fly(Vector3 force)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }
    void OnTriggerEnter(Collider collider)
        {
            if(didHit) return;
            didHit = true;

            if(enemyTag == null) return;

            if (collider.CompareTag(enemyTag))
            {
                collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                transform.SetParent(collider.transform);
            }

            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.isKinematic = true;
            //transform.SetParent(collider.transform);
        }
} 
