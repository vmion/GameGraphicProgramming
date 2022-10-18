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
        //�ؽ�ó ��ü�� 2D���
        renderer.material.mainTexture = Resources.Load<Texture2D>("Test");
        //�ؽ�ó ������ ����
        renderer.material.SetTextureScale("_MainTex", new Vector2(0.8f, 0.8f));
    }
    void Update()
    {
        offset.x += Time.deltaTime;
        //_MainTex�� �����ؽ�ó�� �ǹ�
        renderer.material.SetTextureOffset("_MainTex", offset);
    }
}
