using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectHelper
{
    //게임오브젝트의 인스턴스를 생성
    // -Mesh, Render를 로드
   public static GameObject CreateObjectOnLoad(string _name)
   {
        GameObject obj = new GameObject();
        obj.name = _name;
        obj.tag = "Terrain";
        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
        meshFilter.mesh = Resources.Load<Mesh>("Mesh/beach");
        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
        meshRenderer.material = Resources.Load<Material>("Materials/7_VertexColorMultiTexture");
        return obj;
   }
}
