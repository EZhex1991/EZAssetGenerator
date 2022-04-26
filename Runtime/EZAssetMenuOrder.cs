/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-04-12 15:57:09
 * Organization:    #ORGANIZATION#
 * Description:     
 */
namespace EZhex1991.EZAssetGenerator
{
    public enum EZAssetMenuOrder
    {
        _Section_0 = 11000,

        _Section_1 = _Section_0 + 100,
        EZGradient1DTextureGenerator,
        EZGradient2DTextureGenerator,
        EZGaussianLutGenerator,
        EZWaveTextureGenerator,
        EZMaterialToTexture,

        _Section_2 = _Section_0 + 200,
        EZPerlinNoiseTextureGenerator,
        EZPixelNoiseTextureGenerator,
        EZSimpleNoiseTextureGenerator,
        EZVoronoiTextureGenerator,

        _Section_3 = _Section_0 + 300,
        EZTextureBlurProcessor,
        EZTextureSpherize,
        EZTextureTwirl,
        EZTextureChannelModifier,
        EZTextureCombiner,
        EZTexturePipeline,

        _Section_4 = _Section_0 + 400,
        EZPlaneGenerator,
        EZBoxGenerator,
        EZUVSphereGenerator,

        _Section_5 = _Section_0 + 500,

        _Section_6 = _Section_0 + 600,

        _Section_7 = _Section_0 + 700,

        _Section_8 = _Section_0 + 800,

        _Section_9 = _Section_0 + 900,
    }
}
