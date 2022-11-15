using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GoDownstairs downstairs;
   [SerializeField] private PlayerMovement player;

   public TMP_Text stairs;
    public Animator transition;
    void Start(){
        stairs.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.baseColl.IsTouching(downstairs.downstairsColl)){
            stairs.enabled=true;
            LoadLivingRoom();
        }
    }
    public void LoadLivingRoom(){
        TransitionLivingRoom(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator TransitionLivingRoom(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}   
