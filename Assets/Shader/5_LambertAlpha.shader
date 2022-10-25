Shader "Custom/5_LambertAlpha"
{
    Properties
    {
        _Red("Red", Range(0,1)) = 1.0
        _Green("Green", Range(0,1)) = 1.0
        _Blue("Blue", Range(0,1)) = 1.0
        _Alpha("Alpha", Range(0,1)) = 1.0
        _Color("EmissionColor", Color) = (1,1,1,1)
        _MainTex_1("Albedo (RGB)", 2D) = "white" {}
        _MainTex_2("Albedo (RGB)", 2D) = "white" {}
        _BumpTex("Normal", 2D) = "white" {}
        _Specular("Specular", Range(0,1)) = 1.0
        _Gloss ("Gloss", Range(0,1)) = 1.0  
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
        LOD 200        
        
        CGPROGRAM
        
        #pragma surface surf Lambert alpha:fade        
        #pragma target 3.0

        sampler2D _MainTex_1;
        sampler2D _MainTex_2;
        sampler2D _BumpTex;
        struct Input
        {
            float2 uv_MainTex_1;
            float2 uv_MainTex_2;
            float2 uv_BumpTex;
        };
        fixed _Red;
        fixed _Green;
        fixed _Blue;
        fixed _Alpha;
        fixed4 _Color;
        half _Specular;
        fixed _Gloss;                
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)
        void surf (Input IN, inout SurfaceOutput o)
        {            
            fixed4 c1 = tex2D(_MainTex_1, IN.uv_MainTex_1) * fixed4(_Red, _Green, _Blue, _Alpha);
            fixed4 c2 = tex2D(_MainTex_2, IN.uv_MainTex_2) * fixed4(_Red, _Green, _Blue, _Alpha);
            fixed3 n = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));
            o.Albedo = lerp(c1.rgb, c2.rgb, 0.5);
            o.Normal = n;
            o.Emission = _Color.rgb; //조명의 영향을 받지 않는 색상
            o.Specular = _Specular;
            o.Gloss = _Gloss;
            o.Alpha = lerp(c1.a, c2.a, 0.5);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
