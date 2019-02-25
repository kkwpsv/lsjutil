using Lsj.Util.JSON;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.APIs.UmeTrip
{
    public class FlightInfo
    {
        /// <summary>
        /// 航班号
        /// </summary>
        [CustomJsonPropertyNameAttribute("pflynum")]
        public string FlyNum
        {
            get;
            set;
        }
        /// <summary>
        /// 航空公司
        /// </summary>
        [CustomJsonPropertyNameAttribute("paircorp")]
        public string AirCorp
        {
            get;
            set;
        }
        /// <summary>
        /// 机型
        /// </summary>
        [CustomJsonPropertyNameAttribute("pflytype")]
        public string FlyType
        {
            get;
            set;
        }
        /// <summary>
        /// 起飞时间
        /// </summary>
        [CustomJsonPropertyNameAttribute("pbegtime")]
        public string BegTime
        {
            get;
            set;
        }
        /// <summary>
        /// 到达时间
        /// </summary>
        [CustomJsonPropertyNameAttribute("pendtime")]
        public string EndTime
        {
            get;
            set;
        }
        /// <summary>
        /// 剩余票量
        /// </summary>
        [CustomJsonPropertyNameAttribute("pseatnum")]
        public string SeatNum
        {
            get;
            set;
        }
        /// <summary>
        /// 准点率
        /// </summary>
        [CustomJsonPropertyNameAttribute("ontimeperformance")]
        public string OnTimeRate
        {
            get;
            set;
        }
        /// <summary>
        /// 价格
        /// </summary>
        [CustomJsonPropertyNameAttribute("pprice")]
        public int Price
        {
            get;
            set;
        }
        /// <summary>
        /// 民航基金
        /// </summary>
        [CustomJsonPropertyNameAttribute("pcn")]
        public int CivilAviationDevelopmentFund
        {
            get;
            set;
        }
        /// <summary>
        /// 然后附加费
        /// </summary>
        [CustomJsonPropertyNameAttribute("pyq")]
        public int FuelSurcharge
        {
            get;
            set;
        }
        /// <summary>
        /// 总价
        /// </summary>
        [NotSerialize]
        public int TotalPrice => Price + CivilAviationDevelopmentFund + FuelSurcharge;

        [CustomJsonPropertyNameAttribute("pcabinInfos")]
        public List<CabinInfo> Cabins
        {
            get;
            set;
        }

    }
}
