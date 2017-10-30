﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public InputType inputType;

    Character character;

	void Awake () {
        character = GetComponent<Character>();
	}
	
	void Update () {

        if (Input.GetKey(KeyCode.LeftShift)) {
            character.Run(GetInputVector());
        } else {
            character.Walk(GetInputVector());
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            character.Jump();
        }
	}

    Vector3 GetInputVector() {

        Vector3 input = Vector3.zero;

        if(inputType == InputType.Normal) {
            input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        } else if (inputType == InputType.Raw) {
            input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }

        return Camera.main.transform.TransformDirection(input).normalized;
    }

    public enum InputType { Normal, Raw }
}
