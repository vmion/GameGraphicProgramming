using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_03_MultiTouch : MonoBehaviour
{
    //멀티터치
    //마우스와는 다른 방법
    //마우스 입력 이벤트는 pc와 스마트디바이스에서 작동된다.

    //Input.Touch는 pc에서는 작동되지 않는다.
    void Start()
    {
        
    }

    void Update()
    {
        //현재 구동된고있는 플랫폼이 안드로이드라면 또는 아이폰이라면
        if(Application.platform == RuntimePlatform.Android || 
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            //GetTouch(0)은 첫번째 터치를 의미한다.
            Touch myTouch = Input.GetTouch(0);
            Debug.Log(myTouch.deltaPosition);

            Touch[] myTouches = Input.touches;
            for(int i = 0; i < Input.touchCount; i++)
            {
                Debug.Log("i = " + i.ToString() + myTouches[i].position);
                Debug.Log("i = " + i.ToString() + myTouches[i].fingerId);

                if(myTouches[i].phase == TouchPhase.Began)
                {

                }
                if (myTouches[i].phase == TouchPhase.Moved)
                {

                }
                if (myTouches[i].phase == TouchPhase.Ended)
                {

                }
            }
        }
    }
}
