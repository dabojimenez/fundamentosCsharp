﻿using System;
using System.Collections.Generic;
using System.Text;

namespace fundamentosCsharp.Models
{
    public interface IBebidaAlcoholica
    {
        public int Alcohol { get; set; }

        public void MaximoRecomendado();
    }
}
