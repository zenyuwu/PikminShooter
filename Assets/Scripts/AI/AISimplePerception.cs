using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISimplePerception : AIPerception
{

	public override GameObject[] GetGameObjects()
	{
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
        return objects;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
