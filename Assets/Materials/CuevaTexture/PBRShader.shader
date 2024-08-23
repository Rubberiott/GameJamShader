Shader "Unlit/PBRShader"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1,1,1,1)
        _BaseMap ("Base Map (Albedo)", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _HeightMap ("Height Map", 2D) = "gray" {}
        _Metallic ("Metallic", Range(0, 1)) = 0.0
        _MetallicMap ("Metallic Map", 2D) = "white" {}
        _Smoothness ("Smoothness", Range(0, 1)) = 0.5
        _RoughnessMap ("Roughness Map", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float3 worldNormal : NORMAL;
            };

            sampler2D _BaseMap;
            sampler2D _NormalMap;
            sampler2D _HeightMap;
            sampler2D _MetallicMap;
            sampler2D _RoughnessMap;

            float4 _BaseColor;
            float _Metallic;
            float _Smoothness;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldNormal = normalize(mul(v.normal, (float3x3)unity_WorldToObject));
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Base color
                fixed4 albedo = tex2D(_BaseMap, i.uv) * _BaseColor;

                // Normal mapping
                fixed3 normal = UnpackNormal(tex2D(_NormalMap, i.uv));

                // Height mapping (basic parallax)
                float height = tex2D(_HeightMap, i.uv).r;
                i.uv += height * normal.xy * 0.05;

                // Metallic and Roughness
                float metallic = tex2D(_MetallicMap, i.uv).r * _Metallic;
                float roughness = tex2D(_RoughnessMap, i.uv).r;

                // Roughness needs to be inverted to match Smoothness
                float smoothness = 1.0 - roughness;

                // Lighting (simplified PBR)
                fixed3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                fixed3 viewDir = normalize(_WorldSpaceCameraPos - i.pos.xyz);

                // Lambertian diffuse
                fixed3 diffuse = albedo.rgb * saturate(dot(normal, lightDir));

                // Specular (using the smoothness for reflection control)
                fixed3 reflectDir = reflect(-lightDir, normal);
                float spec = pow(saturate(dot(viewDir, reflectDir)), 1.0 / smoothness);

                // Final color with metallic and specular properties
                fixed4 color = fixed4(diffuse + spec * metallic, albedo.a);

                return color;
            }
            ENDHLSL
        }
    }
}