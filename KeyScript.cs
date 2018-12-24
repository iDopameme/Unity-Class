using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    //public static bool open=false;
    public bool open = false;
   // public GameObject OpenedDoor;
    private int currentScene;
    public Vector2 doorPos;
    public GameObject doorO;
   float endtime;
    // Use this for initialization
    void Start()
    { }

    private void Update()
    {   //if  (open == true)
           
        if (Time.time >= endtime && open == true)
            open = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!open)
        {
            if (collision.gameObject.tag == "Player")
            {
                open = true;
                Debug.Log("Player got key");
                PersonController.abc = true;
                AudioManager.Instance.PlaySoundEffect(2);
                endtime = Time.time + 250f;
            }
           Destroy(this.gameObject);
        }
        
    }
}