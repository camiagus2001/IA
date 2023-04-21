// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Water"
{
	Properties
	{
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_FlowMap("FlowMap", 2D) = "white" {}
		_Speed("Speed", Vector) = (0.05,0.075,0,0)
		_FlowIntensity("Flow Intensity", Range( 0 , 0.25)) = 0.26
		_Float0("Float 0", Float) = 13.63
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows exclude_path:deferred vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
			float4 screenPosition15;
		};

		uniform sampler2D _TextureSample0;
		uniform float2 _Speed;
		uniform sampler2D _FlowMap;
		uniform float _FlowIntensity;
		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float _Float0;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_vertex3Pos = v.vertex.xyz;
			float3 vertexPos15 = ase_vertex3Pos;
			float4 ase_screenPos15 = ComputeScreenPos( UnityObjectToClipPos( vertexPos15 ) );
			o.screenPosition15 = ase_screenPos15;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 temp_cast_0 = (3.6).xx;
			float2 uv_TexCoord2 = i.uv_texcoord * temp_cast_0;
			float2 temp_cast_2 = (0.0).xx;
			float2 temp_cast_3 = (3.6).xx;
			float2 uv_TexCoord12 = i.uv_texcoord * temp_cast_3;
			float2 panner11 = ( 1.0 * _Time.y * temp_cast_2 + uv_TexCoord12);
			float4 lerpResult10 = lerp( float4( uv_TexCoord2, 0.0 , 0.0 ) , tex2D( _FlowMap, panner11 ) , _FlowIntensity);
			float2 panner1 = ( 1.0 * _Time.y * _Speed + lerpResult10.rg);
			o.Albedo = tex2D( _TextureSample0, panner1 ).rgb;
			float4 ase_screenPos15 = i.screenPosition15;
			float4 ase_screenPosNorm15 = ase_screenPos15 / ase_screenPos15.w;
			ase_screenPosNorm15.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm15.z : ase_screenPosNorm15.z * 0.5 + 0.5;
			float screenDepth15 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm15.xy ));
			float distanceDepth15 = abs( ( screenDepth15 - LinearEyeDepth( ase_screenPosNorm15.z ) ) / ( _Float0 ) );
			float3 temp_cast_6 = (( 1.0 - saturate( distanceDepth15 ) )).xxx;
			o.Emission = temp_cast_6;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
0;452;1034.2;323.4;316.6479;443.6383;1.575159;False;False
Node;AmplifyShaderEditor.RangedFloatNode;5;-1625.603,-570.4011;Inherit;False;Constant;_Float1;Float 1;1;0;Create;True;0;0;0;False;0;False;3.6;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;12;-1385.283,-457.4267;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;13;-1319.411,-284.8947;Inherit;False;Constant;_FloatSpeed;FloatSpeed;3;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;11;-1061.785,-398.6092;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;8;-860.8895,-405.5989;Inherit;True;Property;_FlowMap;FlowMap;1;0;Create;True;0;0;0;False;0;False;-1;26ad3bf22a052434782bec454dc5b32a;26ad3bf22a052434782bec454dc5b32a;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PosVertexDataNode;24;-82.11732,-139.3384;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;14;-849.4854,-181.5836;Inherit;False;Property;_FlowIntensity;Flow Intensity;3;0;Create;True;0;0;0;False;0;False;0.26;0;0;0.25;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;16;11.45374,37.77404;Inherit;False;Property;_Float0;Float 0;4;0;Create;True;0;0;0;False;0;False;13.63;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-1027.922,-591.2278;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DepthFade;15;160.3664,-65.99168;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;10;-497.0366,-473.4972;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;7;-491.3477,-185.5494;Inherit;False;Property;_Speed;Speed;2;0;Create;True;0;0;0;False;0;False;0.05,0.075;0.05,0.075;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SaturateNode;23;448.9708,-62.90825;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;1;-250.3506,-348.6451;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;22;600.4945,-62.30264;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;3;-47.29102,-343.1102;Inherit;True;Property;_TextureSample0;Texture Sample 0;0;0;Create;True;0;0;0;False;0;False;-1;8523dc096ca45e24ca7f59c01c815669;8523dc096ca45e24ca7f59c01c815669;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;833.1429,-374.3814;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Water;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;0;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;12;0;5;0
WireConnection;11;0;12;0
WireConnection;11;2;13;0
WireConnection;8;1;11;0
WireConnection;2;0;5;0
WireConnection;15;1;24;0
WireConnection;15;0;16;0
WireConnection;10;0;2;0
WireConnection;10;1;8;0
WireConnection;10;2;14;0
WireConnection;23;0;15;0
WireConnection;1;0;10;0
WireConnection;1;2;7;0
WireConnection;22;0;23;0
WireConnection;3;1;1;0
WireConnection;0;0;3;0
WireConnection;0;2;22;0
ASEEND*/
//CHKSM=0D0FE651D5CDB71BA85F62B32167760DBB8A3861