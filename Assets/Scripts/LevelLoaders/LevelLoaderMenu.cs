using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoaderMenu : MonoBehaviour
{
    public TMP_Text titleText;
    public Animator transition;
    private Music_Manager mm;

    void Start(){
        titleText.enabled=false;
        mm = GameObject.FindGameObjectWithTag("Audio_Manager").GetComponent<Music_Manager>();
    }

    public void LoadGame(int currentDay){
        titleText.text="DIA "+currentDay;
        StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void ReturnToStart(){
        titleText.text="GRACIAS POR JUGAR";
        StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex));
    }


    IEnumerator Transition(int levelIndex){
        transition.SetTrigger("Start");
        titleText.enabled=true;
        mm.SlowStop("Track0_MainMenu");
        yield return new WaitForSeconds(2);
        mm.StartMain();
        SceneManager.LoadScene(levelIndex);
    }
    void OnEnable(){
        SettingsMenu.loadtheNewGame += LoadGame;
        SettingsMenu.loadtheReturn += ReturnToStart;
    }
    void OnDisable(){
        SettingsMenu.loadtheNewGame -= LoadGame;
        SettingsMenu.loadtheReturn -= ReturnToStart;
    }

}
