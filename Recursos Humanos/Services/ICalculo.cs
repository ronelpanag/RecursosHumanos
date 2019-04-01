﻿using Recursos_Humanos.Models.Colaboradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Services
{
    interface ICalculo
    {
        IList<Empleado> Empleados();
        double NominaTotal();

    }
}
