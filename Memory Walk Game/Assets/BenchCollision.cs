using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchCollision : MonoBehaviour {

    private AudioSource imapctEffect;
    private AudioSource frictionEffect;
    // Use this for initialization
    void Start () {
        imapctEffect = gameObject.GetComponents<AudioSource>()[0];
        frictionEffect = gameObject.GetComponents<AudioSource>()[1];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!imapctEffect.isPlaying && collision.relativeVelocity.magnitude > 2)
            imapctEffect.Play();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= 2)
        {
            frictionEffect.volume = collision.relativeVelocity.magnitude / 10;
            frictionEffect.Play();
        }
    }
}
