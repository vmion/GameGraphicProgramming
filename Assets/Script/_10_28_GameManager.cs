using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_28_GameManager : MonoBehaviour
{
    void Start()
    {
        //staticŬ������ ��ü�� �������� �ʴ´�.
        //�������(�Լ�)���ٽ� - Ŭ������.���
        GameObjectHelper.CreateObjectOnLoad("Terrain_1");
    }

    void Update()
    {
        
    }
}
