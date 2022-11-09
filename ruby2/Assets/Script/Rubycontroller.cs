using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubycontroller : MonoBehaviour
{
    //声明音频源对象
    AudioSource AudioSource;
    //脚步声
    public AudioClip stepClip;
    //飞镖声
    public AudioClip cogClip;
    //伤血声音
    public AudioClip playerHited;
    public GameObject ProjecttilePrefeb;
    // Start is called before the first frame update
    public float speed = 0.1f;

    Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;
    public int MaxHealth = 5;

    public float timeInvincible = 2.0f;
    bool isInvincible=false;
    float inInvincibleTimer;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    Vector2 move;
    public int Health { get { return CurrentHealth; } }
    private int CurrentHealth;

    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        CurrentHealth = 5;
        animator = GetComponent<Animator>();

        AudioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if(isInvincible)
        {
            inInvincibleTimer -= Time.deltaTime;
            if(inInvincibleTimer<0)
            {
                isInvincible = false;
            }
        }
        move = new Vector2(horizontal, vertical);
        if(!Mathf.Approximately(move.x,0.0f)||!Mathf.Approximately(move.y,0.0f))
        {
            lookDirection.Set(move.x,move.y);
            lookDirection.Normalize();
            if(!AudioSource.isPlaying)
            {
                AudioSource.Play(); 
            }
        }
        else
        {
            AudioSource.Stop();
        }
        animator.SetFloat("Lock x", lookDirection.x);
        animator.SetFloat("Look y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        if (Input.GetKeyDown(KeyCode.C) || Input.GetAxis("Fire1") != 0.0f)
        {
            Launch();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("我按了xxxxx");
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
               NonPlayerCharacter character=hit.collider.GetComponent<NonPlayerCharacter>();
                if(character != null)
                {
                    character.DisplayDialog();
                }
                Debug.Log("击中的目标为："+hit.collider.gameObject);
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position = position + speed * move * Time.deltaTime;
        rigidbody2D.MovePosition(position);
    }
    public void ChangeHealth(int amount)
    {
        if(amount<0)
        {
            if (isInvincible)
            {
                Debug.Log("无敌时间");
                return; }               
            animator.SetTrigger("Hit");
            isInvincible = true;
            inInvincibleTimer = timeInvincible;
            PlaySound(playerHited, 1.0f);
        }
 
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
        Debug.Log($"当前生命值：{CurrentHealth}/{MaxHealth}");

        UIHealthBar.instance.SetValue(CurrentHealth / (float)MaxHealth);
        Debug.Log($"value为 {CurrentHealth / (float)MaxHealth}");
    }
    void Launch()
    {
        GameObject ProjecttileObject = Instantiate(ProjecttilePrefeb, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);
        Projecttile projecttile = ProjecttileObject.GetComponent<Projecttile>();
        projecttile.launch(lookDirection, 300);
        animator.SetTrigger("Launch");
        PlaySound(cogClip, 1.0f);
    }
    //音频调用
    public void PlaySound(AudioClip audioclip,float soundvol)
    {
        AudioSource.PlayOneShot(audioclip,soundvol);
    }
}
