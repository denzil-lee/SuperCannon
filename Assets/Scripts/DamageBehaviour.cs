using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehaviour : MonoBehaviour, ITakeDamage
{
    Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void ApplyDamage(int hitpoints)
    {
        
        Enemy _enemy = GetComponent<Enemy>();
        _enemy.strength--;
        Debug.Log("Enemy strength: " + _enemy.strength.ToString());
        
        if (_enemy.strength <= 0 )
        {
            GameManager.Instance.OnEnemyDie(hitpoints);
            Destroy(this.gameObject);
        }
        StartCoroutine(ApplyDamageEffect());
    }

    IEnumerator ApplyDamageEffect()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color enemyColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        animator.SetBool("spin_trigger", true);
        Vector2 old_velocity= rb.velocity;
        rb.velocity = new Vector2(0f,0f);
        yield return new WaitForSeconds(0.4f);
        rb.velocity = old_velocity;
        spriteRenderer.color = enemyColor;
        animator.SetBool("spin_trigger", false);
    }

}

//if you don;t wish to use a coroutine to just drive animator transitions you can use

// animator.SetBool("spin_trigger", true);
// Invoke("StopRotation", 1f);#

// void StopRotation()
// {
// animator.SetBool("spin_trigger", false);
// }