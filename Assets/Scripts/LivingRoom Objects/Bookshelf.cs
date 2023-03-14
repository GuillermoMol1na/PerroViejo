using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    public Collider2D BookShelfColl;
    public Collider2D playerCol;
    private GameMaster  gm;
    private LevelLoader2 thelevelLoader;
    [SerializeField] private RedArrowObj redArrow;

    void Start(){
       gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
       playerCol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
       thelevelLoader = LevelLoader2.FindObjectOfType<LevelLoader2>();
       if(gm.usedRedArrowBook){
            gm.usedRedArrowBook=true;
            redArrow.RedArrowVanish();
        }
    }
    void Update(){
        if(playerCol.IsTouching(BookShelfColl) && Input.GetKeyDown(KeyCode.F)){
            gm.usedRedArrowBook= true;
            gm.usedRedArrowPC=false;
            thelevelLoader.LoadBook();
        }
        /*if(!gm.usedRedArrowBook){
            redArrow.RedArrowAppear();
        }*/
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
