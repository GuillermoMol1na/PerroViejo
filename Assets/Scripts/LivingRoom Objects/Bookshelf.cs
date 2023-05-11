using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    public Collider2D BookShelfColl;
    public Collider2D playerCol;
    private GameMaster  gm;
    private Music_Manager mm;
    private LevelLoader2 thelevelLoader;
    [SerializeField] private RedArrowObj redArrow;

    void Start(){
       gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
       mm = GameObject.FindGameObjectWithTag("Audio_Manager").GetComponent<Music_Manager>();
       playerCol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
       thelevelLoader = LevelLoader2.FindObjectOfType<LevelLoader2>();
       if(gm.usedRedArrowBook){
            gm.usedRedArrowBook=true;
            redArrow.RedArrowVanish();
        }
    }
    void Update(){
        if(playerCol.IsTouching(BookShelfColl) && Input.GetKeyDown(KeyCode.F) && !gm.startMinigame2){
            gm.usedRedArrowBook= true;
            if(gm.det == 0){
                gm.usedRedArrowPC=false;
            }
            thelevelLoader.LoadBook();
        }
    }
    void OnEnable(){
        Minibar.activatebRedArr += ActivatetheArrow;
    }
    void OnDisable(){
        Minibar.activatebRedArr -= ActivatetheArrow;
    }
    void ActivatetheArrow(){
        redArrow.RedArrowAppear();
    }


    
}
