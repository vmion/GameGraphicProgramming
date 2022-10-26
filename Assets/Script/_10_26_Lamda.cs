using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ȯ������ int�̰� �Ű������� int�� ��������Ʈ ����
public delegate int Do(int _a);
//��ȯ������ int�̰� �Ű������� ���� ��������Ʈ ����
public delegate int DoN();
//��ȯ������ void�̰� �Ű������� ���� ��������Ʈ ����
public delegate void DoV();

public class _10_26_Lamda : MonoBehaviour
{ 
    Do doSomething;
    DoN doSomethingN;
    DoV doSomethingV;
    void Start()
    {
        //���ٽ��� �̿��Ͽ� �Լ��� �����ϰ� ����
        doSomething = (x) => x * x;
        //doSomething�� ���ٽ����� ������ �Լ��� ������ ����
        int result = doSomething(2);
        Debug.Log("��� =" + result);
        //���ٽ��� �̿��Ͽ� �Լ��� �����ϰ� ����
        for(int i = 1; i < 10; i++)
        {
            doSomethingN = () => 2 * i;
            int resultN = doSomethingN();
            Debug.Log("��� =" + resultN);
        }
        //Debug.Log�� voidŸ���� ��ȯ�̴�.
        doSomethingV = () => Debug.Log("123");
        doSomethingV();

        //�������� ���� ;�����ݷ� �ٿ����� ����
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
            Debug.Log("����");
        }

        Debug.Log(FindData(list, 99));
    }
    public void Test (Do _doSomething)
    {        
        Debug.Log("Test�Լ� = " + _doSomething(2));
    }
    public void Test2(Do _doSomething, int _arg)
    {
        Debug.Log("Test2�Լ� = " + _doSomething(_arg));
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
