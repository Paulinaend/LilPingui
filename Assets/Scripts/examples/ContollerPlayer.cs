using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterLocomotion))]
public class ContollerPlayer : MonoBehaviour {


    private CharacterLocomotion character;

    private bool jump;

    void Awake ()
    {
        character = GetComponent<CharacterLocomotion>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (!jump) jump = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        bool run = Input.GetKey(KeyCode.LeftShift);

        character.Move(!run ? hor : hor *= 3, jump);

        jump = false;
    }
}
