using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FlyText : MonoBehaviour {
    void Start()
    {
        transform.DOScale(0.03f, 1f);
        transform.DOMoveY(2,1f);
    }
}
