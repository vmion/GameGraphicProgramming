using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _7_EffectManager : MonoBehaviour
{
    //ResourceManager�� �����ؾ���
    List<GameObject> rceffectList;
    //���� �÷��� ���ӿ�����Ʈ
    List<ParticleSystem> effectList;
    private void Awake()
    {
        rceffectList = new List<GameObject>();
        effectList = new List<ParticleSystem>();
        GameObject [] tmp = Resources.LoadAll<GameObject>("Effect/");
        for(int i = 0; i < tmp.Length; i++)
        {            
            rceffectList.Add(tmp[i]);
        }        
    }
    //���ӿ�����Ʈ�� �����ϱ����� ������ ���ӿ�����Ʈ�� �˻�
    public GameObject EnableObject(string _name)
    {
        //ParticleSystem particle = effectList.Find(o => o.gameObject.activeSelf == false && o.gameObject.name.Equals(_name));        
        for(int i = 0; i < effectList.Count; i++)
        {
            if(effectList[i].gameObject.activeSelf == false && effectList[i].gameObject.name.Equals(_name))
            {
                return effectList[i].gameObject;
            }
        }
        return null;
    }
    public GameObject CreateInstance(string _name)
    {
        GameObject enableObj = EnableObject(_name);
        if (enableObj != null)
            return enableObj;        
        GameObject particle = rceffectList.Find(o => o.name.Equals(_name));            
        return GameObject.Instantiate<GameObject>(particle);                     
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = CreateInstance("ShockWave");
            obj.name = "ShockWave";
            obj.SetActive(true);
            effectList.Add(obj.GetComponent<ParticleSystem>());
        }
    }
}
