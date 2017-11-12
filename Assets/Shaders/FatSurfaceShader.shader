Shader "Custom/FatSurfaceShader" {
	Properties{
		_MainTex("Texture", 2D) = "white" {}
	Amount("Extrusion Amount", Range(-0.0015,0.0150)) = 0
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM
#pragma surface surf Lambert vertex:vert
	struct Input {
		float2 uv_MainTex;
	};
	float Amount;
	void vert(inout appdata_full v) {
		v.vertex.xyz += v.normal * Amount;
	}
	sampler2D _MainTex;
	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
	}
	ENDCG
	}
		Fallback "Diffuse"
}