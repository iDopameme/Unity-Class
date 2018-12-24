using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    private int currentScene;
    public static string message;
    private static TransitionManager instance;
    // public static string died;
    public static bool gonext = false;
    public static int player_life = 5;
    float endtime;
    public static bool neverDone = false;
    public static TransitionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TransitionManager>();
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)  //will only happen once!
        {//set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != null && instance != this)
            //Then destroy this. only ever be one instance of a GameManager.
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start()
    {
        //scoreboard if there's any goes here
        //if so, this may be helpful: DontDestroyOnLoad(this);
       // if (currentScene == 0)
           // AudioManager.Instance.PlaySong(0);
        currentScene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && currentScene == 0)
        {
            SceneManager.LoadScene(1);
            AudioManager.Instance.PlaySoundEffect(0);
            currentScene++;
        }
        if (Input.GetKeyDown(KeyCode.K) && currentScene == 1)
        {
            SceneManager.LoadScene(2);
            AudioManager.Instance.PlaySong(0);
            currentScene++;
        }
        if(neverDone == false) // This is in place so that the "you died" message only updates once
        {
            if (player_life == 0)
            {
                currentScene = 5;
                AudioManager.Instance.PlaySong(3);//effect
                message = "You Died.  (T_T)";
                SceneManager.LoadScene(5);
                neverDone = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && currentScene == 5)
        {
            currentScene = 0;
            AudioManager.Instance.PlaySong(0);
            SceneManager.LoadScene(0);
        }

        if (Time.time >= endtime && gonext == true)
            gonext = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
   // }
    //private void OnTriggerEnter2D(Collider2D collision)
   // {
        if (gonext == true && collision.gameObject.tag == "door")
        {
            if (currentScene == 2)
            {
                DontDestroyOnLoad(gameObject);
                SceneManager.LoadScene(3);
                AudioManager.Instance.PlaySong(1);
                currentScene++;
            }
            else if (currentScene == 3)//&&  the option after touch the door
            {
                SceneManager.LoadScene(4);
                AudioManager.Instance.PlaySong(1);
                currentScene++;
            }
            else if (currentScene == 4)/// the option after touch the door
            {
                AudioManager.Instance.PlaySong(2);//effect
                message = "You Escaped!!!! (^o^)";
                SceneManager.LoadScene(5);
            }
            endtime = Time.time + 250f ;
        }
    }
}