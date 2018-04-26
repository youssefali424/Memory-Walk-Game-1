using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavMeshGo : MonoBehaviour {
	public Transform[]  targerts;

	int i = 0;
	NavMeshAgent agent;
// not yet	Animator anim;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (targerts[i].position);
	//	anim = GetComponent<Animator> ();
		/* speed for human is good from 2 to 3.5 
		 * angular speed doesn't really matter 
		 *However Stopping distance must be more than 0 if we have more than one person going to the same destination
					*/
}
	
	// Update is called once per frame
	void Update () {
		//Becuase the agent.remainigDistance Method isn't calculated until the destination is set or whatever shit happen 
		//I'm gonna need to calculaote the destinance as follows

		if (Vector3.Distance (targerts [i].position, transform.position) < 5f) {
			if (++i >= targerts.Length)
				i = 0;
			agent.SetDestination (targerts [i].position);
			//Debug.Log ("reached");

		}

	}
}
