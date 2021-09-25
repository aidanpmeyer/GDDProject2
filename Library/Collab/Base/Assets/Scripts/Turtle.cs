using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turtle : MonoBehaviour
{   
    public bool shrink;
    public bool Jellyfish;
    public bool Crab;
    public bool Plankton;
    public bool feetContact;
    public BoxCollider2D feet;
    private bool doubleJump;
    private Rigidbody2D RB;
    private SpriteRenderer SR;

    #region Health_variables
    public Slider HPSlider;
    public float maxHealth;
    float currHealth;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        currHealth = maxHealth;
        HPSlider.value = currHealth/maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.position = (Vector2)transform.position + new Vector2(-5, 0) * Time.deltaTime;
            SR.flipX = true;

        } else if (Input.GetKey(KeyCode.D)) {
            transform.position = (Vector2)transform.position + new Vector2(5, 0) * Time.deltaTime;
            SR.flipX = false;

        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump()) {
            RB.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.S) && Plankton){
            if (shrink){
                Unshrink();
            }else{
                Shrink();
            }

        }

    }

    bool canJump() {
        if (feetContact) {
            doubleJump = Jellyfish;
            return true;
        }
        if (doubleJump) {
            doubleJump = false;
            return true;
        }
        return false;
	}
    #region health_funcs


    //need to make spike script call this with a collider
    public void TakeDamage(float value)
    {
        // sound
       // FindObjectOfType<AudioManager>().Play("PlayerHurt");

       
       if(!Crab){
         currHealth -= value;  
       }
       HPSlider.value = currHealth/maxHealth;
 

        //Check if dead
        if(currHealth <= 0){
            //die
            Die();
        }
    }

     private void Die()
    {
        //sound
        //FindObjectOfType<AudioManager>().Play("PlayerDeath");
        //destroy object
        
        Destroy(this.gameObject);
        //find game manager and lose game (uncomment once gamemanager made)
        //GameObject gm = GameObject.FindWithTag("GameController");
        //Debug.Log("got to lose");
        //gm.GetComponent<GameManager>().LoseGame();
    }

    #endregion

    #region abilityfuncs
    public void StickyFeet(){
        feet.size = new Vector2(0.52f,feet.size.y);
    }

    public void Shrink(){
        this.transform.localScale = new Vector3(4.1548f/2f,4.2324f/2f,1);
        shrink = true;
    }
    public void Unshrink(){
        this.transform.localScale = new Vector3(4.1548f,4.2324f,1);
        shrink = false;
    }
    #endregion

}
