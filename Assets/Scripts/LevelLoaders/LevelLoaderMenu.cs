using System.Collections;
using System.Collections.Generic;using TMPro;
using UnityEngine.SceneManagement;using UnityEngine;

public class LevelLoaderMenu : MonoBehaviour
{
    public TMP_Text titleText;
    public Animator transition;

    void Start(){
        titleText.enabled=false;
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
        yield return new WaitForSeconds(2);

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
