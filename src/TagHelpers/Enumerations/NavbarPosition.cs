namespace Dgmjr.AspNetCore.TagHelpers.Enumerations;

public enum Position
{
    None = 0,

    [EnumInfo("fixed-top")]
    FixedTop,

    [EnumInfo("fixed-top")]
    fixedtop = FixedTop,

    [EnumInfo("fixed-bottom")]
    FixedBottom,

    [EnumInfo("fixed-bottom")]
    fixedbottom = FixedBottom,

    [EnumInfo("sticky-top")]
    StickyTop,

    [EnumInfo("sticky-top")]
    stickytop = StickyTop,

    [EnumInfo("sticky-bottom")]
    StickyBottom,

    [EnumInfo("sticky-bottom")]
    stickybottom = StickyBottom
}
