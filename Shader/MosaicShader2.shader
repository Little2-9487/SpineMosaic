// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/MosaicShader2" {
	Properties {
		_BlockSize ("Block Size", Float) = 15.0
	}


	Subshader {
		Tags { "Queue"="Transparent" "RenderType"="Opaque" }
		ZTest Less Cull Back ZWrite Off
		Fog { Mode off }

		GrabPass {
			//"_FrameBuffer1"
		}
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _GrabTexture;
			float _BlockSize;

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f {
				float4 vertex : POSITION;
				float4 screen_pos : TEXCOORD0;
			};  

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.screen_pos = ComputeGrabScreenPos(o.vertex);
				return o;
			}
				
			half4 frag (v2f i) : SV_Target
			{
				float2 t = i.screen_pos.xy/ i.screen_pos.w;
				float2 b = (_ScreenParams.zw-1.0) * _BlockSize;
				t = t - fmod(t, b) + b*0.5;

				return tex2D(_GrabTexture, t);
			}
			ENDCG
		}
	}
}
