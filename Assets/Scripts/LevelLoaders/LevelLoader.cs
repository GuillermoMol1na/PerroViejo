using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private Collider2D stairsColl;
    private PlayerMovement player;
    public TMP_Text downStairs;
    public TMP_Text upStairs;
    public Animator transition;
    void Start(){
        downStairs.enabled= false;
        upStairs.enabled= false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        stairsColl = GameObject.FindGameObjectWithTag("Stairs").GetComponent<Collider2D>();
    }
    void Update()
    {
        if(player.baseColl.IsTouching(stairsColl)){
            downStairs.enabled=true;
            LoadLivingRoom();
        }
        
    }
    public void LoadLivingRoom(){
        downStairs.text="Tras bajar las escaleras...";
        StartCoroutine(TransitionLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadNextDay(){
        int ind = PlayerPrefs.GetInt("day");
        downStairs.enabled=true;
        downStairs.text="DIA "+ind;
        StartCoroutine(TransitionLevel(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator TransitionLevel(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
    void OnEnable(){
        Options_Answers.nextDay += LoadNextDay;
    }
    void OnDisable(){
        Options_Answers.nextDay -= LoadNextDay;
    }

}   
