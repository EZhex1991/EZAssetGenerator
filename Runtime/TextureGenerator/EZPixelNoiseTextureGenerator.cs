/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-09-03 10:57:51
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine;

namespace EZhex1991.EZAssetGenerator
{
    [CreateAssetMenu(
        fileName = nameof(EZPixelNoiseTextureGenerator),
        menuName = MenuName_TextureGenerator + nameof(EZPixelNoiseTextureGenerator),
        order = (int)EZAssetMenuOrder.EZPixelNoiseTextureGenerator
    )]
    public class EZPixelNoiseTextureGenerator : EZTextureGeneratorPixel
    {
        public int randomSeed = 17685;
        public bool colored;

        [EZCurveRect]
        public AnimationCurve outputCurve = AnimationCurve.Linear(0, 0, 1, 1);

        [EZCurveRect]
        public AnimationCurve outputCurveR = AnimationCurve.Linear(0, 0, 1, 1);
        [EZCurveRect]
        public AnimationCurve outputCurveG = AnimationCurve.Linear(0, 0, 1, 1);
        [EZCurveRect]
        public AnimationCurve outputCurveB = AnimationCurve.Linear(0, 0, 1, 1);
        [EZCurveRect]
        public AnimationCurve outputCurveA = AnimationCurve.Linear(0, 0, 1, 1);


        public override void SetTexturePixels(Texture2D texture)
        {
            Random.State originalState = Random.state;
            Random.InitState(randomSeed);

            for (int x = 0; x < texture.width; x++)
            {
                for (int y = 0; y < texture.height; y++)
                {
                    Color color = Color.white;
                    if (colored)
                    {
                        color.r = outputCurveR.Evaluate(Random.value);
                        color.g = outputCurveG.Evaluate(Random.value);
                        color.b = outputCurveB.Evaluate(Random.value);
                        color.a = outputCurveA.Evaluate(Random.value);
                    }
                    else
                    {
                        color = Color.white * outputCurve.Evaluate(Random.value);
                    }
                    texture.SetPixel(x, y, color);
                }
            }

            Random.state = originalState;
        }
    }
}
