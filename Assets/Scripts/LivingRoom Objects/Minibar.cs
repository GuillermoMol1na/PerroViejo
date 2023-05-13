using UnityEngine;

public class Minibar : MonoBehaviour
{
    public Sprite GlassFull;
    public Sprite GlassEmpty;
    public Collider2D minibarColl;
    private GameMaster  gm;
    private PlayerMovement player;
    [SerializeField] private RedArrowObj redArrow;
    public delegate void ActivateBookshelfArrow();
    public static event ActivateBookshelfArrow activatebRedArr;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player= PlayerMovement.FindObjectOfType<PlayerMovement>();
        if(gm.glassfull)
        this.gameObject.GetComponent<SpriteRenderer>().sprite = GlassFull;
        else{
            this.gameObject.GetComponent<SpriteRenderer>().sprite = GlassEmpty;
            redArrow.RedArrowVanish();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.baseColl.IsTouching(minibarColl) && Input.GetKeyDown(KeyCode.F) && gm.glassfull){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = GlassEmpty;
            FindObjectOfType<Music_Manager>().Play("Track8-TomarTrago",false);
            redArrow.RedArrowVanish();
            if(activatebRedArr!= null){
                activatebRedArr();
            }
            gm.glassfull = !gm.glassfull;
        }
    }
}
