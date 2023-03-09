using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;
    
    FirstPersonMovement firstPersonMovement;
    private GameObject playerHealthCanvas;
    PlayerHP playerHP;

    [SerializeField] Text coinsText; 
    [SerializeField] AudioSource collectCoin;
    [SerializeField] AudioSource collectSpeed;
    [SerializeField] AudioSource collectJump;
    public float duration = 4f;

    private void Start ()
    {
        playerHealthCanvas = GameObject.Find("Player Stats Overview");
        firstPersonMovement = GetComponent<FirstPersonMovement>();
        playerHP = playerHealthCanvas.GetComponent<PlayerHP>();
        Debug.Log(firstPersonMovement.moveSpeed);
        Debug.Log(playerHP.HP);
    }

    private void OnTriggerEnter(Collider other)
    {
       StartCoroutine(Pickup(other));
    }
    

    IEnumerator Pickup (Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            collectCoin.Play();
            coins++;
            coinsText.text = "Coins: " + coins;
        } 
        else if (other.gameObject.CompareTag("Jump Boost"))
        {
            Destroy(other.gameObject);
            firstPersonMovement.jumpForce = 10f;
            collectJump.Play();
            yield return new WaitForSeconds(duration);
            firstPersonMovement.jumpForce = 8f;
        }
        else if (other.gameObject.CompareTag("Speed Boost"))
        {
            Destroy(other.gameObject);
            firstPersonMovement.moveSpeed = 7f;
            collectSpeed.Play();
            yield return new WaitForSeconds(duration);
            firstPersonMovement.moveSpeed = 4f;
        }
        else if (other.gameObject.CompareTag("Regeneration"))
        {
            Destroy(other.gameObject);
            playerHP.regenAmount = 10f;
            collectSpeed.Play();
            yield return new WaitForSeconds(duration);
            playerHP.regenAmount = 5f;
        }
        else if (other.gameObject.CompareTag("MedicalKit"))
        {
            Destroy(other.gameObject);
            playerHP.HP = 200;
            collectSpeed.Play();
        }
    }
}
 /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            collectCoin.Play();
            coins++;
            coinsText.text = "Coins: " + coins;
        }
        if (other.gameObject.CompareTag("Jump Boost"))
        {
            Destroy(other.gameObject);
            firstPersonMovement.jumpForce = 100f;
            collectJump.Play();
            StartCoroutine("PowerUpDuration");
            firstPersonMovement.jumpForce = 8f;
        }
        if (other.gameObject.CompareTag("Speed Boost"))
        {
            Destroy(other.gameObject);
            firstPersonMovement.moveSpeed = 7f;
            collectSpeed.Play();
            StartCoroutine("PowerUpDuration");
            firstPersonMovement.moveSpeed = 4f;
        }
        if (other.gameObject.CompareTag("Regeneration"))
        {
            Destroy(other.gameObject);
            playerHP.regenAmount = 10f;
            collectSpeed.Play();
            StartCoroutine("PowerUpDuration");
            playerHP.regenAmount = 5f;
        }
        if (other.gameObject.CompareTag("MedicalKit"))
        {
            Destroy(other.gameObject);
            playerHP.HP = 200;
            collectSpeed.Play();
        }
    }

    IEnumerator PowerUpDuration()
    {
        yield return new WaitForSeconds(duration);
    }
    */
