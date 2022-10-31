using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _6_ResourceManager : MonoBehaviour
{
    public static _6_ResourceManager instance;
    List<GameObject> rcCharlist;
    public void Awake()
    {
        instance = this;
        rcCharlist = new List<GameObject>();
    }
   public GameObject GetCharRc(string _name)
   {
        return rcCharlist.Find(o => (o.Equals(_name)));
   }

    void Update()
    {
        
    }
}
