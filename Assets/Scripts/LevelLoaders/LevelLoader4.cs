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
        StartCoroutine(TransitionLiving(SceneManager.GetActiveScene().buildIndex -2));
    }
    public void LoadGameOver(){
        StartCoroutine(TransitionLiving(SceneManager.GetActiveScene().buildIndex +2));
    }
    void OnEnable(){
        Timer_1.goToGameOver += LoadGameOver;
    }
    void OnDisable(){
        Timer_1.goToGameOver -= LoadGameOver;
    }

    IEnumerator TransitionLiving(int levelIndex){
        if(transition != null){
        transition.SetTrigger("Start");
        }
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

}
