using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_20_AnimationEffect : MonoBehaviour
{
    public Animator ani;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AnimatorClipInfo[] clipInfo = ani.GetCurrentAnimatorClipInfo(0);
            for(int i = 0; i < clipInfo.Length; i++)
            {
                Debug.Log(clipInfo[i].clip.name);
            }
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);            
            if(stateInfo.IsName("Idle"))
            {
                float startTime = stateInfo.normalizedTime - 0.08f;
                ani.Play("Idle", 0, startTime);
            }            
        }
    }
}
