using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 2.0f;

    AudioSource AudioSource;
    public AudioClip hitedEnemy;
    public AudioClip fixedRobot;
    public ParticleSystem smokeEffect;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    bool broken;
    Animator animator;

    // 在第一次帧更新之前调用 Start
    void Start()
    {
        speed = 0.3f;
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        if (!broken)
        {
            return;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;
            animator.SetFloat("Move x", 0);
            animator.SetFloat("Move y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; ;
            animator.SetFloat("Move x", direction);
            animator.SetFloat("Move y", 0);
        }

        rigidbody2D.MovePosition(position);
        if (!broken)
        {
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rubycontroller rubycontroller = collision.gameObject.GetComponent<Rubycontroller>();
        if(rubycontroller!=null)
        {
            rubycontroller.PlaySound(rubycontroller.playerHited, 1.0f);
            rubycontroller.ChangeHealth(-1);
            Debug.Log("触碰敌人-1");
        }
    }
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("fix");
        smokeEffect.Stop();
        AudioSource.Stop();
        PlaySound(fixedRobot, 1.0f);
    }
    public void PlaySound(AudioClip audioClip,float soundvol)
    {
        AudioSource.PlayOneShot(audioClip, soundvol);
    }
}
