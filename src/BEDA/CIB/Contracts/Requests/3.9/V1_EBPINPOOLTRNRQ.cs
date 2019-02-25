﻿using BEDA.CIB.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BEDA.CIB.Contracts.Requests
{
    /// <summary>
    /// 3.9.3.1电子商业汇票票据入池请求主体
    /// </summary>
    public class V1_EBPINPOOLTRNRQ : IRequest<V1_EBPINPOOLTRNRS>
    {
        /// <summary>
        /// 3.9.3.1电子商业汇票票据入池请求主体
        /// </summary>
        public EBPINPOOLTRNRQ EBPINPOOLTRNRQ { get; set; }
    }
    /// <summary>
    /// 3.9.3.1电子商业汇票票据入池请求主体
    /// </summary>
    public class EBPINPOOLTRNRQ : BIZRQBASE
    {
        /// <summary>
        /// 3.9.3.1电子商业汇票票据入池请求内容
        /// </summary>
        [XmlElement(Order = 2)]
        public EBPINPOOLTRN_RQBODY RQBODY { get; set; }
    }
    /// <summary>
    /// 3.9.3.1电子商业汇票票据入池请求内容
    /// </summary>
    public class EBPINPOOLTRN_RQBODY
    {
        /// <summary>
        /// 入池方式 ：01-托管入池 02-质押入池	必输
        /// </summary>
        [XmlElement(Order = 2)]
        public string INPOOLTYPE { get; set; }
        /// <summary>
        /// 票据总笔数,8位整数	必输
        /// </summary>
        [XmlElement(Order = 3)]
        public int TOTALCOUNT
        {
            get
            {
                return this.List?.Count ?? 0;
            }
            set { }
        }
        /// <summary>
        /// 票据总金额, 17位(15整数位,2小数位) 	必输
        /// </summary>
        [XmlElement(Order = 4)]
        public decimal TOTALAMT
        {
            get
            {
                return this.List?.Sum(c => c.BILLAMT) ?? 0;
            }
            set { }
        }
        /// <summary>
        /// 3.9.3.1电子商业汇票票据入池请求集合
        /// </summary>
        [XmlElement("CONTENT", Order = 30)]
        public List<EBPINPOOLTRN_CONTENT> List { get; set; }
    }
    /// <summary>
    /// 3.9.3.1电子商业汇票票据入池请求明细
    /// </summary>
    public class EBPINPOOLTRN_CONTENT
    {
        /// <summary>
        /// 小序号,4位	必输
        /// </summary>
        [XmlElement(Order = 0)]
        public int INDX { get; set; }
        /// <summary>
        /// 票据号码,30位	必输
        /// </summary>
        [XmlElement(Order = 1)]
        public string BILLCODE { get; set; }
        /// <summary>
        /// 票据金额,17位(15整数位,2小数位)	必输
        /// </summary>
        [XmlElement(Order = 2)]
        public decimal BILLAMT { get; set; }
        /// <summary>
        /// 票据类型，AC01银承 AC02商承	必输
        /// </summary>
        [XmlElement(Order = 3)]
        public string BILLTYPE { get; set; }
        /// <summary>
        /// 出票日期 YYYY-MM-DD 必输
        /// </summary>
        [XmlIgnore]
        public DateTime OUTDATE { get; set; }
        /// <summary>
        /// 出票日期 YYYY-MM-DD, 对应<see cref="OUTDATE"/> 必输
        /// </summary>
        [XmlElement("OUTDATE", Order = 4)]
        public string OUTDATEStr
        {
            get
            {
                return this.OUTDATE.ToString("yyyy-MM-dd");
            }
            set
            {
                if (DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime tmp))
                {
                    this.OUTDATE = tmp;
                }
            }
        }
        /// <summary>
        /// 出票截止日期 YYYY-MM-DD 必输
        /// </summary>
        [XmlIgnore]
        public DateTime DUEDATE { get; set; }
        /// <summary>
        /// 出票截止日期 YYYY-MM-DD, 对应<see cref="DUEDATE"/> 必输
        /// </summary>
        [XmlElement("DUEDATE", Order = 5)]
        public string DUEDATEStr
        {
            get
            {
                return this.DUEDATE.ToString("yyyy-MM-dd");
            }
            set
            {
                if (DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime tmp))
                {
                    this.DUEDATE = tmp;
                }
            }
        }
        /// <summary>
        /// 出票人全称，商承纸票时指付款人名称	必输
        /// </summary>
        [XmlElement(Order = 6)]
        public string DRAWERNAME { get; set; }
        /// <summary>
        /// 出票人账号，商承纸票时指付款人账号	必输
        /// </summary>
        [XmlElement(Order = 7)]
        public string DRAWERACCTNO { get; set; }
        /// <summary>
        /// 付款行名称，商承时指付款人开户行名称	必输
        /// </summary>
        [XmlElement(Order = 8)]
        public string DRAWERBANKNAME { get; set; }
        /// <summary>
        /// 付款行行号	必输
        /// </summary>
        [XmlElement(Order = 9)]
        public string DRAWERBANKCODE { get; set; }
        /// <summary>
        /// 收款人名称	必输
        /// </summary>
        [XmlElement(Order = 10)]
        public string PAYEENAME { get; set; }
        /// <summary>
        /// 收款人账号	非必输
        /// </summary>
        [XmlElement(Order = 11)]
        public string PAYEEACCTNO { get; set; }
        /// <summary>
        /// 收款人开户行名称	非必输
        /// </summary>
        [XmlElement(Order = 12)]
        public string PAYEEBANKNAME { get; set; }
        /// <summary>
        /// 收款人开户行行号，收款人开户行名称不为空时必输	非必输
        /// </summary>
        [XmlElement(Order = 13)]
        public string PAYEEBANKCODE { get; set; }
        /// <summary>
        /// 前一手背书人	非必输
        /// </summary>
        [XmlElement(Order = 14)]
        public string PREINDORSER { get; set; }
    }
}