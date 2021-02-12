using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLightsToSreetLight : MonoBehaviour {

    public GameObject leftLight;
    public GameObject rightLight;

	// Use this for initialization
	void Start () {
        Transform[] childs = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in childs)
        {
            GameObject leftLightObject = Instantiate<GameObject>(leftLight);
            GameObject rightLightObject = Instantiate<GameObject>(rightLight);
            leftLightObject.transform.parent = child.transform;
            leftLightObject.transform.position = child.transform.position;
            rightLightObject.transform.parent = child.transform;
            rightLightObject.transform.position = child.transform.position;
            leftLightObject.transform.localPosition = new Vector3(-0.271f, 0, 3.243f);
            leftLightObject.transform.localEulerAngles = new Vector3(0, 180f, 0);
            rightLightObject.transform.localPosition = new Vector3(0.271f, 0, 3.243f);
            rightLightObject.transform.localEulerAngles = new Vector3(0, 180f, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
