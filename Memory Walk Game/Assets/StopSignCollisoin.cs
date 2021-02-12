using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSignCollisoin : MonoBehaviour {

    private AudioSource collidEffect;
    // Use this for initialization
    void Start () {
        collidEffect = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        triggerCollisionSound(collision.relativeVelocity.magnitude);
    }

    private void OnJointBreak(float breakForce)
    {
        triggerCollisionSound(breakForce);
    }

    private void triggerCollisionSound(float force)
    {
        if (!collidEffect.isPlaying && force >= 2)
        {
            collidEffect.volume = force / 20;
            collidEffect.Play();
        }
    }
}
