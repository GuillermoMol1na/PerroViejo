using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private Collider2D stairsColl;
    private PlayerMovement player;
    public TMP_Text downStairs;
    public TMP_Text upStairs;
    public Animator transition;
    void Start(){
        downStairs.enabled= false;
        upStairs.enabled= false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        stairsColl = GameObject.FindGameObjectWithTag("Stairs").GetComponent<Collider2D>();
    }
    void Update()
    {
        if(player.baseColl.IsTouching(stairsColl)){
            downStairs.enabled=true;
            LoadLivingRoom();
        }
        
    }
    public void LoadLivingRoom(){
        StartCoroutine(TransitionLivingRoom(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator TransitionLivingRoom(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

}   
