﻿using Evaluacion.Despacho.COMMON;
using Evaluacion.Despacho.DATA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.BUSINESS.Interfaces
{
    public interface IBusinessGenero
    {
        public OperationResult<List<Genero>> Get();
    }
}
