using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStart : MonoBehaviour {

    GameUIController control;

	// Use this for initialization
	void Start () {
        control = GameObject.FindObjectOfType<GameUIController>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0))
        {
            control.StartGame();
        }

	}
}
