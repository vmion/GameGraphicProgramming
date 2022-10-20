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
        //어떤 수를 1부터 9까지 차례로 증가시키고 9까지 도달하면 1부터 다시 시작함
        //시간의 개념 적용
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
