using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader5 : MonoBehaviour
{
    public int theDay;
    private Animator transition;

    void Start(){
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
        //also this
        PlayerPrefs.SetInt("day",theDay);
    }
    public void LoadPCMenu(){
        StartCoroutine(TransitionTo(SceneManager.GetActiveScene().buildIndex -2));
    }
    public void LoadMainMenu(){
        StartCoroutine(TransitionTo(SceneManager.GetActiveScene().buildIndex -6));
    }
    IEnumerator TransitionTo(int levelIndex){
        if(transition != null){
        transition.SetTrigger("Start");
        }
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
