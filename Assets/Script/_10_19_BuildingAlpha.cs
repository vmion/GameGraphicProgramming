using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_19_BuildingAlpha : MonoBehaviour
{
    //1. ī�޶�� ĳ���� ������ ������Ʈ�� ã�� ����Ʈ�� �����Ͻÿ�
    //2. ī�޶�� ĳ���� ������ ������Ʈ�� �÷��� A�� 0.3���� �Ͻÿ�.
    //3. �̹� ������ ������Ʈ�� A�� 1�� ���������ÿ�
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
        //Ű�� �����ϴ��� �˾ƺ��� �Լ�
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
            // �̹� ����Ʈ�� ������ ���� �ֱ� ������ ����Ʈ�� �����ϴ��� �˻��� �������� �ʴ´ٸ� Add
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
        //1.�迭���� �����ϴ� ���ӿ�����Ʈ 	
        //foreach(RaycastHit one in hitInfos)
        //{
        //    MeshRenderer findRenderer = hitList.Find(o => o.gameObject.name.Equals(one.collider.gameObject.name));
        //    if(findRenderer==null)
        //        hitList.Add(findRenderer);
        //}
        //2.����Ʈ���� �����ϴ� ���ӿ�����Ʈ
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
