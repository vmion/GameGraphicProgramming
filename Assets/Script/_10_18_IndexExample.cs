using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_18_IndexExample : MonoBehaviour
{
    int frame;
    float elapsed;
    public int column;
    public int row;
    private int totalFrame;
    void Start()
    {
        totalFrame = row * column;
        //� ���� 1���� 9���� ���ʷ� ������Ű�� 9���� �����ϸ� 1���� �ٽ� ������
        //�ð��� ���� ����
        frame = 1;
        elapsed = 0f;

    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed >= 0.2f)
        {
            frame++;
            if(frame > 9)
            {
                frame = 1;
            }
        }
        
    }
}
