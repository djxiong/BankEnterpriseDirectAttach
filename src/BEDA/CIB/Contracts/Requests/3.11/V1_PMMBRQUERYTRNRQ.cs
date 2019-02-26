﻿using BEDA.CIB.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BEDA.CIB.Contracts.Requests
{
    /// <summary>
    /// 3.11.1.4贵金属交易会员信息查询请求主体
    /// </summary>
    public class V1_PMMBRQUERYTRNRQ : IRequest<V1_PMMBRQUERYTRNRS>
    {
        /// <summary>
        /// 3.11.1.4贵金属交易会员信息查询请求主体
        /// </summary>
        public PMMBRQUERYTRNRQ PMMBRQUERYTRNRQ { get; set; }
    }
    /// <summary>
    /// 3.11.1.4贵金属交易会员信息查询请求主体
    /// </summary>
    public class PMMBRQUERYTRNRQ : BIZRQBASE
    {
        /// <summary>
        /// 3.11.1.4贵金属交易会员信息查询请求内容
        /// </summary>
        [XmlElement(Order = 2)]
        public PAGED_RQACCT RQBODY { get; set; }
    }
}
