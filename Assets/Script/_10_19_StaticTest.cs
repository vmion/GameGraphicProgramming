using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_19_StaticTest : MonoBehaviour
{
    public static int count;
    void Start()
    {
        count = 0;
    }
    private static void DisplayData()
    {
        Debug.Log(count);
    }    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            DisplayData();
        }
    }
}
