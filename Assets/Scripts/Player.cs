using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    InputController inputController;

	// Use this for initialization
	void Start () {
        inputController = GameManager.Instance.InputController;
	}
	
	// Update is called once per frame
	void Update () {
        print("Horizontal :" + inputController.Horizontal);
        print("Mouse :" + inputController.MouseInput);

    }
}
