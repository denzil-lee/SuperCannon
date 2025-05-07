using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITakeDamage
{
    public void ApplyDamage(int hitpoints);
}


public class Enemy : MonoBehaviour
{

    public int strength;
    public int hitpoints;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
       Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            GetComponent<ITakeDamage>().ApplyDamage(hitpoints);
        }

        if (other.gameObject.name.Contains("PlayerBase"))
        {
            EnemyWins();
        }
    }



    private void EnemyWins()
    {
        GameData.PlayerHealth -= 1;
        GameManager.Instance.OnEnemyWins();
        //Debug.Log("Player health: " + GameData.PlayerHealth.ToString());
        Destroy(this.gameObject);
        
    }

}
