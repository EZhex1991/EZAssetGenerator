/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-03-19 09:49:34
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEditor;
using UnityEngine;

namespace EZhex1991.EZAssetGenerator
{
    [CustomEditor(typeof(EZTextureGeneratorPixel), true)]
    public class EZTextureGeneratorPixelEditor : EZTextureGeneratorBaseEditor
    {
        protected EZTextureGeneratorPixel generatorPixel;

        protected Texture2D m_PreviewTexture;
        protected Texture2D previewTexture
        {
            get
            {
                if (m_PreviewTexture == null)
                {
                    m_PreviewTexture = new Texture2D(generator.previewResolution.x, generator.previewResolution.y, generator.outputFormat, false);
                }
                return m_PreviewTexture;
            }
            set
            {
                m_PreviewTexture = value;
            }
        }

        protected override void OnEnable()
        {
            generatorPixel = target as EZTextureGeneratorPixel;
            base.OnEnable();
        }

        public override void DrawPreview(Rect previewArea)
        {
            EditorGUI.DrawTextureTransparent(previewArea, previewTexture, generator.previewScaleMode);
        }
        protected override void CheckPreviewResolution()
        {
            if (previewTexture.width != generator.previewResolution.x || previewTexture.height != generator.previewResolution.y || previewTexture.format != generator.outputFormat)
            {
                previewTexture = new Texture2D(generator.previewResolution.x, generator.previewResolution.y, generator.outputFormat, false);
            }
        }
        protected override void RefreshPreview()
        {
            generator.SetTexturePixels(previewTexture);
            previewTexture.Apply();
            Repaint();
        }
    }
}
