using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_03_MultiTouch : MonoBehaviour
{
    //��Ƽ��ġ
    //���콺�ʹ� �ٸ� ���
    //���콺 �Է� �̺�Ʈ�� pc�� ����Ʈ����̽����� �۵��ȴ�.

    //Input.Touch�� pc������ �۵����� �ʴ´�.
    void Start()
    {
        
    }

    void Update()
    {
        //���� �����Ȱ��ִ� �÷����� �ȵ���̵��� �Ǵ� �������̶��
        if(Application.platform == RuntimePlatform.Android || 
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            //GetTouch(0)�� ù��° ��ġ�� �ǹ��Ѵ�.
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
