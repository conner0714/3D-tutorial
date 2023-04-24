using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    GameObject arrow;
    Arrow arrowScript;
    // Start is called before the first frame update
    void Start()
    {
        
        arrow = GameObject.Find("Arrow");
        arrowScript = arrow.GetComponent<Arrow>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -1f)
        {
            arrowScript.damage = 80;
        }
    }
    
    
}
