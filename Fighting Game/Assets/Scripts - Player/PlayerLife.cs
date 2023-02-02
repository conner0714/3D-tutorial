using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource death;
    bool dead = false;
    private void Update()
    {
        if (transform.position.y < -1f && !dead){
            Die();
        }
    }
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Die();
        }
    }
    void Die()
    {
        death.Play();
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(169, 169, 169);
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
        
    }



    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
