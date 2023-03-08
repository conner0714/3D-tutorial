using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float HP = 200;
    public Slider healthBar; 

    public GameObject shieldWarriorPrefab;

    public Transform spawnPoint;

    void Update(){
        healthBar.value = HP;
    }
    
    public void TakeDamage(float damageAmount){
        HP -= damageAmount;
        Debug.Log(this);
        if(HP <= 0)
        {
            Destroy(this.transform.parent.gameObject);
            Instantiate(shieldWarriorPrefab, spawnPoint);
            //Play Death Animation
        } 
        else 
        {
            //Play Hit Animation
        }
    }


}
