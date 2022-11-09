using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    //��ʾ�Ի���ʱ��
    public float displayTime = 4.0f;
    //��ȡ�Ի������
    public GameObject dialogBox;
    //���ڼ�ʱ
    float timeDisplay;
    //����һ����Ϸ��������ȡtmp�ؼ�
    public GameObject dlgTxtproGameObject;
    //������Ϸ�������
    TextMeshProUGUI _tmTxtBox;

    int _currentPage = 1;
    int _totalPages;
    // Start is called before the first frame update
    void Start()
    {
        //��Ϸһ��ʼ����ʾ�Ի���
        dialogBox.SetActive(false);
        timeDisplay = -1.0f;

        //��ȡ�Ի���tmp
        _tmTxtBox = dlgTxtproGameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //��ȡ��ҳ��
        _totalPages = _tmTxtBox.textInfo.pageCount;
        if (timeDisplay >= 0)
        {
            //��ҳ����д�뵹��ʱ
            //����û����룬ÿ�οո��̸��ʱ����
            if(Input.GetKeyUp(KeyCode.Space))
            {
                if(_currentPage<_totalPages)
                {
                    _currentPage++;
                }
                else
                {
                    _currentPage = 1;
                }
                _tmTxtBox.pageToDisplay = _currentPage;
                timeDisplay = displayTime;
            }
            timeDisplay-=Time.deltaTime;
        }
        else
        {
            dialogBox.SetActive(false );
        }
    }
    public void DisplayDialog()
    {
        timeDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
