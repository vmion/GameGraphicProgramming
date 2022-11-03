Shader "Custom/_11_03_VertexLit"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _SpecColor("Spec Color", Color) = (1,1,1,0)
        _Emission("Emissiv Color", Color) = (0,0,0,0)
        _Shininess("Shininess", Range(0.1,1)) = 0.7
        _MainTex("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" "Opaque" = "Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite ON
        Lighting ON
        LOD 200
        Pass{
            Tags{"LightMode" = "Vertex"}
            Material
            {
                Diffuse[_Color]
                Ambient[_Color]
                Shininess[_Shininess]
                Specular[_SpecColor]
                Emission[_Emission]
            }            
            SeparateSpecular On
            SetTexture[_MainTex]{
                Combine texture * primary DOUBLE, texture * primary
            }
        }
    }
    FallBack "Diffuse"
}
