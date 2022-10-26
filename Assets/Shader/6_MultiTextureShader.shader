Shader "Custom/6_MultiTextureShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex_1("MainTexture_1", 2D) = "white" {}
        _MainTex_2("MainTexture_2", 2D) = "white" {}
        _MainTex_3("MainTexture_3", 2D) = "white" {}
        //_MainTex_4("MainTexture_4", 2D) = "white" {}
        //_MainTex_5("MainTexture_5", 2D) = "white" {}
        //_MainTex_6("MainTexture_6", 2D) = "white" {}
        //_MainTex_7("MainTexture_7", 2D) = "white" {}
        //_MainTex_8("MainTexture_8", 2D) = "white" {}
        //_MainTex_9("MainTexture_9", 2D) = "white" {}
        //_MainTex_10("MainTexture_10", 2D) = "white" {}
        //_MainTex_11("MainTexture_11", 2D) = "white" {}
        //_MainTex_12("MainTexture_12", 2D) = "white" {}
        //_MainTex_13("MainTexture_13", 2D) = "white" {}
        //_MainTex_14("MainTexture_14", 2D) = "white" {}
        //_MainTex_15("MainTexture_15", 2D) = "white" {}
        //_MainTex_16("MainTexture_16", 2D) = "white" {}
        //_MainTex_17("MainTexture_17", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _Interpolation1("Interpolation1", Range(0,1)) = 0.0
        _Interpolation2("Interpolation2", Range(0,1)) = 0.0
        //_Interpolation3("Interpolation3", Range(0,1)) = 0.0        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        
        #pragma surface surf Standard fullforwardshadows        
        #pragma target 3.0

        sampler2D _MainTex_1;
        sampler2D _MainTex_2;
        sampler2D _MainTex_3;
        //sampler2D _MainTex_4;
        //sampler2D _MainTex_5;
        //sampler2D _MainTex_6;
        //sampler2D _MainTex_7;
        //sampler2D _MainTex_8;
        //sampler2D _MainTex_9;
        //sampler2D _MainTex_10;
        //sampler2D _MainTex_11;
        //sampler2D _MainTex_12;
        //sampler2D _MainTex_13;
        //sampler2D _MainTex_14;
        //sampler2D _MainTex_15;
        //sampler2D _MainTex_16;
        //sampler2D _MainTex_17;
        
        struct Input
        {
            float2 uv_MainTex_1;
            //float2 uv_MainTex_2;
            //float2 uv_MainTex_3;
            //float2 uv_MainTex_4;
            //float2 uv_MainTex_5;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        fixed _Interpolation1;
        fixed _Interpolation2;
        //fixed _Interpolation3;  
                
        UNITY_INSTANCING_BUFFER_START(Props)            
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {            
            fixed4 c1 = tex2D(_MainTex_1, IN.uv_MainTex_1) * _Color;
            fixed4 c2 = tex2D(_MainTex_2, IN.uv_MainTex_1) * _Color;
            fixed4 c3 = tex2D(_MainTex_3, IN.uv_MainTex_1) * _Color;
            //fixed4 c4 = tex2D(_MainTex_4, IN.uv_MainTex_1) * _Color;
            //fixed4 c5 = tex2D(_MainTex_5, IN.uv_MainTex_1) * _Color;
            //fixed4 c6 = tex2D(_MainTex_6, IN.uv_MainTex_1) * _Color;
            //fixed4 c7 = tex2D(_MainTex_7, IN.uv_MainTex_1) * _Color;
            //fixed4 c8 = tex2D(_MainTex_8, IN.uv_MainTex_1) * _Color;
            //fixed4 c9 = tex2D(_MainTex_9, IN.uv_MainTex_1) * _Color;
            //fixed4 c10 = tex2D(_MainTex_10, IN.uv_MainTex_1) * _Color;
            //fixed4 c11 = tex2D(_MainTex_11, IN.uv_MainTex_1) * _Color;
            //fixed4 c12 = tex2D(_MainTex_12, IN.uv_MainTex_1) * _Color;
            //fixed4 c13 = tex2D(_MainTex_13, IN.uv_MainTex_1) * _Color;
            //fixed4 c14 = tex2D(_MainTex_14, IN.uv_MainTex_1) * _Color;
            //fixed4 c15 = tex2D(_MainTex_15, IN.uv_MainTex_1) * _Color;
            //fixed4 c16 = tex2D(_MainTex_16, IN.uv_MainTex_1) * _Color;
            //fixed4 c17 = tex2D(_MainTex_17, IN.uv_MainTex_1) * _Color;
            
            fixed3 t1 = lerp(c1, c2, _Interpolation1);
            //fixed3 t2 = lerp(t1, c3, _Interpolation2);
            //fixed3 t3 = lerp(t2, c4, _Interpolation3);
            o.Albedo = lerp(t1, c3, _Interpolation2);
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c1.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
