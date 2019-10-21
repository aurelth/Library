using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMBEV.AS.Utils.Attributes;

namespace Shared.Enums
{
    public enum StatusEnum
    {
        [StringValue("Available")]
        Available = 1,        
        [StringValue("Occupied")]
        Occupied,        
    }
}
