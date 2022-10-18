using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_18_UvAnimation_2 : MonoBehaviour
{
    MeshRenderer renderer;
    Vector2 offset;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.material.SetTextureScale("_MainTex", new Vector2(0.33f, 0.33f));
        offset.Set(0.33f, 0.33f);
        renderer.material.SetTextureOffset("_MainTex", offset);
    }

    void Update()
    {
        
    }
}
