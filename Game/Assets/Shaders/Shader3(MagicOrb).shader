Shader "Custom/Shader3(MagicOrb)" {
	/*SUMMARY/
	This shader is simalr to the wave shader made in the exvercises of week 6.
	The main differences being the incooperation of sampling a texture for noise as well as a ramp texture.
	This results in a lava lamp effect on the surface of an object.
	*/
	Properties {
		 _RampTex("Ramp texture", 2D) = "white" {}
		_NoiseTex("Noise texture",2D) = "grey" {}
		_RampVal("Ramp offset", Range(-0.5, 0.5)) = 0
		_Amplitude("Amplitude factor", Range(0, 0.03)) = 0.01
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// This time we let unity know the name of the vertex function to look for.
		 #pragma surface surf Lambert vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0
		//The noise texture will be used to add a random variation to the manipulation of the
			//the objects verticies.
		//The ramp texture will be used to sample colours and light values. The lighter colours are used on vertices
			//that are moved further away from the object, whilst the darker ones remain closer to the core.
		//The ramp value used for the ramp offset determines the samples of colour used in the effect.
		sampler2D _NoiseTex;
		sampler2D _RampTex;
		fixed _RampVal;
		fixed _Amplitude;

		struct Input {
			float2 uv_NoiseTex;
		};

		void vert(inout appdata_full v) {
			//The noise texture coordinates is taken and assigned to noiseVal
			half noiseVal = tex2Dlod(_NoiseTex, float4(v.texcoord.xy, 0, 0)).r;
			//The displacement is calculated using the same method as the wave shader but
			//with the addition of our noise value onto time.
			//Since I'm not manipulating the frequency of the displacement, I used the regular time variable.
			v.vertex.xyz += v.normal * sin(_Time + noiseVal * 100)* _Amplitude;
		}

		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutput o) {
			//Now we calculate the noise value using the uv value of our noise texture.
			// We then add sin(time) onto it and finally divide by 15.
			//The division is important in making sure our value doesn't become to large making it hard to vary
			// the colours being sampled from the ramp texture.
			half noiseVal = tex2D(_NoiseTex, IN.uv_NoiseTex).r + (sin(_Time.y)) / 15;
			//our colour is then assigned adding our ramp value and noise value, the saturate method
			// truncates the final value which helps avoid undesired results.
			half4 color = tex2D(_RampTex, float2(saturate(_RampVal + noiseVal), 0.5));
			//We can then assign our new colour value to the Emission and Albedo, allowing us to see the result.
			o.Albedo = color.rgb;
			o.Emission = color.rgb;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
