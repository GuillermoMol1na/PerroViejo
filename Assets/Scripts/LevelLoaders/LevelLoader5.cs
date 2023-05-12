using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader5 : MonoBehaviour
{
    private Animator transition;
    private Music_Manager mm;
    private int theDay;
    private int scene;

    void Start(){
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
        theDay = PlayerPrefs.GetInt("day");
        mm = GameObject.FindGameObjectWithTag("Audio_Manager").GetComponent<Music_Manager>();

        mm.Play("Track3-Game_Over",false);
    }
    public void LoadContinue(){
        mm.Play("Track6-Click",false);
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
        mm.Play("Track6-Click",false);
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
