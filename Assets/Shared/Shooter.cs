using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] float rateOfFire;
    [SerializeField] Projectile projectile;
    [HideInInspector]
    public Transform muzzel;

    float nextFireAllowed;
    public bool canFire;

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

        //instantiate the projectile;
        Instantiate(projectile, muzzel.position, muzzel.rotation);

        canFire = true;
    }
}
