using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_19_BuildingAlpha : MonoBehaviour
{
    //1. 카메라와 캐릭터 사이의 오브젝트를 찾아 리스트에 저장하시오
    //2. 카메라와 캐릭터 사이의 오브젝트의 컬러의 A를 0.3으로 하시오.
    //3. 이미 지나간 오브젝트의 A를 1로 돌려놓으시오
    public Transform trCharacter;
    List<MeshRenderer> hitList;    
    void Start()
    {
        hitList = new List<MeshRenderer>();
        Test();
    }
    public void Test()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Building");
        Dictionary<string, int> dic = new Dictionary<string, int>();
        for (int i = 0; i < objs.Length; i++)
        {
            dic.Add(objs[i].gameObject.name, i + 1);
        }
        if (dic.ContainsKey("Building_1"))
        //키가 존재하는지 알아보는 함수
        {
            Debug.Log(dic["Building_1"]);
        }        
    }
    void Update()
    {
        Vector3 dir = trCharacter.position - transform.position;
        float distance = Vector3.Distance(transform.position, trCharacter.position);
        RaycastHit[] hitInfos = Physics.RaycastAll(transform.position, dir.normalized, distance);
        for (int i = 0; i < hitInfos.Length; i++)
        {
            // 이미 리스트에 존재할 수가 있기 때문에 리스트에 존재하는지 검사후 존재하지 않는다면 Add
            MeshRenderer findRenderer = hitList.Find(o => o.gameObject.name.Equals(hitInfos[i].collider.gameObject.name));
            if (findRenderer == null)
            {
                MeshRenderer renderer = hitInfos[i].transform.GetComponent<MeshRenderer>();
                Color tmp = renderer.material.color;
                tmp.a = 0.3f;
                renderer.material.color = tmp;
                hitList.Add(renderer);
            }
        }
        //1.배열에만 존재하는 게임오브젝트 	
        //foreach(RaycastHit one in hitInfos)
        //{
        //    MeshRenderer findRenderer = hitList.Find(o => o.gameObject.name.Equals(one.collider.gameObject.name));
        //    if(findRenderer==null)
        //        hitList.Add(findRenderer);
        //}
        //2.리스트에만 존재하는 게임오브젝트
        List<MeshRenderer> removeList = null;
        foreach (MeshRenderer one in hitList)
        {
            MeshRenderer findRenderer = null;
            foreach (RaycastHit hitOne in hitInfos)
            {
                if (one.gameObject.name.Equals(hitOne.collider.gameObject.name))
                {
                    findRenderer = one;
                    break;
                }
            }
            if (removeList == null)
                removeList = new List<MeshRenderer>();
            if (findRenderer == null)
            {
                Color tmp = one.material.color;
                tmp.a = 1f;
                one.material.color = tmp;
                removeList.Add(one);
            }
        }
        if (removeList != null)
        {
            foreach (MeshRenderer one in removeList)
            {
                MeshRenderer removeRenderer = hitList.Find(o => o.gameObject.name.Equals(one.gameObject.name));
                hitList.Remove(removeRenderer);
            }
        }
    }
}
