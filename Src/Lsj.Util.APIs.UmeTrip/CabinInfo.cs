using Lsj.Util.JSON;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.APIs.UmeTrip
{
    public class CabinInfo
    {
        /// <summary>
        /// 舱位代码
        /// </summary>
        [CustomJsonPropertyNameAttribute("pcode")]
        public string CabinCode
        {
            get;
            set;
        }
        /// <summary>
        /// 剩余票量
        /// </summary>
        [CustomJsonPropertyNameAttribute("seatNum")]
        public string SeatNum
        {
            get;
            set;
        }
        /// <summary>
        /// 折扣
        /// </summary>
        [CustomJsonPropertyNameAttribute("discount")]
        public decimal Discount
        {
            get;
            set;
        }
        /// <summary>
        /// 价格
        /// </summary>
        [CustomJsonPropertyNameAttribute("price")]
        public int Price
        {
            get;
            set;
        }
        /// <summary>
        /// 民航基金
        /// </summary>
        [CustomJsonPropertyNameAttribute("cn")]
        public int CivilAviationDevelopmentFund
        {
            get;
            set;
        }
        /// <summary>
        /// 然后附加费
        /// </summary>
        [CustomJsonPropertyNameAttribute("yq")]
        public int FuelSurcharge
        {
            get;
            set;
        }
        /// <summary>
        /// 总价
        /// </summary>
        public int TotalPrice => Price + CivilAviationDevelopmentFund + FuelSurcharge;
    }
}
