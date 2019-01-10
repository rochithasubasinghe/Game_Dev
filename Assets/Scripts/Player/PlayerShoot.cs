using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    Shooter[] weapons;
    Shooter activeWeapon;

    int currentWeaponIndex;

    public Shooter ActiveWeapon
    {
        get
        {
            return activeWeapon;
        }
    }

    void Awake()
    {
        weapons = transform.Find("Weapons").GetComponentsInChildren<Shooter>();

        if (weapons.Length > 0)
            Equip(0);
    }

    void SwitchWeapon(int direction)
    {
        currentWeaponIndex += direction;

        if (currentWeaponIndex > weapons.Length - 1)
            currentWeaponIndex = 0;
        if (currentWeaponIndex < 0)
            currentWeaponIndex = weapons.Length - 1;

        Equip(currentWeaponIndex);
    }

    void Equip(int index)
    {
        activeWeapon = weapons[index];
    }


    void Update()
    {
        if (GameManager.Instance.InputController.MouseWheelDown)
            SwitchWeapon(1);
        if (GameManager.Instance.InputController.MouseWheelUp)
            SwitchWeapon(-1);

        if (GameManager.Instance.InputController.Fire1)
        {
            activeWeapon.Fire();
        }
    }
}
