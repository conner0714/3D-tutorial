using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [SerializeField]
    private Weapon weapon;

    [SerializeField]
    private string enemyTag;

    [SerializeField]
    private float maxFirePower;

    [SerializeField]
    private float firePowerSpeed;

    private float firePower;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float minRotation;

    [SerializeField]
    private float maxRotation;

    private float mouseY;

    private bool fire;

    void Start()
    {
        weapon.SetEnemyTag(enemyTag);
        weapon.Reload();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseY -= Input.GetAxis("Mouse Y") * rotateSpeed;
        mouseY = Mathf.Clamp(mouseY, minRotation, maxRotation);
        //weapon.transform.localRotation = Quaternion.Euler(mouseY, weapon.transform.localEulerAngles.y, weapon.transform.localEulerAngles.z);

        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
        }

        if (fire && firePower < maxFirePower)
        {
            firePower += Time.deltaTime * firePowerSpeed;
            Debug.Log(Time.deltaTime);
        }

        if (fire && Input.GetMouseButtonUp(0))
        {
            weapon.fire(firePower);
            firePower = 0;
            fire = false;
        }
    }
}
