using UnityEngine;

/// <summary>
/// Simple player controller based on a Rigidbody
/// </summary>
public class PlayerController : MonoBehaviour
{
    #region Public Variables
    
    public float Speed = 30.0F;
    public float JumpForce = 10.0F; 

    #endregion

    #region Private Variables
    
    private Rigidbody thisRigidbody;
    private bool isJumping; 
	//private float gravity = 9.81f;

    #endregion

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        isJumping = false;
    }

    void Update()
    {

		//Moves Forward and back along z axis                           //Up/Down
		transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical")* Speed);
		//Moves Left and right along x Axis                               //Left/Right
		transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal")* Speed);      

        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
			thisRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

       //thisRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, thisRigidbody.velocity.y);
    }

    void OnCollisionEnter(Collision collision)
    {
        isJumping = false;

        if (collision.gameObject.tag == "Enemy")
        {
            thisRigidbody.transform.position = CheckPoint.GetActiveCheckPointPosition();
        }

    }


}