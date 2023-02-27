using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;
    
    FirstPersonMovement firstPersonMovement;

    [SerializeField] Text coinsText; 
    [SerializeField] AudioSource collectCoin;
    [SerializeField] AudioSource collectSpeed;
    [SerializeField] AudioSource collectJump;
    public float duration = 4f;

    private void Start ()
    {
        firstPersonMovement = GetComponent<FirstPersonMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
       StartCoroutine( Pickup(other) );
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
        if (other.gameObject.CompareTag("Jump Boost"))
        {
            Destroy(other.gameObject);
            firstPersonMovement.jumpForce = 10f;
            collectJump.Play();
            yield return new WaitForSeconds(duration);
            firstPersonMovement.jumpForce = 8f;
        }
        if (other.gameObject.CompareTag("Speed Boost"))
        {
            Destroy(other.gameObject);
            firstPersonMovement.moveSpeed = 7f;
            collectSpeed.Play();
            yield return new WaitForSeconds(duration);
            firstPersonMovement.moveSpeed = 4f;
        }
    }
}
