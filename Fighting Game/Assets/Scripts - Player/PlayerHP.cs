using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    bool regen = true;
    public float regenAmount = 5f;
    public float HP = 200;
    public Slider healthBar; 
    [SerializeField] Text playerHealthText;

    void Update(){
        healthBar.value = HP;
        playerHealthText.text = "" + HP;
        if(regen && HP < 200)
        {
            StartCoroutine("Regeneration");
            if(HP > 200)
            {
                HP = 200;
            }
        }
    }
    
    public void PlayerDamaged(float damageAmount){
        HP -= damageAmount;
    }

    public float GetHealth()
    {
        return HP;
    }

    IEnumerator Regeneration()
    {
        regen = false;
        yield return new WaitForSeconds(2);
        HP += 5;
        regen = true;
    }
}
