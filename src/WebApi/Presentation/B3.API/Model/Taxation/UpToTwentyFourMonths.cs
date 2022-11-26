﻿using B3.API.Model.Interface;

namespace B3.API.Model.Taxation
{
    public class UpToTwentyFourMonths : ITax
    {
        public decimal Calculate(decimal valorRendimento) => Math.Round(valorRendimento - (valorRendimento * (17.5M / 100)), 2, MidpointRounding.ToEven);
    }
}
