using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader4 : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator transition;

    void Start(){
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
    }
    public void LoadLivingRoom(){
        StartCoroutine(TransitionLiving(SceneManager.GetActiveScene().buildIndex -2));
    }
    

    IEnumerator TransitionLiving(int levelIndex){
        if(transition != null){
        transition.SetTrigger("Start");
        }
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);

    }
}
