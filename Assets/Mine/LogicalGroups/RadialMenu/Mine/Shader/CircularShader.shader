Shader "Custom/CircleShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Calculate the center (assuming pivot is at the center)
                float2 center = float2(0.5, 0.5);
                
                // Calculate the distance from the center
                float dist = distance(i.uv, center);
                
                // Define the radius
                float radius = 0.5;

                // If the distance is greater than the radius, discard the pixel
                if (dist > radius)
                {
                    discard;
                }
                
                // Otherwise, return the texture color
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}
