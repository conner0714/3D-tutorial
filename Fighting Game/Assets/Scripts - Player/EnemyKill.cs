using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    private int enemyKillCount;
    private GameObject door;

    public void Start()
    {
        door = GameObject.Find("Door");
    }

    public void Update()
    {
        if(enemyKillCount > 2)
        {
            Destroy(door);
        }
    }
    public void IncreaseKillCount()
    {
        enemyKillCount++;
    }

    public int GetKillCount()
    {
        return enemyKillCount;
    }
}
