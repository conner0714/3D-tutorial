using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    private int enemyKillCount;

    public void IncreaseKillCount()
    {
        enemyKillCount++;
    }

    public int GetKillCount()
    {
        return enemyKillCount;
    }
}
