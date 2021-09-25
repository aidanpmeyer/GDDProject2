using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Turtle : MonoBehaviour
{   
    #region Animal_variables
    private bool Jellyfish;
    private bool Crab;
    private bool Plankton;
    #endregion

    #region Ability_variables
    private bool doubleJump;
    private bool shrink;
    #endregion
    
    #region Text_variables
    public Canvas textCanvas;
    public TMP_Text textBox;
    private float textTime;
    private string textStr;
    #endregion

    #region Unity_variables
    public BoxCollider2D feet;
    private Rigidbody2D RB;
    private SpriteRenderer SR;
    #endregion
    
    #region Health_variables
    public Slider HPSlider;
    public float maxHealth;
    float currHealth;
    #endregion

    public bool feetContact;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        currHealth = maxHealth;
        HPSlider.value = currHealth/maxHealth;
        textStr = "";
        textTime = 0;
        textCanvas.enabled = false;
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
            RB.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.S) && Plankton){
            if (shrink){
                Unshrink();
            }else{
                Shrink();
            }

        }

        if (!textStr.Equals("")) {
            if (textTime <= 0) {
                textStr = "";
                textCanvas.enabled = false;
            } else {
                textTime -= Time.deltaTime;
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
        GameObject gm = GameObject.FindWithTag("GameController");
        //Debug.Log("got to lose");
        gm.GetComponent<GameManager>().Lose();
    }

    #endregion

    #region abilityfuncs

    public void GetStarfish(){
        feet.size = new Vector2(0.52f,feet.size.y);
        textStr = "With the power of the starfish, I can jump off walls!";
        textBox.text = textStr;
        textTime = 10f;
        textCanvas.enabled = true;
    }


    public void GetCrab() {
        Crab = true;
        textStr = "Thanks to the crab, spikes can't hurt me!";
        textBox.text = textStr;
        textTime = 10f;
        textCanvas.enabled = true;
    }

    public void GetPlankton() {
        Plankton = true;
        textStr = "Press 'S' to shrink to plankton's size and unshrink!";
        textBox.text = textStr;
        textTime = 10f;
        textCanvas.enabled = true;
    }

    public void GetJellyfish() {
        Jellyfish = true;
        textStr = "Woah! Thanks Jellyfish! Now I can double jump.";
        textBox.text = textStr;
        textTime = 10f;
        textCanvas.enabled = true;
    }

    private void Shrink(){
        this.transform.localScale = new Vector3(4.1548f/2f,4.2324f/2f,1);
        shrink = true;
    }
    private void Unshrink(){
        this.transform.localScale = new Vector3(4.1548f,4.2324f,1);
        shrink = false;
    }
    #endregion

}
