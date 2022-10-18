using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_18_UvAnimation : MonoBehaviour
{
    MeshRenderer renderer;
    Vector2 offset;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        Debug.Log(renderer.material.mainTexture.wrapMode);
        //텍스처 교체시 2D사용
        renderer.material.mainTexture = Resources.Load<Texture2D>("Test");
        //텍스처 스케일 변경
        renderer.material.SetTextureScale("_MainTex", new Vector2(0.8f, 0.8f));
    }
    void Update()
    {
        offset.x += Time.deltaTime;
        //_MainTex는 메인텍스처를 의미
        renderer.material.SetTextureOffset("_MainTex", offset);
    }
}
