using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWaterToHydrants : MonoBehaviour {

    public ParticleSystem parent;

	// Use this for initialization
	void Start () {
        ArrayList childs = new ArrayList();
        for (int id = 0; id < gameObject.transform.childCount; id++)
            childs.Add(gameObject.transform.GetChild(id));

        foreach(Transform child in childs)
        {
            ParticleSystem parentObject = Instantiate<ParticleSystem>(parent);
            parentObject.transform.parent = gameObject.transform;
            parentObject.transform.position = child.transform.position;
            child.transform.parent = parentObject.transform;
            parentObject.Stop();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
