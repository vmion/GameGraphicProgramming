Shader "Custom/6_MultiTextureBumpShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)

        _MainTex ("MainTex", 2D) = "white" {}        
        _MainTex2("MainTex2", 2D) = "white" {}
        _BumpTex("BumpTex", 2D) = "white" {}
        _BumpTex2("BumpTex2", 2D) = "white" {}
        //_Strength1("Strength1", Range(0,1)) = 0.5
        //_Strength2("Strength2", Range(0,1)) = 0.5

        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _InterpolationTex("InterpolationTex", Range(0,1)) = 0.0        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM       
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _MainTex2;
        sampler2D _BumpTex;
        sampler2D _BumpTex2;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpTex;            
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed _InterpolationTex;
        fixed _Strength1;
        fixed _Strength2;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 c2 = tex2D (_MainTex2, IN.uv_MainTex) * _Color;

            fixed3 b = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));
            fixed3 b2 = UnpackNormal(tex2D(_BumpTex2, IN.uv_BumpTex));
            b.z -= _Strength1;
            b2.z -= _Strength2;

            o.Albedo = lerp(c.rgb, c2.rgb, _InterpolationTex);
            o.Normal = lerp(b, b2, _InterpolationTex);

            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
