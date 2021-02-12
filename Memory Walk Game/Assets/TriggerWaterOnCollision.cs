using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWaterOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnJointBreak(float breakForce)
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        ParticleSystem ps = parent.GetComponent<ParticleSystem>();
        ps.Play();
    }
}
