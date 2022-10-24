using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_21_LoadMonster : MonoBehaviour
{
    List<GameObject> mobList;
    public GameObject mob;
    void Start()
    {
        mobList = new List<GameObject>();
        for(int i = 0; i < 10; i++)
        {
            mobList.Add(Instantiate(mob));
            mobList[i].transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
            PhysicsHelper.GetHeightPosition(mobList[i].transform.position);
        }
    }

    void Update()
    {
        
    }
}
