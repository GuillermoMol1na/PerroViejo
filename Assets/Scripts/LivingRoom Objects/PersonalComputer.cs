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
    private string[] readMssg = {"Debes leer acerca de los peligros del malware primero"};
    private string[] drinkMssg = {"Erwin no inicia el día sin un buen vaso de brandy"};
    
    private Messages readMsg = new Messages();
    private Messages drinkMsg = new Messages();
 
    void Start()
    {
        //This is new
        readMsg.Include(readMssg);
        drinkMsg.Include(drinkMssg);
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
            if(gm.glassfull){
                msgTrigg.UsetheMessages(drinkMsg);
                msgTrigg.TriggerMessage();
            }
            else if(gm.usedRedArrowPC){
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
