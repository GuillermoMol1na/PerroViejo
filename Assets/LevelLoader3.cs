using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader3 : MonoBehaviour
{
    public Animator transition;
    public TMP_Text stairsMSG;
    void Start(){
    stairsMSG.enabled= false;
    }
    public void LoadLivingRoom(){
        StartCoroutine(TransitionLiving(1));
    }
    

    IEnumerator TransitionLiving(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);

    }
}   

