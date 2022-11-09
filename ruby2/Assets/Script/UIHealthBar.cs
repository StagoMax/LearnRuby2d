using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }
    //����uiͼ�ζ���mask
    public Image mask;
    //����һ����������¼���ֲ��ʼ����
    float originalSize;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //��ȡ���ֲ�ͼ��ĳ�ʼ���
        originalSize = mask.rectTransform.rect.width;
    }

    //����һ���������������ߣ����ģ�����mask���ֲ�Ŀ��
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize*value);
        Debug.Log($"���ֲ㳤�ȣ�{originalSize} valueֵ{value}");
    }
}
