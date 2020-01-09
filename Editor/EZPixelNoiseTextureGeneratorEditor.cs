/* Author:          ezhex1991@outlook.com
 * CreateTime:      2020-01-09 18:02:20
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEditor;

namespace EZhex1991.EZTextureProcessor
{
    [CustomEditor(typeof(EZPixelNoiseTextureGenerator))]
    public class EZPixelNoiseTextureGeneratorEditor : EZTextureGeneratorEditor
    {
        private SerializedProperty m_RandomSeed;
        private SerializedProperty m_Colored;
        private SerializedProperty m_OutputCurve;
        private SerializedProperty m_OutputCurveR;
        private SerializedProperty m_OutputCurveG;
        private SerializedProperty m_OutputCurveB;
        private SerializedProperty m_OutputCurveA;

        protected override void GetInputProperties()
        {
            m_RandomSeed = serializedObject.FindProperty(nameof(EZPixelNoiseTextureGenerator.randomSeed));
            m_Colored = serializedObject.FindProperty(nameof(EZPixelNoiseTextureGenerator.colored));
            m_OutputCurve = serializedObject.FindProperty(nameof(EZPixelNoiseTextureGenerator.outputCurve));
            m_OutputCurveR = serializedObject.FindProperty(nameof(EZPixelNoiseTextureGenerator.outputCurveR));
            m_OutputCurveG = serializedObject.FindProperty(nameof(EZPixelNoiseTextureGenerator.outputCurveG));
            m_OutputCurveB = serializedObject.FindProperty(nameof(EZPixelNoiseTextureGenerator.outputCurveB));
            m_OutputCurveA = serializedObject.FindProperty(nameof(EZPixelNoiseTextureGenerator.outputCurveA));
        }

        protected override void DrawInputSettings()
        {
            EditorGUILayout.PropertyField(m_RandomSeed);
            EditorGUILayout.PropertyField(m_Colored);
            if (m_Colored.boolValue)
            {
                EditorGUILayout.PropertyField(m_OutputCurveR);
                EditorGUILayout.PropertyField(m_OutputCurveG);
                EditorGUILayout.PropertyField(m_OutputCurveB);
                EditorGUILayout.PropertyField(m_OutputCurveA);
            }
            else
            {
                EditorGUILayout.PropertyField(m_OutputCurve);
            }
        }
    }
}
