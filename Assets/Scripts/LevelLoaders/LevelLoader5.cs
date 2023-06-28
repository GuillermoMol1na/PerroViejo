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
        StartCoroutine(TransitionTo(SceneManager.GetActiveScene().buildIndex - 1));
    }
    public void LoadMainMenu(){
        mm.Play("Track6-Click",false);
        StartCoroutine(TransitionTo(SceneManager.GetActiveScene().buildIndex - 5));
    }
    IEnumerator TransitionTo(int levelIndex){
        if(transition != null){
        transition.SetTrigger("Start");
        }
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
