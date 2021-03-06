﻿Shader "Hidden/RedDotShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Radius("Radius",Int) = 4
		_Color("Color",Color)=(1.0,1.0,1.0,1.0)
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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
				float2 screenPos:TEXCOORD2;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.screenPos = ComputeScreenPos(o.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			int _Resolution_x;
			int _Resolution_y;
			float _Radius;
			float4 _Color;

			
			fixed4 frag (v2f i) : SV_Target
			{
				/*fixed4 colRed = (1.0,0.0,0.0,0.0);*/
				half2 center;
				half2 currentVert;
				center = i.screenPos*_ScreenParams.xy;
				center.x /= 2;
				currentVert = (i.vertex.x,i.vertex.y);
				float4 col= tex2D(_MainTex, i.uv);
				col = lerp(col,_Color, step(0.0,_Radius-distance(currentVert,center)));				
				return col;
			}
			ENDCG
		}
	}
}
