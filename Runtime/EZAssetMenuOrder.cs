/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-04-12 15:57:09
 * Organization:    #ORGANIZATION#
 * Description:     
 */
namespace EZhex1991.EZAssetGenerator
{
    public enum EZAssetMenuOrder
    {
        _____SECTION_0_____ = 6990,
        EZGradient1DTextureGenerator,
        EZGradient2DTextureGenerator,
        EZGaussianLutGenerator,
        EZWaveTextureGenerator,
        EZMaterialToTexture,

        _____SECTION_1_____ = _____SECTION_0_____ + 100,
        EZPerlinNoiseTextureGenerator,
        EZPixelNoiseTextureGenerator,
        EZSimpleNoiseTextureGenerator,
        EZVoronoiTextureGenerator,

        _____SECTION_2_____ = _____SECTION_0_____ + 200,
        EZTextureBlurProcessor,
        EZTextureSpherize,
        EZTextureTwirl,
        EZTextureChannelModifier,
        EZTextureCombiner,
        EZTexturePipeline,

        _____SECTION_3_____ = _____SECTION_0_____ + 300,
        EZPlaneGenerator,
        EZBoxGenerator,
        EZUVSphereGenerator,

    }
}
