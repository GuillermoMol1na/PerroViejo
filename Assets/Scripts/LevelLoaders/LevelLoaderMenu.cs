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

    public void LoadNewGame(){
        titleText.text="DIA 0";
        StartCoroutine(TransitionLivingRoom(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator TransitionLivingRoom(int levelIndex){
        transition.SetTrigger("Start");
        titleText.enabled=true;
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(levelIndex);
    }
    void OnEnable(){
        SettingsMenu.loadtheNewGame += LoadNewGame;
    }
    void OnDisable(){
        SettingsMenu.loadtheNewGame -= LoadNewGame;
    }

}
