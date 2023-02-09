using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float reloadTime;

    [SerializeField] private Arrow arrowPrefab;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private AudioSource arrowShot;

    public Transform orientation;

    private Arrow currentArrow;

    private string enemyTag;

    private bool isReloading;

    private Vector3 fireRotation;

    public void SetEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void Reload ()
    {
        if (isReloading || currentArrow != null) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        currentArrow = Instantiate(arrowPrefab, spawnPoint);
        currentArrow.transform.localPosition = Vector3.zero;
        currentArrow.SetEnemyTag(enemyTag);
        isReloading = false;
    }

    public void fire(float firePower)
    {
        if(isReloading || currentArrow == null) return;
        fireRotation = new Vector3(0.01f * orientation.rotation.eulerAngles.x, 0.01f * orientation.rotation.eulerAngles.y, 0.001f * orientation.rotation.eulerAngles.z);
        var force = spawnPoint.TransformDirection(fireRotation * firePower);
        arrowShot.Play();
        currentArrow.Fly(force);
        currentArrow = null;
        Reload();
    }


    public bool IsReady()
    {
        return (isReloading && currentArrow != null);
    }
}
