Shader "Custom/StencilFront"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
    }

    SubShader
    {
        
        Tags { "RenderPipeline"="UniversalRenderPipeline" "Queue"="Geometry-1" }

        // Don't write color or depth; always pass depth test to update stencil even when occluded.
        ColorMask 0
        ZWrite Off
        ZTest Always
        Cull Off

        // Write stencil ref=1 unconditionally.
        Stencil
        {
            Ref 1
            Comp Always
            Pass Replace
        }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes { float4 positionOS : POSITION; };
            struct Varyings   { float4 positionHCS : SV_POSITION; };

            Varyings vert (Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                return OUT;
            }

            half4 frag (Varyings IN) : SV_Target
            {
                // Not rendered due to ColorMask 0; fragment still executes to update stencil.
                return half4(0,0,0,1);
            }
            ENDHLSL
        }
    }
}