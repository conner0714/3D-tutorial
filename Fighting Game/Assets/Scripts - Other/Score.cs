using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    [SerializeField] Text distanceText;
    private GameObject arrow;
    private Arrow arrowScript;
    private GameObject wayPoint;
    private float distance;
    private float distanceX;
    private float distanceY;
    private float distanceZ;
    // Start is called before the first frame update
    void Start()
    {
        
        arrow = GameObject.Find("Arrow");
        arrowScript = arrow.GetComponent<Arrow>();
        wayPoint = GameObject.Find("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        distanceX = (wayPoint.transform.position.x - transform.position.x) * (wayPoint.transform.position.x - transform.position.x);
        distanceY = (wayPoint.transform.position.y - transform.position.y) * (wayPoint.transform.position.y - transform.position.y);
        distanceZ = (wayPoint.transform.position.z - transform.position.z) * (wayPoint.transform.position.z - transform.position.z);
        distance = Mathf.Sqrt(distanceX + distanceY + distanceZ);
        distanceText.text = "Distance: " + distance;
        if (distance < 20f)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
        }
        if(transform.position.y < -1f)
        {
            arrowScript.damage = 80;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
    
    
}
