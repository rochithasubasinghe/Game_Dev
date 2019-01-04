using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamara : MonoBehaviour {

    public Player LocalPlayer;
	void Awake () {
        GameManager.Instance.OnLocalPlayerJoin += HandleLocalPlayer;
	}

    private void HandleLocalPlayer(Player player)
    {
        LocalPlayer = player;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
