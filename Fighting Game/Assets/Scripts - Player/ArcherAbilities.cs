using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAbilities : MonoBehaviour
{
    //Assignment
    FirstPersonMovement firstPersonMovement;
    Weapon bowController;
    GameObject player;
    GameObject bow;
    GameObject arrow;
    Arrow arrowScript;

    //Cooldown variables
    bool speedCooldown = true;
    bool bowCooldown = true;
    bool explosiveArrowsCooldown = true;


    void Start()
    {
        player = GameObject.Find("Player");
        bow = GameObject.Find("Bow");
        arrow = GameObject.Find("Arrow");
        bowController = bow.GetComponent<Weapon>();
        arrowScript = arrow.GetComponent<Arrow>();
        firstPersonMovement = player.GetComponent<FirstPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && speedCooldown)
        {
            StartCoroutine("SpeedBoost");  
        }

        if(Input.GetKeyDown(KeyCode.E) && bowCooldown)
        {
            StartCoroutine("SurvivalArrow");
        }

        if(Input.GetKeyDown(KeyCode.R) && explosiveArrowsCooldown)
        {
           StartCoroutine("ExplosiveArrows");
        }
    }

    IEnumerator SpeedBoost()
    {
        firstPersonMovement.moveSpeed = 6f;
        speedCooldown = false;
        yield return new WaitForSeconds(4f);
        firstPersonMovement.moveSpeed = 4f;
        yield return new WaitForSeconds(9f);
        speedCooldown = true;
    }

    IEnumerator SurvivalArrow()
    {
        bowController.reloadTime = 0.5f;
        bowCooldown = false;
        yield return new WaitForSeconds(4f);
        bowController.reloadTime = 1f;
        yield return new WaitForSeconds(9f);
        bowCooldown = true;
    }

    IEnumerator ExplosiveArrows()
    {
        Debug.Log("Hey");
        arrowScript.explosiveArrows = true;
        explosiveArrowsCooldown = false;
        yield return new WaitForSeconds(100f);
        arrowScript.explosiveArrows = false;
        yield return new WaitForSeconds(20f);
        explosiveArrowsCooldown = true;
    }
}
