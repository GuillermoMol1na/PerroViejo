using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader3 : MonoBehaviour
{
    private Animator transition;
    public TMP_Text stairsMSG;

    public int theDay;
    public int completed;
    void Start(){
        PlayerPrefs.SetInt("day",theDay);
        PlayerPrefs.SetInt("dayCompleted",completed);
        if(stairsMSG != null){
            stairsMSG.enabled= false;
        }
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
    }
    public void LoadLivingRoom(){
        StartCoroutine(TransitionLiving(SceneManager.GetActiveScene().buildIndex -1));
    }
    IEnumerator TransitionLiving(int levelIndex){
        if(transition != null){
        transition.SetTrigger("Start");
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
}   

