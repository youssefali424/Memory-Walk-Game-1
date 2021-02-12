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
        triggerCollisionSound(collision.relativeVelocity.magnitude);
    }

    private void OnJointBreak(float breakForce)
    {
        Material[] mats = gameObject.GetComponent<Renderer>().materials;
        mats[1] = lightOffMat;
        gameObject.GetComponent<Renderer>().materials = mats;
        Light[] lights = gameObject.GetComponentsInChildren<Light>();
        foreach(Light light in lights)
            light.enabled = false;
        breakEffect.Play();
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
