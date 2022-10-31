using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_31_GPUInstancing : MonoBehaviour
{    
    void Start()
    {
        
    }
    public void CreateObject(string _name)
    {
        GameObject tmp = Resources.Load<GameObject>(_name);
        GameObject obj = GameObject.Instantiate<GameObject>(tmp);
        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        props.SetColor("_Color", new Color(r, g, b));
        renderer.SetPropertyBlock(props);       
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //CreateObject("Cube"); 
            _10_31_GPUInstancingPractice.instance.CreateObject("Cube");
        }
        //마우스로 선택한 게임오브젝트의 컬러를 선택
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                MeshRenderer renderer = hitInfo.collider.gameObject.GetComponent<MeshRenderer>();
                MaterialPropertyBlock props = new MaterialPropertyBlock();
                renderer.GetPropertyBlock(props);
                Color color = props.GetColor("_Color");
                //color.r = 0;
                //color.g = 0;
                //color.b = 0;
                color.a = 0.3f;
                props.SetColor("_Color", color);
                renderer.SetPropertyBlock(props);
            }
        }
    }
}
