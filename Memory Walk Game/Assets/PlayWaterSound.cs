using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWaterSound : MonoBehaviour {

    private ParticleSystem ps;
    private AudioSource effect;
	// Use this for initialization
	void Start () {
        ps = gameObject.GetComponent<ParticleSystem>();
        effect = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (ps.isPlaying && !effect.isPlaying)
        {
            effect.Play();
        }
        
	}
}
