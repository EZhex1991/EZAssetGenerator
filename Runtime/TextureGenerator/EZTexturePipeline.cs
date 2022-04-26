/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-08-20 13:23:31
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine;

namespace EZhex1991.EZAssetGenerator
{
    [CreateAssetMenu(
        fileName = nameof(EZTexturePipeline),
        menuName = MenuName_TextureGenerator + nameof(EZTexturePipeline),
        order = (int)EZAssetMenuOrder.EZTexturePipeline
    )]
    public class EZTexturePipeline : EZTextureGeneratorBase
    {
        public EZTextureGeneratorBase[] m_TextureGenerators;
        public EZTextureGeneratorBase[] textureGenerators { get { return m_TextureGenerators; } }

        public override bool previewAutoUpdate { get { return false; } }

        public override void SetTexturePixels(Texture2D texture)
        {
            for (int i = 0; i < textureGenerators.Length; i++)
            {
                if (textureGenerators[i] == null) continue;
                textureGenerators[i].SetTexturePixels(texture);
            }
        }
    }
}
