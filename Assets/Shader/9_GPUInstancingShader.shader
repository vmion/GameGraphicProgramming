Shader "Custom/9_GPUInstancingShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Specular("Specular", Range(0,1)) = 1.0
        _Gloss("Gloss", Range(0,1)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
        LOD 200
        CGPROGRAM        
        #pragma surface surf Lambert alpha:fade
        #pragma target 3.0

        sampler2D _MainTex;
        struct Input
        {
            float2 uv_MainTex;
        };
        half _Specular;
        fixed _Gloss;
                
        UNITY_INSTANCING_BUFFER_START(Props)
            UNITY_DEFINE_INSTANCED_PROP(fixed4, _Color)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
            o.Albedo = c.rgb;            
            o.Specular = _Specular;
            o.Gloss = _Gloss;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
