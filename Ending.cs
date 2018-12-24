using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour {
    public Text end;
    // Use this for initialization
    void Start ()
    {
        end.text = TransitionManager.message.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
