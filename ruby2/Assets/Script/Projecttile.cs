using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude>50.0f)
        {
            Destroy(gameObject);
        }
    }
    public void launch(Vector2 direction,float force)
    {
        rigidbody2D.AddForce(direction*force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController2 enemyController2=collision.collider.GetComponent<EnemyController2>();
        if (enemyController2 != null)
        {
            enemyController2.Fix();
            enemyController2.PlaySound(enemyController2.hitedEnemy, 1.0f);
        }

        Destroy(gameObject);
    }
}
