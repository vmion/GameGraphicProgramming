using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_02_ReculsivePractice : MonoBehaviour
{
    public enum eDATA { NONE = -1, One = 1, Two }
    void Start()
    {
        Debug.Log(Plus(10));
        Sum(0);
        Debug.Log(Multiply(10));
        //열거체 데이터 문자열로 출력
        foreach(var one in System.Enum.GetValues(typeof(eDATA)))
        {
            Debug.Log(one.ToString());
        }
    }
    
    public int Plus(int end)
    {        
        if (end == 1)
            return 1;
        else
            return end += Plus(end - 1);         
    }
    public void Sum(int count, int result = 0)
    {
        if(count > 10)
        {
            Debug.Log(result);
            return;
        }        
        result += 1;
        Sum(++count, result);
    }
    public int Multiply(int sum)
    {
        if (sum == 1)
            return 1;
        else
            return sum *= Plus(sum - 1);
    }    
    void Update()
    {
        
    }
}
