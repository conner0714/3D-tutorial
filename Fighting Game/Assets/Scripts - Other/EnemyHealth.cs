using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float HP = 100;
    public Slider healthBar; 

    void Update(){
        healthBar.value = HP;
    }
    
    public void TakeDamage(float damageAmount){
        HP -= damageAmount;
        if(HP <= 0)
        {
            Destroy(this.transform.parent.gameObject);
            //Play Death Animation
        } 
        else 
        {
            //Play Hit Animation
        }
    }


}
