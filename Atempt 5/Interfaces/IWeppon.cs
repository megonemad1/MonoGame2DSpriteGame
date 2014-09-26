using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Interfaces
{
    interface IWeppon
    {
        float Damage{get; set;}
        void ApplyEffect();
    }
}
