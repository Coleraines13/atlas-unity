Shader "Custom/DissolveShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _DissolveTex ("Dissolve Texture", 2D) = "white" {}
        _DissolveThreshold ("Dissolve Threshold", Range(0, 1)) = 0.5
        _DissolveColor ("Dissolve Color", Color) = (1, 0, 0, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        sampler2D _DissolveTex;
        float _DissolveThreshold;
        fixed4 _DissolveColor;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_DissolveTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            float dissolve = tex2D(_DissolveTex, IN.uv_DissolveTex).r;

            if (dissolve < _DissolveThreshold)
            {
                o.Albedo = _DissolveColor.rgb;
                o.Alpha = _DissolveColor.a;
            }
            else
            {
                o.Albedo = c.rgb;
                o.Alpha = c.a;
            }
        }
        ENDCG
    }
    FallBack "Diffuse"
}