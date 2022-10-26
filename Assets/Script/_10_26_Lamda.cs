using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//반환형식이 int이고 매개변수가 int인 델리게이트 선언
public delegate int Do(int _a);
//반환형식이 int이고 매개변수가 없는 델리게이트 선언
public delegate int DoN();
//반환형식이 void이고 매개변수가 없는 델리게이트 선언
public delegate void DoV();

public class _10_26_Lamda : MonoBehaviour
{ 
    Do doSomething;
    DoN doSomethingN;
    DoV doSomethingV;
    void Start()
    {
        //람다식을 이용하여 함수를 정의하고 대입
        doSomething = (x) => x * x;
        //doSomething은 람다식으로 정의한 함수의 구문을 실행
        int result = doSomething(2);
        Debug.Log("결과 =" + result);
        //람다식을 이용하여 함수를 정의하고 대입
        for(int i = 1; i < 10; i++)
        {
            doSomethingN = () => 2 * i;
            int resultN = doSomethingN();
            Debug.Log("결과 =" + resultN);
        }
        //Debug.Log는 void타입의 반환이다.
        doSomethingV = () => Debug.Log("123");
        doSomethingV();

        //문람다의 끝에 ;세미콜론 붙여야함 유의
        doSomething = (x) =>
        {
            int result = x * x + 100;
            return result;
        };
        Debug.Log(doSomething(2));

        Test(doSomething = (x) =>
        {
            int result = x * x + 100;
            return result;
        });

        Test2(doSomething, 2);

        List<int> list = new List<int>();
        for (int i = 0; i < 10; i++)
            list.Add(i);
        //var tmp = list.Find(o => o == 99);
        int? tmp = list.Find(o => o == 99);
        if(tmp.HasValue)
        {
            Debug.Log(tmp);
        }
        else 
        {
            Debug.Log("없음");
        }

        Debug.Log(FindData(list, 99));
    }
    public void Test (Do _doSomething)
    {        
        Debug.Log("Test함수 = " + _doSomething(2));
    }
    public void Test2(Do _doSomething, int _arg)
    {
        Debug.Log("Test2함수 = " + _doSomething(_arg));
    }
    public int? FindData(List<int> _list, int _findData)
    {
        foreach(int one in _list)
        {
            if (one.Equals(_findData))
                return one;
        }
        return null;
    }
    void Update()
    {
        
    }
}
