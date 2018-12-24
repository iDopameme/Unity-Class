using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour {
    private int currentScene;
    public bool isTrigger = false;
    // Vector2 doorPos;
    //public GameObject door;
    float endtime;

    // Use this for initialization
    void Start () {
        
    }
    // Update is called once per frame
    void Update () {
//if (Time.time >= endtime && isTrigger == true)
  //          isTrigger = false;

    }
   /* public void OnTriggerEnter2D(Collider2D collision)// in colloder ckeck IStriggrts then it touch the object will have effect
    {
        if (!isTrigger)
        {
            if (KeyScript.open == true)
            {
                isTrigger = true;
                TransitionManager.gonext = true;
                Debug.Log("Door is Open");
                AudioManager.Instance.PlaySoundEffect(5);
                endtime = Time.time + 2f;
            }
        }
    }*/
            
}
