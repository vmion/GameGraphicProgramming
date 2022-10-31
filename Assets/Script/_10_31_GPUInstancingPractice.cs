using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_31_GPUInstancingPractice : MonoBehaviour
{
    public struct GPUInstancingObject
    {
        public Color originColor;
        public MeshRenderer meshRenderer;
    }
    public static _10_31_GPUInstancingPractice instance;
    private List<GPUInstancingObject> gpuInstancingList;
    private void Awake()
    {
        instance = this;
        gpuInstancingList = new List<GPUInstancingObject>();
    }
    void Start()
    {
        
    }    
    public void CreateObject(string _name)
    {
        GameObject tmp = Resources.Load<GameObject>(_name);
        GameObject obj = GameObject.Instantiate<GameObject>(tmp);
        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
        MaterialPropertyBlock props = new MaterialPropertyBlock();        

        GPUInstancingObject GPUInstancingObj;
        GPUInstancingObj.originColor = renderer.material.color;
        GPUInstancingObj.meshRenderer = renderer;
        renderer.SetPropertyBlock(props);
        gpuInstancingList.Add(GPUInstancingObj);               
    } 
    public void SetColor(string _name, Color _color)
    {
        //GPUInstancingObject findObj = gpuInstancingList.Find(o=>(o.meshRenderer.gameObject.name.Equals(_name)));
        foreach(GPUInstancingObject one in gpuInstancingList)
        {
            if(one.meshRenderer.gameObject.name.Equals(_name))
            {
                MaterialPropertyBlock props = new MaterialPropertyBlock();
                one.meshRenderer.GetPropertyBlock(props);
                props.SetColor("Color", _color);
                one.meshRenderer.SetPropertyBlock(props);
            }
        }
    }
    public void SetAlpha(string _name, float _alpaha)
    {
        foreach (GPUInstancingObject one in gpuInstancingList)
        {
            if (one.meshRenderer.gameObject.name.Equals(_name))
            {
                MaterialPropertyBlock props = new MaterialPropertyBlock();
                one.meshRenderer.GetPropertyBlock(props);
                Color tmp = one.originColor;
                tmp.a = _alpaha;                
                props.SetColor("Color", tmp);
                one.meshRenderer.SetPropertyBlock(props);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateObject("Cube");
            SetColor("Cube", Color.red);
            SetAlpha("Cube", 1);
        }        
    }
}
