﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WydatkiDomoweWeb.Domain.Entities;

namespace WydatkiDomoweWeb.Domain.Abstract
{
    public interface ICityRepository
    {
        IEnumerable<City> Cities { get; }
    }
}
