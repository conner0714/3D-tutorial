using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 3f;
    private string enemyTag = "Enemy Head";

    [SerializeField] AudioSource meleeHit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
    }

    /*
    void Attack()
    {
       Collider3D[] hitEnemies = Physics3D.OverlapSphereAll(attackPoint.position, attackRange, enemyLayers);

       foreach(Collider3D enemy in hitEnemies)
       {
           Debug.Log("yay");
       }
    }
    */
    void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position, attackRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(enemyTag))
            {
                hitCollider.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
                meleeHit.Play();
            };
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
