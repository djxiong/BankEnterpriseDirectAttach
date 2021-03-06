﻿using BEDA.CIB.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BEDA.CIB.Contracts.Requests
{
    /// <summary>
    /// 3.4.6批量托收、批量子账户托收请求主体
    /// </summary>
    public class V1_FBBATCHGATHERTRNRQ : IRequest<V1_FBBATCHGATHERTRNRS>
    {
        /// <summary>
        /// 3.4.6批量托收、批量子账户托收
        /// </summary>
        public FBBATCHGATHERTRNRQ FBBATCHGATHERTRNRQ { get; set; }
    }
    /// <summary>
    /// 3.4.6批量托收、批量子账户托收
    /// </summary>
    public class FBBATCHGATHERTRNRQ : BIZRQBASE
    {
        /// <summary>
        /// 3.4.6托收请求
        /// </summary>
        [XmlElement(Order = 1)]
        public FBBATCHGATHERTRN_RQBODY RQBODY { get; set; }
    }
    /// <summary>
    /// 3.4.6托收请求
    /// </summary>
    public class FBBATCHGATHERTRN_RQBODY
    {
        /// <summary>
        /// 收款账户(兴业银行账户)，32位
        /// 子账户托收输入22位或24位子账户 必输
        /// </summary>
        [XmlElement(Order = 0)]
        public string ACCTID { get; set; }
        /// <summary>
        /// 单位编码， 4位	必输
        /// </summary>
        [XmlElement(Order = 1)]
        public string FIRMCODE { get; set; }
        /// <summary>
        /// 业务编码，5位<see cref="GATHERRQINFO.BIZCODE"/> 必输
        /// </summary>
        [XmlElement(Order = 2)]
        public string BIZCODE { get; set; }
        /// <summary>
        /// 托收摘要代号 非必输 <see cref="GATHERRQINFO.SUMM"/>
        /// </summary>
        [XmlElement(Order = 3)]
        public string SUMM { get; set; }
        /// <summary>
        /// 回款期限:1/2/3天 默认为3天
        /// </summary>
        [XmlElement(Order = 4)]
        public int LIMITDAYS { get; set; } = 3;
        /// <summary>
        /// 标题，最大30位
        /// </summary>
        [XmlElement(Order = 5)]
        public string TITLE { get; set; }
        /// <summary>
        /// 托收备注，最大50位
        /// </summary>
        [XmlElement(Order = 6)]
        public string MEMO { get; set; }
        /// <summary>
        /// 交易类型（借0/贷1），可不填。默认为收款（贷），即托收时赋值1。
        /// </summary>
        [XmlElement(Order = 7)]
        public int TRNTYPE { get; set; } = 1;
        /// <summary>
        /// 凭证号，7位数字；可不填，默认使用电子凭证号。	非必输
        /// </summary>
        [XmlElement(Order = 8)]
        public string CHEQUENUM { get; set; }
        /// <summary>
        /// 批次用途，最大30位	非必输
        /// </summary>
        [XmlElement(Order = 9)]
        public string USE { get; set; }
        /// <summary>
        /// 批量托收付款信息集合
        /// </summary>
        [XmlElement("GATHERINFO", Order = 10)]
        public List<FBBATCHGATHER_PAYINFO> GATHERINFO { get; set; }
    }
    /// <summary>
    /// 批量托收付款信息
    /// <see cref="RQPAYINFO.BIZCODE0"/>和<see cref="RQPAYINFO.BIZCODE1"/>为必输
    /// 另外<see cref="RQPAYINFO.BIZCODE2"/>此处业务中不存在，所以切记勿要输入
    /// </summary>
    public class FBBATCHGATHER_PAYINFO : RQPAYINFO
    {
        /// <summary>
        /// 托收备注，最大60位	必输
        /// </summary>
        [XmlElement(Order = 9)]
        public string MEMO { get; set; }
    }
}
