using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
   public float maxSpeed=2;
    public int damage=1;
    public SpriteRenderer sr;
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Flip(){
        sr.flipX =!sr.flipX;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            FindObjectOfType<RinStats>().TakeDamage(damage);
            //Flip();
        }
        else if(other.tag == "Wall"){
            //Flip();
        }
    }

    public void EnemyTakeDamage(int damage){
        health -= damage;

        if(health <= 0){
            health = 0;
        }


        if(health == 0){
            Debug.Log("Enemy Finished");
            Destroy(gameObject);
        }
    }

}
