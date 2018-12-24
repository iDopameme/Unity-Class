using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour {
    public Text player_life;
    public bool isTigger;
    // Use this for initialization
    void Start()
    {
        player_life.text = "Player life:" + TransitionManager.player_life.ToString();
    }
    // Update is called once per frame
    void Update()
    {   //isTigger = false;
        Debug.Log(TransitionManager.player_life.ToString());
        player_life.text = "Player life:" + TransitionManager.player_life.ToString();

    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Timer : MonoBehaviour
{
    public Text player_life;
    public bool isTigger;
    // Use this for initialization
    void Start()
    {
        player_life.text = "Red Score: " + TransitionManager.player_life.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        //isTigger = false;
        Debug.Log(TransitionManager.player_life.ToString());
        player_life.text = "Player life have: " + TransitionManager.player_life.ToString();

    }
}

/*    public int timeLeft = 3600; //Seconds Overall
    public Text countdown; //UI Text Object
   // public bool died = f;
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        countdown.text = ("" + timeLeft); //Showing the Score on the Canvas\

       /* if (timeLeft == 0)
            TransitionManager.died = "D";
    }
    //Simple Coroutine
    IEnumerator LoseTime()
{
    while (true)
    {
        yield return new WaitForSeconds(1);
        timeLeft--;
    }
}
*/
