using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_20_CustomCamera : MonoBehaviour
{
    public float duration;
    float tmpDuration;
    Vector3 originPos;
    delegate void Do();
    Do doSomething;
    public float rangeConstant;
    void Start()
    {
        tmpDuration = duration;
        doSomething = null;
    }
    public void EffectOn()
    {
        tmpDuration -= Time.deltaTime;
        //Vector3 delta = Random.insideUnitCircle * rangeConstant;
        Vector3 delta = new Vector3(Random.Range(-1f, 1f) * rangeConstant, Random.Range(-0.25f, 0.25f), 0f);
        transform.position = originPos + delta;
        if(tmpDuration <= 0f)
        {
            doSomething -= EffectOn;
            tmpDuration = duration;
            transform.position = originPos;
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(doSomething == null)
            {
                doSomething += EffectOn;
                originPos = transform.position;
            }                     
        }
        if(doSomething != null)
        {
            doSomething();
        }
    }
}
