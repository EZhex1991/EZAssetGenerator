/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-08-20 13:45:47
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace EZhex1991.EZAssetGenerator
{
    [CustomEditor(typeof(EZTexturePipeline))]
    public class EZTexturePipelineEditor : EZTextureGeneratorPixelEditor
    {
        protected SerializedProperty m_TextureGenerators;
        protected ReorderableList textureGeneratorList;

        protected override void GetInputProperties()
        {
            m_TextureGenerators = serializedObject.FindProperty(nameof(m_TextureGenerators));
            textureGeneratorList = new ReorderableList(serializedObject, m_TextureGenerators)
            {
                drawHeaderCallback = DrawProcessorListHeader,
                drawElementCallback = DrawProcessorListElement,
            };
        }
        protected override void DrawInputSettings()
        {
            textureGeneratorList.DoLayoutList();
        }

        private void DrawProcessorListHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, m_TextureGenerators.displayName);
        }
        private void DrawProcessorListElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty element = m_TextureGenerators.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(new Rect(rect) { height = EditorGUIUtility.singleLineHeight }, element);
        }
    }
}
