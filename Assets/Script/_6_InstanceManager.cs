using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _6_InstanceManager : MonoBehaviour
{
    public static _6_InstanceManager instance;
    List<_6_Monster> monsterList;
    private void Awake()
    {
        instance = this;
        monsterList = new List<_6_Monster>();
    }
    public _6_Monster CreateInstance(string _name)
    {
        GameObject tmp = _6_ResourceManager.instance.GetCharRc(_name);
        GameObject obj = GameObject.Instantiate<GameObject>(tmp);
        _6_Monster mob = obj.AddComponent<_6_Monster>();
        monsterList.Add(mob);
        return mob;
    }
    public _6_Monster FindInstance(string _name)
    {
        return monsterList.Find(o => (o.gameObject.Equals(_name)));
    }
    void Update()
    {
        
    }
}
