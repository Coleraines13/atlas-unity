Shader "Custom/EdgeGlowShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _GlowColor ("Glow Color", Color) = (1,1,1,1)
        _GlowPower ("Glow Power", Range(0, 4)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 normal : TEXCOORD0;
                float3 viewDir : TEXCOORD1;
            };

            float4 _Color;
            float4 _GlowColor;
            float _GlowPower;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.normal = mul((float3x3)unity_ObjectToWorld, v.normal);
                o.viewDir = _WorldSpaceCameraPos - worldPos;

                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                // Normalize the normal and view direction
                float3 norm = normalize(i.normal);
                float3 viewDir = normalize(i.viewDir);

                // Compute the rim glow factor
                float rim = 1.0 - saturate(dot(norm, viewDir));
                rim = pow(rim, _GlowPower);

                // Mix the rim glow color with the base color
                float4 color = _Color;
                color.rgb += _GlowColor.rgb * rim * rim;  // Multiply rim by itself to intensify the effect

                return color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}