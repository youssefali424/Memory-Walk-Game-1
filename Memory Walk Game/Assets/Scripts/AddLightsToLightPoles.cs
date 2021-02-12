using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLightsToLightPoles : MonoBehaviour {

	public new GameObject light;
	// Use this for initialization
	void Start () {
        //Transform[] childs = gameObject.GetComponentsInChildren<Transform>();
        for (int id = 0; id < gameObject.transform.childCount; id++)
        {
            GameObject lightObject = Instantiate<GameObject>(light);
            lightObject.transform.parent = gameObject.transform.GetChild(id).transform;
            lightObject.transform.position = gameObject.transform.GetChild(id).transform.position;
            lightObject.transform.localPosition = new Vector3(0, 2.708f, 8.986f);
            lightObject.transform.localEulerAngles = new Vector3(0, 180f, 0);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
