﻿using System;
using System.Collections.Generic;

namespace TacoBell_API.Models;

public partial class Drink
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public float? Cost { get; set; }

    public bool? Slushie { get; set; }
}
