using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int HP = 100;
    
    public void TakeDamage(int damageAmount){
        HP -= damageAmount;
        if(HP <= 0)
        {
            Destroy(this.gameObject);
            //Play Death Animation
        } 
        else 
        {
            //Play Hit Animation
        }
    }


}
