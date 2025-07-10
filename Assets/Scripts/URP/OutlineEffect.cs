using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace URP
{
    public class OutlineEffect : ScriptableRendererFeature
    {
        class OutlineRenderPass : ScriptableRenderPass
        {
            public List<Material> outlineMaterials;
            
            public OutlineRenderPass(List<Material> materials)
            {
                outlineMaterials = materials;
                renderPassEvent = RenderPassEvent.AfterRenderingOpaques;
            }

            public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
            {
                
            }
            
            public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
            {
                CommandBuffer cmd = CommandBufferPool.Get("OutlineRenderPass");
                
                cmd.SetRenderTarget(renderingData.cameraData.renderer.cameraDepthTargetHandle);
                cmd.ClearRenderTarget(false, true, Color.clear);
                
                var settings = new DrawingSettings(new ShaderTagId("UniversalForward"), new SortingSettings(renderingData.cameraData.camera));
                var filterSettings = new FilteringSettings(RenderQueueRange.opaque);
                context.DrawRenderers(renderingData.cullResults, ref settings, ref filterSettings);

                foreach (Material material in outlineMaterials)
                {
                    var drawSettings = new DrawingSettings(new ShaderTagId("Outline"), new SortingSettings(renderingData.cameraData.camera))
                    {
                        overrideMaterial = material
                    };
                    var filterSettingsOutline = new
                    FilteringSettings(RenderQueueRange.opaque);
                    context.DrawRenderers(renderingData.cullResults, ref
                    drawSettings, ref filterSettingsOutline);
                }
                context.ExecuteCommandBuffer(cmd);
                CommandBufferPool.Release(cmd);
            }
            public override void OnCameraCleanup(CommandBuffer cmd)
            {
                
            }
        }
        
        OutlineRenderPass outlinePass;
        public List<Material> outlineMaterials;
        
        public override void Create()
        {
            outlinePass = new OutlineRenderPass(outlineMaterials);
            outlinePass.renderPassEvent = RenderPassEvent.AfterRenderingOpaques;
        }
        
        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(outlinePass);
        }
    }
}
