using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MonoBehaviour
{
    [SerializeField] float speed;
    protected Rigidbody2D rb;
    // Start is called before the first frame update

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    protected virtual void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

        
    }

    protected virtual void Start()
    { 
    }

    void OnBecameInvisible()
    {
     
        this.gameObject.SetActive(false);//Destroy(this.gameObject);
        rb.velocity = new Vector3(0, 0, 0);
        this.gameObject.transform.position = new Vector3(0,0,0);
        this.gameObject.transform.rotation = Quaternion.identity;

    }


}
