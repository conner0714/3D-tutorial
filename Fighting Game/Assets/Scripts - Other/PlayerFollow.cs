using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    //You may consider adding a rigid body to the zombie for accurate physics simulation
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    public Transform cam;
    private bool canLevitate;

    //T$$anonymous$$s will be the zombie's speed. Adjust as necessary.
    public float speed = 3.0f;
    void Start ()
    {
      //At the start of the game, the zombies will find the gameobject called wayPoint.
      wayPoint = GameObject.Find("wayPoint");
      StartCoroutine("Levitation");
    }
 
    void Update ()
    {

      if(canLevitate)
      {
        wayPointPos = wayPointPos = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, wayPoint.transform.position.z);
      } 
      else
      {
        wayPointPos = new Vector3(wayPoint.transform.position.x, 0.12f, wayPoint.transform.position.z);
      }
      //Here, the zombie's will follow the waypoint.
      transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
      transform.LookAt(cam);
    }

    IEnumerator Levitation()
    {
      yield return new WaitForSeconds(20f);
      canLevitate = true;
    }
}
