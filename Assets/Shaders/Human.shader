//
// Earth.shader
//

// ------------------------------------------------
// 地球のシェーダー
// ------------------------------------------------
Shader "Custom/Earth"
{
	Properties
	{
		_MainTex("Main texture", 2D) = "white"{}
		_AppearPos("AppearPos", Float) = 20
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Geometry"
			"RenderType" = "Transparent"
			"RenderType" = "Opaque"
			"Queue" = "Transparent"
		}
		LOD 200

			Cull Back
			ZWrite On
			Blend SrcAlpha OneMinusSrcAlpha

		//Pass
		//{
		//	Cull Front

		//	CGPROGRAM
		//	#pragma vertex vert
		//	#pragma fragment frag

		//	#include "UnityCG.cginc"


		//	// ----------------------------------------------
		//	// 入力
		//	// ----------------------------------------------
		//	struct appdata
		//	{
		//		float4 vertex : POSITION;
		//		float3 normal : NORMAL;
		//	};

		//	// ----------------------------------------------
		//	// フラグメントシェーダーに渡すデータ
		//	// ----------------------------------------------
		//	struct v2f
		//	{
		//		float4 vertex : SV_POSITION;
		//	};


		//	// ----------------------------------------------
		//	// 頂点シェーダ
		//	// ----------------------------------------------
		//	v2f vert(appdata v)
		//	{
		//		v2f o;
		//		//v.vertex += float4(v.normal * 0.001f, 0);
		//		o.vertex = UnityObjectToClipPos(v.vertex);
		//		return o;
		//	}

		//	// ----------------------------------------------
		//	// フラグメントシェーダ
		//	// ----------------------------------------------
		//	float4 frag(v2f i) : SV_Target
		//	{
		//		// 基本色
		//		float4 albedo = float4(0, 0, 0, 1);
		//		return albedo;
		//	}
		//	ENDCG
		//}

		Pass
		{
			Tags
			{
				"LightMode" = "ForwardBase"
			}

			

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"


			// テクスチャ
			sampler2D _MainTex;
			// 拡散範囲
			float _Displacement;
			// 出現座標
			float _AppearPos;


			// ----------------------------------------------
			// 入力
			// ----------------------------------------------
			struct appdata
			{
				float4 vertex	: POSITION;		// 頂点座標
				float3 normal	: NORMAL;		// 頂点の法線情報	
				float2 uv		: TEXCOORD0;	// テクスチャのuv情報
				float4 tangent	: TANGENT;		// 接線の情報
			};

			// ----------------------------------------------
			// フラグメントシェーダに渡す情報
			// ----------------------------------------------
			struct v2f
			{
				float4 vertex	: SV_POSITION;	// 頂点座標
				float3 normal	: NORMAL;		// 法線情報	
				float2 uv		: TEXCOORD0;	// テクスチャのuv情報
				float3 viewDir	: TEXCOORD1;	// カメラの方向ベクトル
				float3 lightDir : TEXCOORD2;	// ライトの方向ベクトル		
				float3 worldPos : TEXCOORD3;	// オブジェクトのワールド座標
				float4 color    : COLOR;		// 頂点色
			};


			// ----------------------------------------------
			// 頂点シェーダー
			// ----------------------------------------------
			v2f vert(appdata v)
			{
				// フラグメントシェーダーに渡すデータ
				v2f o;
				o.normal = UnityObjectToWorldNormal(v.normal);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.uv = v.uv;

				// 接空間におけるライト方向のベクトルと視点方向のベクトルを求める
				TANGENT_SPACE_ROTATION;
				o.lightDir = normalize(ObjSpaceLightDir(v.vertex));
				o.viewDir = normalize(ObjSpaceViewDir(v.vertex));

				// 頂点色を設定
				o.color = float4(1, 1, 1, 1);

				// 頂点のアルファ値を変更
				if (o.worldPos.y > _AppearPos)
				{
					o.color.a = 0;
				}

				// 結果を返す
				return o;
			}

			// ----------------------------------------------
			// フラグメントシェーダー
			// ----------------------------------------------
			float4 frag(v2f i) : COLOR
			{
				// 描画色
				float4 albedo = float4(1, 1, 1, 1);
				albedo = tex2D(_MainTex, i.uv);

				// 結果を返す
				return albedo * i.color;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
