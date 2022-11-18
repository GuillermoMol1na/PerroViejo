using UnityEngine;

public class Bed : MonoBehaviour
{
    public Sprite bedMade;
    public Sprite bedUnmade;
    public Collider2D bedColl;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private RedArrowBed redArrow;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = bedUnmade;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.baseColl.IsTouching(bedColl) && Input.GetKeyDown(KeyCode.F)){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bedMade;
            redArrow.RedArrowVanish();
        }
    }
}
