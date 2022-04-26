/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-08-27 16:41:00
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEditor;
using UnityEngine;

namespace EZhex1991.EZAssetGenerator
{
    [CustomEditor(typeof(EZTextureGeneratorRender), true)]
    public class EZTextureGeneratorRenderEditor : EZTextureGeneratorBaseEditor
    {
        protected EZTextureGeneratorRender generatorRender;

        protected SerializedProperty m_Shader;

        protected RenderTexture m_PreviewTexture;
        protected RenderTexture previewTexture
        {
            get
            {
                if (m_PreviewTexture == null)
                {
                    m_PreviewTexture = RenderTexture.GetTemporary(generatorRender.previewResolution.x, generatorRender.previewResolution.y);
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
            generatorRender = target as EZTextureGeneratorRender;
            base.OnEnable();
        }
        protected override void GetInputProperties()
        {
            m_Shader = serializedObject.FindProperty("m_Shader");
        }
        protected override void DrawInputSettings()
        {
            GUI.enabled = false;
            EditorGUILayout.PropertyField(m_Shader);
            GUI.enabled = true;
            SerializedProperty iterator = m_Shader.Copy();
            while (iterator.Next(false))
            {
                EditorGUILayout.PropertyField(iterator, iterator.isExpanded);
            }
        }

        public override void DrawPreview(Rect previewArea)
        {
            if (generatorRender.inputTexture == null)
            {
                EditorGUI.DrawTextureTransparent(previewArea, previewTexture, generatorRender.previewScaleMode);
            }
            else
            {
                float width = previewArea.width / 2;
                Rect left = new Rect(previewArea.x + 5, previewArea.y + 5, width - 10, previewArea.height);
                Rect right = new Rect(previewArea.x + width + 5, previewArea.y + 5, width - 10, previewArea.height);
                EditorGUI.DrawTextureTransparent(left, generatorRender.inputTexture, generatorRender.previewScaleMode);
                EditorGUI.DrawTextureTransparent(right, previewTexture, generatorRender.previewScaleMode);
            }
        }
        protected override void CheckPreviewResolution()
        {
            if (previewTexture.width != generator.previewResolution.x || previewTexture.height != generator.previewResolution.y)
            {
                RenderTexture.ReleaseTemporary(previewTexture);
                previewTexture = RenderTexture.GetTemporary(generator.previewResolution.x, generator.previewResolution.y);
            }
        }
        protected override void RefreshPreview()
        {
            generatorRender.ProcessTexture(generatorRender.inputTexture, previewTexture);
            Repaint();
        }
    }
}
