using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        Rubycontroller rubycontroller = collision.GetComponent<Rubycontroller>();
        Debug.Log("������������û��Ѫ");
        if (rubycontroller != null)
        {
            rubycontroller.ChangeHealth(-1);
            Debug.Log("������������-1");
        }
    }
}
