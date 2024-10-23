using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoGarageWeb.Models
{
    public class Master
    {    
        public string Id { get; set; }
        public string Company { get; set; }
        public string CarName { get; set; }
        public string ModelNumber { get; set; }
        public string EngeenType { get; set; }
        public string Result { get; set; }
        public string Idencrypt { get; set; }
        public string CreatedBy { get; set; }
        public string BrakingAndSafety { get; set; }
        public string CarOption { get; set; }
        public string ChassisCondition { get; set; }
        public string CountryName { get; set; }
        public string ElectricalSystems { get; set; }
        public string Exterior { get; set; }
        public string HistoryAndRecord { get; set; }
        public string InspectionName { get; set; }
        public string PowerTrain { get; set; }
        public string ProductionYear { get; set; }
        
        public List<Master> lst { get; set; }
        public List<Master> Countrylst { get; set; }
        public List<Master> CarMasterlst { get; set; }
        public List<Master> BrakingAndSafetylst { get; set; }
        public List<Master> CarOptionlst { get; set; }
        public List<Master> ChassisConditionlst { get; set; }


        public DataSet SaveCarMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Company",Company),
                new SqlParameter("@CarName",CarName),
                new SqlParameter("@ModelNumber",ModelNumber),
                new SqlParameter("@EngeenType",EngeenType),
                 new SqlParameter("@CreatedBy",CreatedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveCarMaster", para);
            return ds;
        }
        public DataSet GetCarListMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@Company",Company),
                new SqlParameter("@EngeenType",EngeenType),
            };
            DataSet ds = Connection.ExecuteQuery("GetCarListMaster", para);
            return ds;
        }
        public DataSet UpdateCarMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@Id",Id),
                new SqlParameter("@Company",Company),
                new SqlParameter("@CarName",CarName),
                new SqlParameter("@ModelNumber",ModelNumber),
                new SqlParameter("@EngeenType",EngeenType)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateCarMaster", para);
            return ds;
        }
        public DataSet DeleteCarMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteCarMaster", para);
            return ds;
        }
        public DataSet SaveBrakingAndSafetyMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@BrakingAndSafety",BrakingAndSafety),
                 new SqlParameter("@CreatedBy",CreatedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveBrakingAndSafetyMaster", para);
            return ds;
        }
        public DataSet GetBrakingAndSafetyListMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@BrakingAndSafety",BrakingAndSafety),

            };
            DataSet ds = Connection.ExecuteQuery("GetBrakingAndSafetyListMaster", para);
            return ds;
        }
        public DataSet DeleteBrakingAndSafetyMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteBrakingAndSafetyMaster", para);
            return ds;
        }
        public DataSet UpdateBrakingAndSafetyMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@Id",Id),
                new SqlParameter("@BrakingAndSafety",BrakingAndSafety)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateBrakingAndSafetyMaster", para);
            return ds;
        }
        public DataSet SaveCarOptionMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@CarOption",CarOption),
                 new SqlParameter("@CreatedBy",CreatedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveCarOptionMaster", para);
            return ds;
        }
        public DataSet GetCarOptionListMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@CarOption",CarOption),
            };
            DataSet ds = Connection.ExecuteQuery("GetCarOptionListMaster", para);
            return ds;
        }
        public DataSet DeleteCarOptionMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteCarOptionMaster", para);
            return ds;
        }
        public DataSet UpdateCarOptionMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@Id",Id),
                new SqlParameter("@CarOption",CarOption)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateCarOptionMaster", para);
            return ds;
        }
        public DataSet SaveChassisConditionMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@ChassisCondition",ChassisCondition),
                 new SqlParameter("@CreatedBy",CreatedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveChassisConditionMaster", para);
            return ds;
        }
        public DataSet GetChassisConditionListMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@ChassisCondition",ChassisCondition),
            };
            DataSet ds = Connection.ExecuteQuery("GetChassisConditionListMaster", para);
            return ds;
        }
        public DataSet DeleteChassisConditionMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteChassisConditionMaster", para);
            return ds;
        }
        public DataSet UpdateChassisConditionMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@Id",Id),
                new SqlParameter("@ChassisCondition",ChassisCondition)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateChassisConditionMaster", para);
            return ds;
        }
        public DataSet SaveCountryMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@CountryName",CountryName),
                 new SqlParameter("@CreatedBy",CreatedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveCountryMaster", para);
            return ds;
        }
        public DataSet GetCountryListMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@CountryName",CountryName),
            };
            DataSet ds = Connection.ExecuteQuery("GetCountryListMaster", para);
            return ds;
        }
        public DataSet DeleteCountryMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteCountryMaster", para);
            return ds;
        }
        public DataSet UpdateCountryMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@Id",Id),
                new SqlParameter("@CountryName",CountryName)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateCountryMaster", para);
            return ds;
        }
        public DataSet SaveElectricalSystemsMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@ElectricalSystems",ElectricalSystems),
                 new SqlParameter("@CreatedBy",CreatedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveElectricalSystemsMaster", para);
            return ds;
        }
        public DataSet GetElectricalSystemsListMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@ElectricalSystems",ElectricalSystems),
            };
            DataSet ds = Connection.ExecuteQuery("GetElectricalSystemsListMaster", para);
            return ds;
        }
        public DataSet DeleteElectricalSystemsMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteElectricalSystemsMaster", para);
            return ds;
        }
        public DataSet UpdateElectricalSystemsMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@Id",Id),
                new SqlParameter("@ElectricalSystems",ElectricalSystems)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateElectricalSystemsMaster", para);
            return ds;
        }
        public DataSet SaveExteriorMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Exterior",Exterior),
                 new SqlParameter("@CreatedBy",CreatedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveExteriorMaster", para);
            return ds;
        }
        public DataSet GetExteriorListMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@Exterior",Exterior),
            };
            DataSet ds = Connection.ExecuteQuery("GetExteriorListMaster", para);
            return ds;
        }
        public DataSet UpdateExteriorMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@Id",Id),
                new SqlParameter("@Exterior",Exterior)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateExteriorMaster", para);
            return ds;
        }
        public DataSet DeleteExteriorMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteExteriorMaster", para);
            return ds;
        }
        public DataSet SaveHistoryAndRecordMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@HistoryAndRecord",HistoryAndRecord),
                 new SqlParameter("@CreatedBy",CreatedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveHistoryAndRecordMaster", para);
            return ds;
        }
        public DataSet GetHistoryAndRecordListMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@HistoryAndRecord",HistoryAndRecord),
            };
            DataSet ds = Connection.ExecuteQuery("GetHistoryAndRecordListMaster", para);
            return ds;
        }
        public DataSet UpdateHistoryAndRecordMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@Id",Id),
                new SqlParameter("@HistoryAndRecord",HistoryAndRecord)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateHistoryAndRecordMaster", para);
            return ds;
        }
        public DataSet DeleteHistoryAndRecordMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteHistoryAndRecordMaster", para);
            return ds;
        }

        public DataSet SaveInspectionMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@InspectionName",InspectionName),
                 new SqlParameter("@CreatedBy",CreatedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveInspectionMaster", para);
            return ds;
        }
        public DataSet GetInspectionListMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@InspectionName",InspectionName),
            };
            DataSet ds = Connection.ExecuteQuery("GetInspectionListMaster", para);
            return ds;
        }

        public DataSet UpdateInspectionMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@Id",Id),
                new SqlParameter("@InspectionName",InspectionName)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateInspectionMaster", para);
            return ds;
        }


        public DataSet DeleteInspectionMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteInspectionMaster", para);
            return ds;
        }



        public DataSet SavePowerTrainMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@PowerTrain",PowerTrain),
                 new SqlParameter("@CreatedBy",CreatedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SavePowerTrainMaster", para);
            return ds;
        }

        public DataSet GetPowerTrainListMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@PowerTrain",PowerTrain),
            };
            DataSet ds = Connection.ExecuteQuery("GetPowerTrainListMaster", para);
            return ds;
        }

        public DataSet UpdatePowerTrainMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@Id",Id),
                new SqlParameter("@PowerTrain",PowerTrain)
            };
            DataSet ds = Connection.ExecuteQuery("UpdatePowerTrainMaster", para);
            return ds;
        }

        public DataSet DeletePowerTrainMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id)
            };
            DataSet ds = Connection.ExecuteQuery("DeletePowerTrainMaster", para);
            return ds;
        }

        public DataSet SaveProductionYearMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@ProductionYear",ProductionYear),
                 new SqlParameter("@CreatedBy",CreatedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveProductionYearMaster", para);
            return ds;
        }

        public DataSet GetProductionYearListMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@ProductionYear",ProductionYear),
            };
            DataSet ds = Connection.ExecuteQuery("GetProductionYearListMaster", para);
            return ds;
        }

        public DataSet UpdateProductionYearMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@Id",Id),
                new SqlParameter("@ProductionYear",ProductionYear)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateProductionYearMaster", para);
            return ds;
        }

        public DataSet DeleteProductionYearMaster()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Id",Id)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteProductionYearMaster", para);
            return ds;
        }





    }
}