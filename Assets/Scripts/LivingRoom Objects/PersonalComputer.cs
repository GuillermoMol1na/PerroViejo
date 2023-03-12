using UnityEngine;


public class PersonalComputer : MonoBehaviour
{

    public Collider2D PcColl;
    [SerializeField] private CircleCollider2D playerCol;
    private GameMaster  gm;
    private LevelLoader2 thelevelLoader;
    [SerializeField] private RedArrowObj redArrow;
    [SerializeField] private MessageTrigger msgTrigg;
    //This is new
    private string[] elarreglo = {"Debes leer primero"};
    
    private Messages readMsg = new Messages();
 
    void Start()
    {
        //This is new
        readMsg.Include(elarreglo);
        //
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        thelevelLoader = LevelLoader2.FindObjectOfType<LevelLoader2>();
        //playerCol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
       if(gm.usedRedArrowPC){
            gm.usedRedArrowPC=true;
            redArrow.RedArrowVanish();
        }
        else{
            redArrow.RedArrowAppear();
        }
    }
    void Update(){
        if(playerCol.IsTouching(PcColl) && Input.GetKeyDown(KeyCode.F)){
            if(gm.usedRedArrowPC){
                //This is new
                msgTrigg.UsetheMessages(readMsg);
                //
                msgTrigg.TriggerMessage();
            }else
             thelevelLoader.LoadPC();
        }
    }
    /*void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag=="Player" && Input.GetKeyDown(KeyCode.F)){
           if(gm.usedRedArrowPC){
                msgTrigg.TriggerMessage();
            }else
             thelevelLoader.LoadPC();
        }
    }*/

}
