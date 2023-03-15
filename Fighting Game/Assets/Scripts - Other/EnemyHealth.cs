using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float HP = 200;
    public Slider healthBar; 
    private GameObject currentWarrior;
    private GameObject warriorHitbox;
    EnemyKill playerKillCount;
    private GameObject player;
    private Forward warriorScript;
    private int KillCount;
    private string shieldWarrior = "ShieldWarrior";
    

    void Start()
    {
        player = GameObject.Find("Player");
        playerKillCount = player.GetComponent<EnemyKill>();
        KillCount = playerKillCount.GetKillCount();
        for (int i = 0; i < KillCount; i++)
        {
            shieldWarrior = shieldWarrior + "(Clone)";
        }
        currentWarrior = GameObject.Find(shieldWarrior);
        HP = 200;
        playerKillCount = player.GetComponent<EnemyKill>();
    }

    void Update(){
        healthBar.value = HP;
    }
    
    public void TakeDamage(float damageAmount){
        HP -= damageAmount;
        Debug.Log(this);
        if(HP <= 0)
        {
            Debug.Log(currentWarrior);
            currentWarrior.GetComponent<Forward>().RespawnAfterTime();
            playerKillCount.IncreaseKillCount();
            Destroy(this.transform.parent.gameObject);
    
            //Play Death Animation
        } 
        else 
        {
            //Play Hit Animation
        }
    }


}
