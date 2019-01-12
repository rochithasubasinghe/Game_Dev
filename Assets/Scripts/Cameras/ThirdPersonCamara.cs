using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamara : MonoBehaviour {

    [SerializeField] Vector3 camaraOffset;
    [SerializeField] float Damping;
    Transform CamaraLookTarget;


    public Player LocalPlayer;
	void Awake () {
        GameManager.Instance.OnLocalPlayerJoin += HandleLocalPlayer;
	}

    private void HandleLocalPlayer(Player player)
    {
        LocalPlayer = player;
        CamaraLookTarget = LocalPlayer.transform.Find("camaraLookTarget");
        if (CamaraLookTarget == null)
            CamaraLookTarget = LocalPlayer.transform;
    }
    
    void Update () {
        if (LocalPlayer == null)
            return;

        Vector3 targetPosisiton = CamaraLookTarget.transform.position + LocalPlayer.transform.forward * camaraOffset.z
                                                  + LocalPlayer.transform.up * camaraOffset.y + LocalPlayer.transform.right * camaraOffset.x;

        Quaternion targetRotation = Quaternion.LookRotation(CamaraLookTarget.position - targetPosisiton, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosisiton, Damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Damping * Time.deltaTime);

    }
}
