using AMBEV.AS.Utils.Attributes;

namespace AMBEV.AS.Utils.Enum
{
    public enum GenreEnum
    {
        [StringValue("Religion")]
        Religion = 1,
        [StringValue("Science")]
        Science,
        [StringValue("Biology")]
        Biology,
        [StringValue("Mathematics")]
        Mathematics,
        [StringValue("Philosophy")]
        Philosophy,
        [StringValue("Chemistry")]
        Chemistry
    }
}