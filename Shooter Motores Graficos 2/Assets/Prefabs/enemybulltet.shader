Shader "Custom/ocean"
{
	Properties
	{
		_MainTex("Texture", 2D ) = "red" {}
	    //velocidad que se mueve la textura
		_Speed("Speed", Range(0,10)) = 0.5 

			//configuracion de las ondas
			_Amplitude("Amplitude",Range(0,2)) = 0
		_Frecuency("Frecuency", Range(0, 2)) = 0
		_Phase("Phase", Range(0, 2)) = 0
	}

    Subshader
	{

		tags {"RenderType" = "Opaque"}
		LOD 100

		pass
		{
		  CGPROGRAM
		  #pragma vertex vert
		  #pragma fragment frag
			#include  "UnityCG.cginc"

			  struct VertexInput
			  {

			   float4 vertex : POSITION;
			   float2 uv : TEXCOORD0;

			   float4 normal : NORMAL;
			  };

		  struct VertexOutput
		  {

			  float4 vertex : POSITION;
			  float2 uv : TEXCOORD0;

		  };

		  uniform  sampler2D _MainTex;
		  uniform float4 _MainTex_ST;
		  uniform float _Speed;

		  static const float PI2 = 6.28318530717959f;

		  uniform float _Amplitude;
		  uniform float _Frecuency;
		  uniform float _Phase;


		  VertexOutput vert (VertexInput input)
		  {

			  float wave = _Amplitude * sin(PI2 * _Frecuency * input.uv.x * _Time.y + _Speed);

			  input.vertex += input.normal * wave;

			  VertexOutput output;

			 


			  output.vertex = UnityObjectToClipPos(input.vertex);
			  output.uv = input.uv * _MainTex_ST.xy + _MainTex_ST.zw + _Time.x * _Speed;

			 

			  return output;
		  }

		  fixed4 frag(VertexOutput input) : SV_TARGET
		  {

			  return tex2D(_MainTex,input.uv);

		  }

		  ENDCG

		 }
	}
}
