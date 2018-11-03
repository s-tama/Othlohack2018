Shader "Unlit/Head"
{
    Properties
    {
        _Color("Body color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags 
        { 
            "RenderType"="Transparent"
            "Queue"="Transparent" 
        }
        LOD 100
        
        
        ZWrite On
        Blend SrcAlpha OneMinusSrcAlpha
        
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
            
            // 色
            float4 _Color;
            
            // ----------------------------------
            // 頂点シェーダー
            // ----------------------------------
            v2f vert (appdata v)
            {
                
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                
                return o;
            }
            
            // ---------------------------------
            // フラグメントシェーダー
            // ---------------------------------
            float4 frag (v2f i) : SV_Target
            {
                float4 albedo = _Color;
                return albedo;
            }
            ENDCG
        }
    }
}
