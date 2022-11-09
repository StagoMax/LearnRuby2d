using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //声明一个公开的音频剪辑变量，用来挂接草莓音频
    public AudioClip collectedClip;
    public float soundVol=1.0f;
    int colliderCount;
    public int amount=1;//草莓加的血量

    public ParticleSystem addHealthEffect;
    // Start is called before the first frame update
    //添加触发器碰撞事件
    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliderCount = colliderCount + 1;
        Debug.Log($"碰撞对象为{collision},这是第{colliderCount}次碰撞");
        Rubycontroller rubycontroller = collision.GetComponent<Rubycontroller>();
        try
        {
            if(rubycontroller.Health<rubycontroller.MaxHealth)
            {
                rubycontroller.ChangeHealth(amount);
                Destroy(gameObject);
                Instantiate(addHealthEffect, transform.position, Quaternion.identity);
                rubycontroller.PlaySound(collectedClip, soundVol);
            }
            
        }
        catch
        {
            Debug.Log("获取rubycontroller组件失败");
        }
 
    }
}
