using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{

    public const float baseSpeed = 6.0f;
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController charController;

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
        Debug.Log(speed);
    }

	void Start ()
    {
       charController = GetComponent<CharacterController>();
	}
	
	void Update ()
    {
        /*
        if (Input.GetKey(KeyCode.LeftShift)) //GetKeyDown for press
        {
            speed = 10;
        }
        else
        {
            speed = 6;
        }
        */

        //You can find input names and mappings under edit -> project settings -> input
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed); //fix diagonal speed

        movement.y = gravity;

        if (Input.GetKey(KeyCode.Space)) //GetKeyDown for press
        {
            movement.y += 20;
        }

        movement *= Time.deltaTime; //frame independant speed
        movement = transform.TransformDirection(movement); //transform movement from local to global space

        charController.Move(movement);
	}
}
