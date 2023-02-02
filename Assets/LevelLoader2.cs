using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader2 : MonoBehaviour
{
[SerializeField] private Stairs stairs;
[SerializeField] private PlayerMovement player;

[SerializeField] private Bookshelf bookshelf;

   public TMP_Text stairsMSG;
    public Animator transition;
    void Start(){
        stairsMSG.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.baseColl.IsTouching(bookshelf.BookShelfColl) && Input.GetKeyDown(KeyCode.F)){
            LoadBook();
        }
        if(player.baseColl.IsTouching(stairs.stairsColl)){
            stairsMSG.enabled=true;
            LoadBedRoom();
        }
        
    }
    public void LoadBedRoom(){
        StartCoroutine(TransitionBedRoom(0));
    }
    
    public void LoadBook(){
        StartCoroutine(TransitionBookshelf(2));
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

