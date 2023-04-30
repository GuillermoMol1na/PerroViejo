using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader5 : MonoBehaviour
{
    private Animator transition;
    private int theDay;
    private int scene;

    void Start(){
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
        theDay = PlayerPrefs.GetInt("day");
    }
    public void LoadContinue(){
        switch(theDay){
            case 2:
                scene= 4;
            break;
            default:
                scene=2;
            break;
        }
        StartCoroutine(TransitionTo(SceneManager.GetActiveScene().buildIndex -scene));
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
