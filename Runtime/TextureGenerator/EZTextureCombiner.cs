/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-05-15 15:48:51
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine;

namespace EZhex1991.EZAssetGenerator
{
    [CreateAssetMenu(
        fileName = nameof(EZTextureCombiner),
        menuName = MenuName_TextureGenerator + nameof(EZTextureCombiner),
        order = (int)EZAssetMenuOrder.EZTextureCombiner
    )]
    public class EZTextureCombiner : EZTextureGeneratorRender
    {
        private static class Uniforms
        {
            public static readonly string ShaderName = "Hidden/EZTextureProcessor/Combiner";
            public static readonly int PropertyID_AddTex = Shader.PropertyToID("_AddTex");
        }

        public override string defaultShaderName { get { return Uniforms.ShaderName; } }


        public Texture m_Background;
        public override Texture inputTexture { get { return m_Background == null ? Texture2DExt.white : m_Background; } }

        [System.NonSerialized]
        protected Material m_Material;
        public override Material material
        {
            get
            {
                if (m_Material == null && shader != null)
                {
                    m_Material = new Material(shader);
                }
                return m_Material;
            }
        }
        public Vector2Int cellSize = new Vector2Int(2, 2);
        public Texture2D[] inputTextures = new Texture2D[36];

        public override void ProcessTexture(Texture sourceTexture, RenderTexture destinationTexture)
        {
            if (material != null)
            {
                RenderTexture lastTexture = RenderTexture.GetTemporary(destinationTexture.width, destinationTexture.height);
                Graphics.Blit(inputTexture, lastTexture);
                for (int i = 0; i < cellSize.x; i++)
                {
                    for (int j = 0; j < cellSize.y; j++)
                    {
                        RenderTexture tempTexture = RenderTexture.GetTemporary(destinationTexture.width, destinationTexture.height);
                        material.SetTexture(Uniforms.PropertyID_AddTex, inputTextures[j * 6 + i]);
                        material.SetTextureScale(Uniforms.PropertyID_AddTex, cellSize);
                        material.SetTextureOffset(Uniforms.PropertyID_AddTex, -new Vector2(i, j));
                        Graphics.Blit(lastTexture, tempTexture, material);
                        RenderTexture.ReleaseTemporary(lastTexture);
                        lastTexture = tempTexture;
                    }
                }
                Graphics.Blit(lastTexture, destinationTexture);
                RenderTexture.ReleaseTemporary(lastTexture);
            }
            else
            {
                Graphics.Blit(sourceTexture, destinationTexture);
            }
        }
    }
}
