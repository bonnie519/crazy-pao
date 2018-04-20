using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCountDown : MonoBehaviour {
    public bool isCanTrigger;       //心判断是否进入区域用

    public Text TimeText;           //倒计时
    public bool isCountDown;        //开始倒计时
    public float LiveTime;          //计时时间
    //public bool isRotate;           
    void Update()
    {
        //if (isRotate)
        //{
        //    transform.Rotate(Vector3.up * Time.deltaTime * 30);
        //}
        if (isCountDown)
        {
            LiveTime -= Time.deltaTime;
            TimeText.text = ((int)LiveTime).ToString();
            if (LiveTime < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isCountDown = true;
        }
    }
}
