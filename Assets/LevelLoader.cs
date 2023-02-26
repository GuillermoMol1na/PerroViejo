using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
[SerializeField] private Stairs stairs;
   [SerializeField] private PlayerMovement player;

    private Vector2 targetPosition = new Vector2(5.08f,3.84f);

   public TMP_Text downStairs;
   public TMP_Text upStairs;
    public Animator transition;
    void Start(){
        downStairs.enabled= false;
        upStairs.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.baseColl.IsTouching(stairs.stairsColl)){
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
