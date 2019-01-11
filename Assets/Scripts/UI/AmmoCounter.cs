using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour {

    [SerializeField] Text text;
    PlayerShoot playerShoot;
	// Use this for initialization
	void Awake () {
        GameManager.Instance.OnLocalPlayerJoin += HandleOnLocalPlayerJoin;
	}
	
    void HandleOnLocalPlayerJoin(Player player)
    {
        playerShoot = player.GetComponent<PlayerShoot>();
        playerShoot.ActiveWeapon.reloader.OnAmmoChanged += HandleOnAmmoCahnged;
    }

    void HandleOnAmmoCahnged()
    {
        text.text = playerShoot.ActiveWeapon.reloader.RoundsRemainingInClip.ToString();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
