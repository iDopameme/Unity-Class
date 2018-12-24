using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontrol : MonoBehaviour
{
    //  public float speed;
    //public GameObject play1;
    //public bool IsDying = false;
    //public bool isTrigger = false;
    public GameObject play1;
    float endtime;
    private int currentScene;
    public Vector2 resetPos;

    // Use this for initialization
    void Start()
    {
        // speed = -1;
        if (currentScene == 2)
            resetPos = new Vector2(0f, 0f);
        //play1.transform.position = new Vector2(-30.77f, 7.63f);// need change based on player location
        else if (currentScene == 3)
            resetPos = new Vector2(-14f, 7f);
        //play1.transform.position = new Vector2(-7.6f, -0.13f);// need change based on player location
        else if (currentScene == 4)
            resetPos = new Vector2(-8f, 3f);
        //play1.transform.position = new Vector2(-7.6f, -0.13f);// need change based on player location

        //resetPos = play1.transform.position;
        //  if (Time.time >= endtime && isTrigger == true)
        //    isTrigger = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //PersonController.IsDying = true;
            Debug.Log("Player hit bomb");
            AudioManager.Instance.PlaySoundEffect(3);
            TransitionManager.player_life--;
            collision.transform.position = resetPos;
            endtime = Time.time + 2f;

        }
        Destroy(this.gameObject);
    }
}
      