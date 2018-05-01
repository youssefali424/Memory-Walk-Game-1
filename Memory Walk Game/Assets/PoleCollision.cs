using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleCollision : MonoBehaviour {

    private AudioSource collidEffect;
    private AudioSource breakEffect;
    public Material lightOffMat;

	// Use this for initialization
	void Start () {
        collidEffect = GetComponents<AudioSource>()[0];
        breakEffect = GetComponents<AudioSource>()[1];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collidEffect.isPlaying && collision.relativeVelocity.magnitude >= 2)
        {
            collidEffect.volume = collision.relativeVelocity.magnitude / 20;
            collidEffect.Play();
        }
    }

    private void OnJointBreak(float breakForce)
    {
        Material[] mats = gameObject.GetComponent<Renderer>().materials;
        mats[1] = lightOffMat;
        gameObject.GetComponent<Renderer>().materials = mats;
        gameObject.GetComponentInChildren<Light>().enabled = false;
        breakEffect.Play();
        if (!collidEffect.isPlaying && breakForce >= 2)
        {
            collidEffect.volume = breakForce / 20;
            collidEffect.Play();
        }
    }
}
