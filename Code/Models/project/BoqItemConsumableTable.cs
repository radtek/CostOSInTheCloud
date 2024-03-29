﻿using System;

namespace Models.project
{
    [Serializable]
    public class BoqItemConsumableTable
    {
        public const long serialVersionUID = 1L;

        public static readonly string[] FIELDS = new string[] { "factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "totalUnits", "finalRate", "totalCost", "fixedCost", "finalFixedCost", "variableCost", "comment" };

        public long? boqItemConsumableId;
        public decimal factor1;
        public decimal factor2;
        public decimal factor3;
        public decimal quantityPerUnit;
        public string quantityPerUnitFormula;
        public sbyte? quantityPerUnitFormulaState;
        public decimal exchangeRate;
        public decimal totalUnits;
        public decimal finalRate;
        public decimal totalCost;
        public decimal localFactor;
        public string localCountry;
        public string localStateProvince;
        public bool? hasUserTotalUnits;
        public DateTime lastUpdate;
        public long? paramItemId;
        //public ParamItemTable paramItemTable;
        public BoqItemTable boqItemTable;

        // FIXED COST:
        public decimal fixedCost;
        public decimal finalFixedCost = decimal.Zero;
        public decimal variableCost = decimal.Zero;
        //public ConsumableTable consumableTable;
        public string comment;
        public string pvVars;

        public BoqItemConsumableTable()
        { }
    }
}