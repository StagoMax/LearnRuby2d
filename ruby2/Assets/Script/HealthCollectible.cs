using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //����һ����������Ƶ���������������ҽӲ�ݮ��Ƶ
    public AudioClip collectedClip;
    public float soundVol=1.0f;
    int colliderCount;
    public int amount=1;//��ݮ�ӵ�Ѫ��

    public ParticleSystem addHealthEffect;
    // Start is called before the first frame update
    //��Ӵ�������ײ�¼�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliderCount = colliderCount + 1;
        Debug.Log($"��ײ����Ϊ{collision},���ǵ�{colliderCount}����ײ");
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
            Debug.Log("��ȡrubycontroller���ʧ��");
        }
 
    }
}
