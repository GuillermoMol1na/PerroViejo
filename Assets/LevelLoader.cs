using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
[SerializeField] private Stairs stairs;
   [SerializeField] private PlayerMovement player;



   public TMP_Text stairsMSG;
    public Animator transition;
    void Start(){
        stairsMSG.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.baseColl.IsTouching(stairs.stairsColl)){
            stairsMSG.enabled=true;
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
