using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.COL;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class ICompany
    {
        public string Name { set; get; }
        public string Address { set; get; }
        public string LandlinePhoneNumber { set; get; }
        public string ElectricalPanelLocation { set; get; }
        public string OxygenTrapLocation { set; get; }
        public string GasTrapLocation { set; get; }
        public string RightCompanyName { set; get; }
        public string RightCompanyBusiness { set; get; }
        public string LeftCompanyName { set; get; }
        public string LeftCompanyBusiness { set; get; }
        public string FrontCompanyName { set; get; }
        public string FrontCompanyBusiness { set; get; }
        public int CompanyID { get; set; }
        public string BackCompanyName { set; get; }
        public string BackCompanyBusiness { set; get; }
        public string FrontFireMediator { set; get; }
        public string LeftFireMediator { set; get; }
        public string BackFireMediator { set; get; }
        public string RightFireMediator { set; get; }
        public int BuildingsNumber { set; get; }
        public byte[] FrontCompanyImage { set; get; }
        public byte[] BackCompanyImage { set; get; }
        public byte[] RightCompanyImage { set; get; }
        public byte[] LeftCompanyImage { set; get; }
        public int UserID { get; set; }
        public string FrontCompanyImageURL { set; get; }
        public string BackCompanyImageURL { set; get; }
        public string RightCompanyImageURL { set; get; }
        public string LeftCompanyImageURL { set; get; }
        public float Latitude { set; get; }
        public float Longitude { set; get; }
        public string CompanyBuisiness { set; get; }
        public float StockVolume {set;get;}
        public string StockType { set; get; }
        public byte[] CompanyImage { set; get; }
        public byte[] CompanyGeometeryImage { set; get; }
        public BuildingsCollection companyBuildings { set; get; }
        public ManagersCollection companyManagers { set; get; }
        public DangerousPlacesCollection CompanyDangerousPlaces { get; set; }
        public AccidentCollection CompanyAccident { get; set; }
        public string ISSI { get; set; }
        public string sector { get; set; }
        public string Info { get; set; }
    }
}