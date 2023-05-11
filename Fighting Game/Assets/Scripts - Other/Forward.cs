using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    [SerializeField] AudioSource slash;
    private GameObject wayPoint;
    private GameObject currentWarrior;
    private Vector3 wayPointPos;
    private Vector3 warriorPos;
    private Animator mAnimator;
    private float attackCooldown = 1f;
    private bool swing = true;
    private int powerSelector;
    bool powerUpOn = true;
    private GameObject player;
    private PlayerLife playerDamage;
    private EnemyKill playerKillCount;
    private int KillCount;
    private PlayerFollow warriorFollower;
    public Transform spawnPoint;
    public GameObject shieldWarriorPrefab;
    EnemyHealth enemyHP;
    private GameObject warriorHitbox;
    private string cloneCounter = "ShieldWarrior";
    private GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerDamage = player.GetComponent<PlayerLife>();
        wayPoint = GameObject.Find("wayPoint");
        playerKillCount = player.GetComponent<EnemyKill>();
        KillCount = playerKillCount.GetKillCount();
        for (int i = 0; i < KillCount; i++)
        {
            cloneCounter = cloneCounter + "(Clone)";
        }
        currentWarrior = GameObject.Find(cloneCounter);
        warriorFollower = currentWarrior.GetComponent<PlayerFollow>();
        mAnimator = currentWarrior.GetComponent<Animator>();
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
            if((Mathf.Abs(wayPoint.transform.position.x - currentWarrior.transform.position.x) < 2) &&
            (Mathf.Abs(wayPoint.transform.position.y - currentWarrior.transform.position.y) < 4) &&
            (Mathf.Abs(wayPoint.transform.position.z - currentWarrior.transform.position.z) < 2) && swing)
            {
                mAnimator.SetTrigger("Attack");
                StartCoroutine("SwingDelay");
                swing = false;
                StartCoroutine("Reset");
            } 
        }
        
    }


    public void RespawnAfterTime()
    {
        currentWarrior = Instantiate(shieldWarriorPrefab, spawnPoint);
        currentWarrior.transform.localPosition = Vector3.zero;
    }

    IEnumerator WarriorPowerUp()
    {
        powerUpOn = false;
        powerSelector = Random.Range(2, 3);
        if (powerSelector == 1)
        {
            
            playerDamage.damage = 100;
            /*
            sword = GameObject.Find("RightSword");
            sword.GetComponent<MeshRenderer>().material.color = new Color(0/256f, 113/256f, 13/256f);
            slash.Play();

            yield return new WaitForSeconds(5f);
            sword.GetComponent<MeshRenderer>().material.color = new Color(255/256f, 255/256f, 255/256f);
            playerDamage.damage = 20;
            */
        }
        if (powerSelector == 2)
        {
            mAnimator.SetTrigger("TrForward");
            slash.Play();
            yield return new WaitForSeconds(5f);
            mAnimator.SetTrigger("Attack");
        }
        yield return new WaitForSeconds(1f);
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

    public string warriorReturn()
    {
        return cloneCounter;
    }
}
