﻿using BEDA.CMB.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BEDA.CMB.Contracts.Requests
{
    /// <summary>
    /// 7.3.查询委托贷款可用额度列表请求主体
    /// </summary>
    [XmlRoot("CMBSDKPGK")]
    public class RQ7_3 : CMBBase<RQINFO>, IRequest<RS7_3>
    {
        /// <summary>
        /// NTNETDZC
        /// </summary>
        /// <returns></returns>
        public override string GetFUNNAM() => "NTNETDZC";
        /// <summary>
        /// 7.3.查询委托贷款可用额度列表请求内容
        /// </summary>
        public NTNETDZCY1 NTNETDZCY1 { get; set; }
    }
    /// <summary>
    /// 7.3.查询委托贷款可用额度列表请求内容
    /// </summary>
    public class NTNETDZCY1
    {
        /// <summary>
        /// 调用公式	C(4)
        /// </summary>
        public string FMLTRF { get; set; }
        /// <summary>
        /// 客户编号	C(10)
        /// </summary>
        public string CLTCOD { get; set; }
        /// <summary>
        /// 产品类别	C(4) 附录A.49信用管理产品类别
        /// </summary>
        public string BUSTYP { get; set; }
        /// <summary>
        /// 相关客户编号	C(10)	调用GetALContract返回的CLTNBR    借款方帐户对应客户编号
        /// </summary>
        public string RELCLT { get; set; }
        /// <summary>
        /// 进帐机构	C(6)	调用NTQALCTL返回的RSV30Z 委托方进账部门
        /// </summary>
        public string ACCBRN { get; set; }

        /// <summary>
        /// 分行号	C(3)	附录A.48招行3位分行
        /// </summary>
        public string BBKNUM { get; set; }
        /// <summary>
        /// 机构号	C(6)
        /// </summary>
        public string BRNNUM { get; set; }
        /// <summary>
        /// 币种	C(2)	附录A.3 币种
        /// </summary>
        public string CRYNUM { get; set; }
        /// <summary>
        /// 授信开关	C(1)
        /// </summary>
        public string CRDYON { get; set; }
        /// <summary>
        /// 进帐分行	C(3)	附录A.48招行3位分行
        /// </summary>
        public string ACCBBK { get; set; }
    }
}
