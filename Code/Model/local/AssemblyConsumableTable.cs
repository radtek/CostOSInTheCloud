﻿using System;

namespace Model.local
{

	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = Desktop.common.nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = Desktop.common.nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = Desktop.common.nomitech.common.@base.ResourceWithAssignmentsTable;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="ASSEMBLY_CONSUMABLE"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class AssemblyConsumableTable : ResourceToAssignmentTable, ProjectIdEntity
	{

		private static readonly decimal ONE = BigDecimalMath.ONE;

		public static readonly string[] FIELDS = new string[] {"factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "finalRate", "fixedCost", "finalFixedCost", "comment"};

		private long? assemblyConsumableId = null;
		private DateTime lastUpdate = null;
		private decimal factor1 = null;
		private decimal factor2 = null;
		private decimal factor3 = null;
		private decimal quantityPerUnit = null;
		private string quantityPerUnitFormula;
		private sbyte? quantityPerUnitFormulaState;
		private decimal localFactor;
		private string localCountry;
		private string localStateProvince;
		private decimal exchangeRate = null;
		private long? consumableTableId = null;
		private ConsumableTable consumableTable = null;
		private AssemblyTable assemblyTable;
		private decimal finalRate;
		private decimal fixedCost = decimal.Zero;
		private decimal finalFixedCost = decimal.Zero;
		private string comment;

		/// <summary>
		/// This String declares which SQL COLUMN contains which PV Variables
		/// 	e.g. <code>CUSRATE1FORM:var1,var2;CUSTXT1FORM:mitsos,george;MARKUPFORM:var2,mitsos</code>
		/// </summary>
		private string pvVars;

		public AssemblyConsumableTable()
		{

		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient public Object clone(boolean cloneAssembly, boolean cloneConsumable)
		public virtual object clone(bool cloneAssembly, bool cloneConsumable)
		{
			AssemblyConsumableTable obj = new AssemblyConsumableTable();

			obj.AssemblyConsumableId = AssemblyConsumableId;
			obj.LastUpdate = LastUpdate;
			//obj.setFinalRate(getFinalRate());
			obj.Factor1 = Factor1;
			obj.Factor2 = Factor2;
			obj.Factor3 = Factor3;

			obj.QuantityPerUnit = QuantityPerUnit;
			obj.QuantityPerUnitFormula = QuantityPerUnitFormula;
			obj.QuantityPerUnitFormulaState = QuantityPerUnitFormulaState;

			obj.LocalFactor = LocalFactor;
			obj.LocalCountry = LocalCountry;
			obj.LocalStateProvince = LocalStateProvince;
			obj.ExchangeRate = ExchangeRate;
			obj.ConsumableTableId = ConsumableTableId;
			obj.ProjectId = ProjectId;
			obj.FixedCost = FixedCost;
			obj.Comment = Comment;
			obj.Comment = Comment;
			obj.PvVars = PvVars;

			try
			{
				obj.FinalRate = calculateFinalRate();
				obj.FinalFixedCost = calculateFinalFixedCost();
			}
			catch (System.NullReferenceException)
			{
				// ignore!
			}

			if (AssemblyTable != null && cloneAssembly)
			{
				obj.AssemblyTable = (AssemblyTable) AssemblyTable.clone();
			}

			if (ConsumableTable != null && cloneConsumable)
			{
				obj.ConsumableTable = (ConsumableTable) ConsumableTable.Clone();
			}

			return obj;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient public Object clone(boolean relations)
		public virtual object clone(bool relations)
		{
			if (relations)
			{
				return clone(true, true);
			}
			AssemblyConsumableTable obj = new AssemblyConsumableTable();

			obj.AssemblyConsumableId = AssemblyConsumableId;
			obj.LastUpdate = LastUpdate;
			//obj.setFinalRate(getFinalRate());
			obj.Factor1 = Factor1;
			obj.Factor2 = Factor2;
			obj.Factor3 = Factor3;

			obj.QuantityPerUnit = QuantityPerUnit;
			obj.QuantityPerUnitFormula = QuantityPerUnitFormula;
			obj.QuantityPerUnitFormulaState = QuantityPerUnitFormulaState;

			obj.LocalFactor = LocalFactor;
			obj.LocalCountry = LocalCountry;
			obj.LocalStateProvince = LocalStateProvince;
			obj.ExchangeRate = ExchangeRate;
			obj.ConsumableTableId = ConsumableTableId;
			obj.ProjectId = ProjectId;
			obj.FixedCost = FixedCost;
			obj.Comment = Comment;
			obj.PvVars = PvVars;

			try
			{
				obj.FinalRate = calculateFinalRate();
				obj.FinalFixedCost = calculateFinalFixedCost();
			}
			catch (System.NullReferenceException)
			{
				// ignore!
			}

			return obj;
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ASSEMBLYCONSUMABLEID" </summary>
		/// <returns> Long </returns>
		public virtual long? AssemblyConsumableId
		{
			get
			{
				return assemblyConsumableId;
			}
			set
			{
				assemblyConsumableId = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LASTUPDATE" type="timestamp" </summary>
		/// <returns> lastUpdate </returns>
		public virtual DateTime LastUpdate
		{
			get
			{
				return lastUpdate;
			}
			set
			{
				lastUpdate = value;
			}
		}


		public virtual decimal calculateFinalRate()
		{

			if (AssemblyTable != null && ConsumableTable != null)
			{
				finalRate = ConsumableTable.RateForCalculation * Factor1;
				finalRate = finalRate * Factor2;
				finalRate = finalRate * Factor3;
				finalRate = finalRate * ExchangeRate;
				finalRate = finalRate * LocalFactor;
				finalRate = finalRate * QuantityPerUnit;

				finalRate = finalRate.setScale(10, decimal.ROUND_HALF_UP);
			}

			return finalRate;
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalRate
		{
			get
			{
				if (AssemblyTable != null && ConsumableTable != null)
				{
					return calculateFinalRate();
				}
    
				return finalRate;
			}
			set
			{
				finalRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FACTOR1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Factor1
		{
			get
			{
				return factor1;
			}
			set
			{
				factor1 = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FACTOR2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Factor2
		{
			get
			{
				return factor2;
			}
			set
			{
				factor2 = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DIVIDER" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Factor3
		{
			get
			{
				return factor3;
			}
			set
			{
				factor3 = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QTYPUNIT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> quantityPerUnit </returns>
		public virtual decimal QuantityPerUnit
		{
			get
			{
				return quantityPerUnit;
			}
			set
			{
				this.quantityPerUnit = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QTYPUNITFORM" type="costos_text" </summary>
		/// <returns> quantityPerUnitFormula </returns>
		public virtual string QuantityPerUnitFormula
		{
			get
			{
				return quantityPerUnitFormula;
			}
			set
			{
				this.quantityPerUnitFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QTYPUFORMSTATE" type="byte" </summary>
		/// <returns> quantityPerUnitFormulaState </returns>
		public virtual sbyte? QuantityPerUnitFormulaState
		{
			get
			{
				return quantityPerUnitFormulaState;
			}
			set
			{
				this.quantityPerUnitFormulaState = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LOCALFACTOR" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal LocalFactor
		{
			get
			{
				return localFactor;
			}
			set
			{
				this.localFactor = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LOCALCOUNTRY" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string LocalCountry
		{
			get
			{
				return localCountry;
			}
			set
			{
				this.localCountry = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LOCALSTATE"  type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string LocalStateProvince
		{
			get
			{
				return localStateProvince;
			}
			set
			{
				this.localStateProvince = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EXCHANGERATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal ExchangeRate
		{
			get
			{
				if (exchangeRate == null)
				{
					exchangeRate = ONE;
				}
				return exchangeRate;
			}
			set
			{
				if (value == null)
				{
					value = ONE;
				}
				this.exchangeRate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FIXEDCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> fixedCost </returns>
		public virtual decimal FixedCost
		{
			get
			{
				return fixedCost;
			}
			set
			{
				this.fixedCost = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FINALFIXEDCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> finalFixedCost </returns>
		public virtual decimal FinalFixedCost
		{
			get
			{
				finalFixedCost = calculateFinalFixedCost();
				return finalFixedCost;
			}
			set
			{
				this.finalFixedCost = value;
			}
		}


		/// <summary>
		/// This String declares which SQL COLUMN contains which PV Variables
		/// e.g. <code>CUSRATE1FORM:var1,var2;CUSTXT1FORM:mitsos,george;MARKUPFORM:var2,mitsos</code>
		/// 
		/// @hibernate.property column="PV_VARS" type="costos_text" </summary>
		/// <returns> pvVars </returns>
		public virtual string PvVars
		{
			get
			{
				return pvVars;
			}
			set
			{
				this.pvVars = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="CONSUMABLEID" </summary>
		/// <returns> ConsumableTable </returns>
		public virtual ConsumableTable ConsumableTable
		{
			get
			{
				return consumableTable;
			}
			set
			{
				this.consumableTable = value;
				if (value != null)
				{
					ConsumableTableId = value.ConsumableId;
				}
			}
		}


		public virtual long? ConsumableTableId
		{
			get
			{
				return consumableTableId;
			}
			set
			{
				this.consumableTableId = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="ASSEMBLYID" </summary>
		/// <returns> ConsumableTable </returns>
		public virtual AssemblyTable AssemblyTable
		{
			get
			{
				return assemblyTable;
			}
			set
			{
				assemblyTable = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COMMENT" type="costos_text" </summary>
		/// <returns> comment </returns>
		public virtual string Comment
		{
			get
			{
				return comment;
			}
			set
			{
				this.comment = value;
			}
		}


		public virtual AssemblyConsumableTable Data
		{
			set
			{
    
				AssemblyConsumableId = value.AssemblyConsumableId;
				LastUpdate = value.LastUpdate;
				//obj.setFinalRate(getFinalRate());
				Factor1 = value.Factor1;
				Factor2 = value.Factor2;
				Factor3 = value.Factor3;
    
				QuantityPerUnit = value.QuantityPerUnit;
				QuantityPerUnitFormula = value.QuantityPerUnitFormula;
				QuantityPerUnitFormulaState = value.QuantityPerUnitFormulaState;
    
				LocalFactor = value.LocalFactor;
				LocalCountry = value.LocalCountry;
				LocalStateProvince = value.LocalStateProvince;
				ExchangeRate = value.ExchangeRate;
				FixedCost = value.FixedCost;
				Comment = value.Comment;
				PvVars = value.PvVars;
    
				try
				{
					FinalRate = value.calculateFinalRate();
					FinalFixedCost = value.calculateFinalFixedCost();
				}
				catch (System.NullReferenceException)
				{
					// ignore!
				}
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Override public System.Nullable<long> getId()
		public override long? Id
		{
			get
			{
				return AssemblyConsumableId;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Override public nomitech.common.base.ResourceWithAssignmentsTable getResourceTable()
		public override ResourceWithAssignmentsTable getResourceTable()
		{
			return AssemblyTable;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Override public nomitech.common.base.ResourceTable getAssignmentResourceTable()
		public override ResourceTable AssignmentResourceTable
		{
			get
			{
				return ConsumableTable;
			}
			set
			{
				ConsumableTable = (ConsumableTable) value;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Override public void setData(nomitech.common.base.ResourceToAssignmentTable assignmentTable)
		public override ResourceToAssignmentTable Data
		{
			set
			{
				Data = (AssemblyConsumableTable) value;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Override public void setResourceTable(nomitech.common.base.ResourceTable resourceTable)
		public override void setResourceTable(ResourceTable resourceTable)
		{
			AssemblyTable = (AssemblyTable) resourceTable;
		}


		private long? projectId;

		//#RXL_START
		/// <summary>
		/// @hibernate.property column="PRJID" type="long" index="IDX_PRJID" </summary>
		/// <returns> BigDecimal </returns>
		//#RXL_END
		public override long? ProjectId
		{
			get
			{
				return projectId;
			}
			set
			{
				this.projectId = value;
			}
		}


	}
}