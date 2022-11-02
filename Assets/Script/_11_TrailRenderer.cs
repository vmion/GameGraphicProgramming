using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_TrailRenderer : MonoBehaviour
{
    public GameObject handEffect;
    private const string handEffectNode = "TrollGiant/Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/Bip001 R Finger1/Bip001 R Finger11/Bip001 R Finger12/HandEffect";
    string handEffectNode2;    
    void Start()
    {
        //handEffectNode2 = string.Format("{0}{1}", gameObject.name, "/Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/Bip001 R Finger1/Bip001 R Finger11/Bip001 R Finger12/HandEffect");
        //handEffect = GameObject.Find(handEffectNode2);
        Transform effectTr = FindEffectTr("HandEffect", transform);
        handEffect = effectTr.gameObject;
        handEffect.SetActive(false);

        FindEffectPath("HandEffect", "TrollGiant", transform);       
    }
    public Transform FindEffectTr(string _findTr, Transform _Tr)
    {
        /*
        Transform[] Child = _Tr.GetComponentsInChildren<Transform>();
        foreach (Transform tmp in _Tr)
        {
            if(tmp.name == _findTr)
            {
                return tmp;
            }
            else
            {
                FindEffectTr(tmp.name, tmp);
            }
        }
        return null;
        */
        if (_Tr.name.Equals(_findTr))
            return _Tr;
        for(int i = 0; i < _Tr.childCount; i++)
        {
            Transform findTr = FindEffectTr(_findTr, _Tr.GetChild(i));
            if (findTr != null)
                return findTr;
        }
        return null;
    }
    public Transform FindEffectPath(string _findname, string _path, Transform _Tr)
    {
        _path = _path + _Tr.name + "/";
        if (_Tr.name.Equals(_findname))
        {
            Debug.Log(_path);
            return _Tr;
        }            
        for (int i = 0; i < _Tr.childCount; i++)
        {
            FindEffectPath(_findname, _path, _Tr.GetChild(i));            
        }
        return null;
    }
    public void OnEffect()
    {
        handEffect.SetActive(true); 
    }
    public void OffEffect()
    {
        handEffect.SetActive(false);
    }
    void Update()
    {
        
    }
}
