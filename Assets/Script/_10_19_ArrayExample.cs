using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_19_ArrayExample : MonoBehaviour
{
    int[] data = new int[20];
    void Start()
    {        
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = Random.Range(0, 100);            
        }
        DscendSort();
        DisplayData();
    }
    public void AscendSort()
    {
        int temp = 0;
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data.Length; j++)
            {
                if (data[i] < data[j])
                {                   
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                }
            }
        }
    }
    public void DscendSort()
    {
        int temp = 0;
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data.Length; j++)
            {
                if (data[i] > data[j])
                {                    
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                }
            }
        }
    } 
    public void DisplayData()
    {
        for(int i = 0; i < data.Length; i++)
        {
            Debug.Log(data[i]);
        }       
    }
    void Update()
    {
        
    }
}
