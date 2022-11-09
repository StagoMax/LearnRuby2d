using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    //显示对话框时长
    public float displayTime = 4.0f;
    //获取对话框对象
    public GameObject dialogBox;
    //用于计时
    float timeDisplay;
    //创建一个游戏对象，来获取tmp控件
    public GameObject dlgTxtproGameObject;
    //创建游戏组件对象
    TextMeshProUGUI _tmTxtBox;

    int _currentPage = 1;
    int _totalPages;
    // Start is called before the first frame update
    void Start()
    {
        //游戏一开始不显示对话框
        dialogBox.SetActive(false);
        timeDisplay = -1.0f;

        //获取对话框tmp
        _tmTxtBox = dlgTxtproGameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取总页数
        _totalPages = _tmTxtBox.textInfo.pageCount;
        if (timeDisplay >= 0)
        {
            //翻页功能写入倒计时
            //检测用户输入，每次空格键谈起时几伙
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
