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
private GameMaster  gm;

   public TMP_Text downStairs;
   public TMP_Text upStairs;
   public Animator transition;
    void Start(){
        downStairs.enabled= false;
        upStairs.enabled= false;
       gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    /*void Update()
    {
        if(player.baseColl.IsTouching(bookshelf.BookShelfColl) && Input.GetKeyDown(KeyCode.F)){  
            
            LoadBook();
        }
        if(player.baseColl.IsTouching(stairs.stairsColl)){
            
            LoadBedRoom();
        }
    }*/
    public void LoadBedRoom(){
        upStairs.enabled=true;
        StartCoroutine(TransitionBedRoom(SceneManager.GetActiveScene().buildIndex -1));
    }
    
    public void LoadBook(){
        gm.usedRedArrowBook= true;
        gm.usedRedArrowPC=false;
        StartCoroutine(TransitionBookshelf(SceneManager.GetActiveScene().buildIndex +1));
    }
    public void LoadPC(){

        StartCoroutine(TransitionBookshelf(SceneManager.GetActiveScene().buildIndex +2));
    }
    IEnumerator TransitionBedRoom(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
    IEnumerator TransitionBookshelf(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}   

