using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader4 : MonoBehaviour
{
    public int theDay;
    private Animator transition;

    void Start(){
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
        //also this
        PlayerPrefs.SetInt("day",theDay);
    }
    public void LoadLivingRoom(){
        StartCoroutine(TransitionNormal(SceneManager.GetActiveScene().buildIndex -2));
    }
    public void LoadGameOver(){
        StartCoroutine(TransitionGO(SceneManager.GetActiveScene().buildIndex +2));
    }
    void OnEnable(){
        Timer_1.goToGameOver += LoadGameOver;
        Email_App.goToGameOver += LoadGameOver;
    }
    void OnDisable(){
        Timer_1.goToGameOver -= LoadGameOver;
        Email_App.goToGameOver -= LoadGameOver;
    }

    IEnumerator TransitionNormal(int levelIndex){
        if(transition != null){
        transition.SetTrigger("Start");
        }
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
    IEnumerator TransitionGO(int levelIndex){
        yield return new WaitForSeconds(5);
        if(transition != null){
        transition.SetTrigger("Start");
        }
        SceneManager.LoadScene(levelIndex);
    }

}
