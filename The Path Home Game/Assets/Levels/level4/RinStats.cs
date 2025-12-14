using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 
using TMPro; 

public class RinStats : MonoBehaviour { 
    public int health=3; 
    public int lives=3; 
    

    private float flickerTime=0f; 
    public float flickerDuration=0.1f; 

    private SpriteRenderer sr; 

    public bool isImmune=false; 
    private float immunityTime=0f; 
    public float immunityDuration=1.5f; 
    public TextMeshProUGUI diamonds; 
    public TextMeshProUGUI livesUI;
    public PlayerHealthBarUI healthBar;


// Start is called before the first frame update 
void Start() { 
    sr=GetComponent<SpriteRenderer>(); 
} 
    // Update is called once per frame 
void Update() { 
    if (isImmune == true ){ 
        SpriteFlicker(); 
        immunityTime = immunityTime + Time.deltaTime; 
        if(immunityTime >= immunityDuration){ 
            isImmune = false; 
            sr.enabled = true; 
        }
    }   
    if (diamonds != null) 
        diamonds.text = Diamond.diamonds.ToString(); 

    livesUI.text =" "+ lives;
    } 
    void SpriteFlicker(){ 
    if(flickerTime < flickerDuration)
    { 
        flickerTime = flickerTime + Time.deltaTime; 
    } 
    else if(flickerTime >= flickerDuration)
    { 
        sr.enabled=!(sr.enabled); 
        flickerTime=0; 
    } 
    } 
    public void TakeDamage(int damage){ 
        if (isImmune == false )
        { 
            health = health - damage; 
            if (health < 0) 
               health = 0; 

            if (healthBar != null)
                healthBar.UpdateHealthBar(health, 3);   
            if (lives > 0 && health == 0)
            { 
                FindObjectOfType<LevelManager>().RespawnPlayer(); 
                health = 3; 
                lives--; 

                if (healthBar != null)
                    healthBar.UpdateHealthBar(health, 3);
            } 
            else if (lives == 0 && health == 0)
            { 
                Debug.Log("Gameover"); 
                Destroy(this.gameObject); 
            } 
            Debug.Log("Player Health:" + health.ToString()); 
            Debug.Log("Player Lives:" + lives.ToString()); 
        } 
        isImmune = true; 
        immunityTime = 0f; 
        } 
        /*void OnTriggerEnter2D(Collider2D other) { 
            if(other.CompareTag("Player")) { 
                RinStats stats = other.GetComponent<RinStats>(); 
                if (stats != null) { 
                    stats.TakeDamage(damage); 
                } 
                Destroy(gameObject); 
                } 
                else if (other.CompareTag("Wall")) { 
                    Destroy(gameObject); 
                } 
        } */
}