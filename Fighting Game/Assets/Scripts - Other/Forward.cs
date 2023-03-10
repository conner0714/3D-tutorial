using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    [SerializeField] AudioSource slash;
    private GameObject wayPoint;
    private GameObject warrior;
    private Vector3 wayPointPos;
    private Vector3 warriorPos;
    private Animator mAnimator;
    private float attackCooldown = 1f;
    private bool swing = true;
    private int powerSelector;
    bool powerUpOn = true;
    private GameObject player;
    PlayerLife playerDamage;
    PlayerFollow warriorFollower;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerDamage = player.GetComponent<PlayerLife>();
        warriorFollower = GetComponent <PlayerFollow>();
        mAnimator = GetComponent<Animator>();
        wayPoint = GameObject.Find("wayPoint");
        warrior = GameObject.Find("ShieldWarrior");
    }

    // Update is called once per frame
    void Update()
    {
        if(mAnimator != null)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                mAnimator.SetTrigger("TrForwardLeft");   
            }

            if(Input.GetKeyDown(KeyCode.X))
            {
                mAnimator.SetTrigger("TrForward");
            }

            if(Input.GetKeyDown(KeyCode.C))
            {
                mAnimator.SetTrigger("TrForwardRight");
            }

            if(Input.GetKeyDown(KeyCode.V))
            {
                mAnimator.SetTrigger("TrLeft");
            }

            if(Input.GetKeyDown(KeyCode.B))
            {
                mAnimator.SetTrigger("TrRight");
            }

            if(Input.GetKeyDown(KeyCode.N))
            {
                mAnimator.SetTrigger("TrBackwardLeft");
            }

            if(Input.GetKeyDown(KeyCode.M))
            {
                mAnimator.SetTrigger("TrBackward");
            }

            if(Input.GetKeyDown(KeyCode.L))
            {
                mAnimator.SetTrigger("TrBackwardRight");
            }

            if(Input.GetKeyDown(KeyCode.P))
            {
                mAnimator.SetTrigger("Attack");
            }
            if(powerUpOn)
            {
                StartCoroutine("WarriorPowerUp");
            }
            if((Mathf.Abs(wayPoint.transform.position.x - warrior.transform.position.x) < 2) &&
            (Mathf.Abs(wayPoint.transform.position.y - warrior.transform.position.y) < 4) &&
            (Mathf.Abs(wayPoint.transform.position.z - warrior.transform.position.z) < 2) && swing)
            {
                mAnimator.SetTrigger("Attack");
                StartCoroutine("SwingDelay");
                swing = false;
                StartCoroutine("Reset");
            }
            
        }
        
    }

    IEnumerator WarriorPowerUp()
    {
        powerUpOn = false;
        powerSelector = Random.Range(1, 3);
        if (powerSelector == 1)
        {
            warriorFollower.speed = 4f;
            slash.Play();
        }
        if (powerSelector == 2)
        {
            playerDamage.damage = 40;
            slash.Play();
        }
        yield return new WaitForSeconds(5f);
        powerUpOn = true;
    }

    IEnumerator SwingDelay() 
    {
        yield return new WaitForSeconds(.5f);
        slash.Play();
    } 

    IEnumerator Reset() 
    {
        // your process
        yield return new WaitForSeconds(attackCooldown);
        // continue process
        swing = true;
    } 
}
