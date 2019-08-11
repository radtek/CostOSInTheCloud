﻿using System;

namespace Desktop.common.nomitech.common.bim.bimengine.impl
{
	using BIMQTOType = nomitech.bimengine.types.BIMQTOType;
	using BIMExtensionPropertiesUtil = nomitech.common.bim.ifcengine.BIMExtensionPropertiesUtil;
	using IfcEnginePropertiesData = nomitech.common.ifc.IfcEnginePropertiesData;
	using IfcEngineQuantitiesData = nomitech.common.ifc.IfcEngineQuantitiesData;
	using BIMPropertySet = nomitech.ifcengine.props.BIMPropertySet;

	public class BEBIMPlate : BIMPlate
	{
	  public BEBIMPlate(object[] paramArrayOfObject, IfcEngineQuantitiesData paramIfcEngineQuantitiesData, IfcEnginePropertiesData paramIfcEnginePropertiesData)
	  {
		Id = (long?)paramArrayOfObject[0];
		GlobalId = (string)paramArrayOfObject[1];
		string str1 = (string)paramArrayOfObject[3];
		string str2 = (string)paramArrayOfObject[5];
		string str3 = (string)paramArrayOfObject[9];
		string str4 = (string)paramArrayOfObject[10];
		string str5 = (string)paramArrayOfObject[11];
		paramIfcEnginePropertiesData.Material = str3;
		paramIfcEnginePropertiesData.Type = str4;
		paramIfcEnginePropertiesData.Layer = str5;
		Material = paramIfcEnginePropertiesData.Material;
		Type = paramIfcEnginePropertiesData.Type;
		Layer = paramIfcEnginePropertiesData.Layer;
		Name = str1;
		Label = str1;
		BimToolId = str2;
		TopElevation = paramIfcEngineQuantitiesData.TopElevation;
		TopElevationQT = BIMQuantityType.QTY_MILLI_METER;
		BottomElevation = paramIfcEngineQuantitiesData.BottomElevation;
		BottomElevationQT = BIMQuantityType.QTY_MILLI_METER;
		LastUpdate = DateTime.Now;
		Area = paramIfcEngineQuantitiesData.FootprintNetArea;
		AreaQT = BIMQuantityType.QTY_SQUARE_METER;
		Volume = paramIfcEngineQuantitiesData.NetVolume;
		VolumeQT = BIMQuantityType.QTY_CUBIC_METER;
		System.Collections.IList list = paramIfcEnginePropertiesData.PropSetList;
		BIMPropertySet bIMPropertySet = BIMExtensionPropertiesUtil.createPropertySet("CalcQuantities");
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcFootprintArea", AreaQT, Area));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcVolume", VolumeQT, Volume));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcHeight", BIMQuantityType.QTY_MILLI_METER, paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.HEIGHT).doubleValue()));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcWidth", BIMQuantityType.QTY_MILLI_METER, paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.WIDTH).doubleValue()));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcNetArea", BIMQuantityType.QTY_SQUARE_METER, paramIfcEngineQuantitiesData.getQuantity(BIMQTOType.SIDE_NET_AREA).doubleValue()));
		bIMPropertySet.Properties.add(BIMExtensionPropertiesUtil.createDoubleProperty("CalcPiece", 0, 1.0D));
		list.Insert(0, bIMPropertySet);
		ExtensionProperties = list;
		Architecture = true;
		Landscaping = true;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\bimengine\impl\BEBIMPlate.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}