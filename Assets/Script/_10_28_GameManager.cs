using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_28_GameManager : MonoBehaviour
{
    void Start()
    {
        //static클래스는 객체를 생성하지 않는다.
        //멤버변수(함수)접근시 - 클래스명.멤버
        GameObjectHelper.CreateObjectOnLoad("Terrain_1");
    }

    void Update()
    {
        
    }
}
