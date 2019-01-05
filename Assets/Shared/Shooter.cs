using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] float rateOfFire;
    [HideInInspector]
    public Transform muzzel;

    float nextFireAllowed;
    bool canFire;

    void Awake()
    {
        muzzel = transform.Find("Muzzle");

    }
    
    public virtual void Fire()
    {
     
        canFire = false;

        if (Time.time < nextFireAllowed)
            return;

        nextFireAllowed = Time.time + rateOfFire;

        canFire = true;
    }
}
