Shader "Custom/RotatingGradientWithSpread"
{
    Properties
    {
        _MainColor1 ("Color 1", Color) = (1, 0, 0, 1)
        _MainColor2 ("Color 2", Color) = (0, 0, 1, 1)
        _Rotation ("Rotation (Degrees)", Range(0, 360)) = 0
        _Spread ("Gradient Spread", Range(0.1, 5.0)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // Shader properties
            fixed4 _MainColor1;
            fixed4 _MainColor2;
            float _Rotation;
            float _Spread;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Convert rotation to radians
                float rad = radians(_Rotation);

                // 2D rotation matrix
                float2x2 rotationMatrix = float2x2(
                    cos(rad), -sin(rad),
                    sin(rad),  cos(rad)
                );

                // Rotate UV coordinates
                float2 rotatedUV = mul(rotationMatrix, i.uv - 0.5) + 0.5;

                // Adjust gradient with spread
                float gradient = saturate((rotatedUV.x - 0.5) * _Spread + 0.5);

                // Interpolate between colors
                fixed4 color = lerp(_MainColor1, _MainColor2, gradient);
                return color;
            }
            ENDCG
        }
    }
}
