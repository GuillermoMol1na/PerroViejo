using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader2 : MonoBehaviour
{
[SerializeField] private Stairs stairs;
[SerializeField] private PlayerMovement player;
[SerializeField] private Bookshelf bookshelf;
[SerializeField] private PersonalComputer computer;
   private Music_Manager mm;
   public TMP_Text downStairs;
   public TMP_Text upStairs;
   public Animator transition;
    void Start(){
        downStairs.enabled= false;
        upStairs.enabled= false;
        mm = GameObject.FindGameObjectWithTag("Audio_Manager").GetComponent<Music_Manager>();
    }
    public void LoadBedRoom(){
        upStairs.enabled=true;
        StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex -1));
    }
    
    public void LoadBook(){
        StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex +1));
        mm.StopMain();
    }
    public void LoadPC(){
        StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex +2));
        mm.StopMain();
        mm.Play("Track10-PcEncendida",false);
    }
    public void LoadGameOver(){
        StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex +3));
        mm.Stop("Track12-Minigame2");
    }
    IEnumerator Transition(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
    void OnEnable(){
        Minigame2_Options.goToGameOver += LoadGameOver;
        Timer_2.goToGameOver += LoadGameOver;
    }
    void OnDisable(){
        Minigame2_Options.goToGameOver -= LoadGameOver;
        Timer_2.goToGameOver -= LoadGameOver;
    }
}   

