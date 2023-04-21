using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource death;
    bool dead = false;
    bool canGetHit = true;
    public int damage = 20;
    private GameObject playerHealthCanvas;
    public Slider healthBar;

    private void Start()
    {
        playerHealthCanvas = GameObject.Find("Player Stats Overview");
    }

    private void Update()
    {
        if (transform.position.y < -1f && !dead){
            Die();
        }
    }
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword") && canGetHit)
        {
            playerHealthCanvas.GetComponent<PlayerHP>().PlayerDamaged(damage);
            canGetHit = false;
            if(playerHealthCanvas.GetComponent<PlayerHP>().GetHealth() <= 0)
            {
                healthBar.value = 0;
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
                //GetComponent<Player>().enabled = false;
                Die();
            }
            StartCoroutine("InvincibilityFrames");
        }
    }
    void Die()
    {
        death.Play();
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(169/256f, 169/256f, 169/256f);
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
        
    }

     IEnumerator InvincibilityFrames() 
    {
        // your process
        yield return new WaitForSeconds(0.5f);
        // continue process
        canGetHit = true;
    } 


    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
