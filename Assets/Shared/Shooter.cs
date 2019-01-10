using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] float rateOfFire;
    [SerializeField] Transform hand;
    [SerializeField] Projectile projectile;
    [HideInInspector]
    Transform muzzel;

    private WeaponReloader reloader;

    float nextFireAllowed;
    public bool canFire;

    void OnEnable()
    {
        transform.SetParent(hand);
    }

    void Awake()
    {
        muzzel = transform.Find("Muzzle");
        reloader = GetComponent<WeaponReloader>();

    }

    public void Reload(){
        if (reloader == null)
            return;
        reloader.Reload();
    }

    public virtual void Fire()
    {
     
        canFire = false;

        if (Time.time < nextFireAllowed)
            return;

        if (reloader != null)
        {
            if (reloader.IsReloading)
                return;
            if (reloader.RoundsRemainingInClip == 0)
                return;
            reloader.TakeFromClip(1);
        }

        nextFireAllowed = Time.time + rateOfFire;

        //instantiate the projectile;
        Instantiate(projectile, muzzel.position, muzzel.rotation);

        canFire = true;
    }
}
