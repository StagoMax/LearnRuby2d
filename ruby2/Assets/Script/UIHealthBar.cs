using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }
    //创建ui图形对象mask
    public Image mask;
    //设置一个变量，记录遮罩层初始长度
    float originalSize;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //获取遮罩层图像的初始宽度
        originalSize = mask.rectTransform.rect.width;
    }

    //创建一个方法，用来蛇者（更改）现在mask遮罩层的宽度
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize*value);
        Debug.Log($"遮罩层长度：{originalSize} value值{value}");
    }
}
