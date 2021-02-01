using System;
using System.Collections.Generic;
using System.Text;

/**
 *  Vendor Enum 
 **/
namespace Yuansfer_SDK.src.enums
{
    public class VendorEnums
    {
        public static readonly VendorEnums ALIPAY = new VendorEnums("alipay"); //Vendor: Alipay
        public static readonly VendorEnums WECHATPAY = new VendorEnums("wechatpay"); //Vendor: Wechat Pay
        public static readonly VendorEnums UNIONPAY = new VendorEnums("unionpay"); //Vendor: Union Pay
        public static readonly VendorEnums CREDITCARD = new VendorEnums("creditcard"); //Vendor: Credit Card
        public static readonly VendorEnums VENMO = new VendorEnums("venmo"); //Vendor: Venmo
        public static readonly VendorEnums PAYPAL = new VendorEnums("paypal"); //Vendor: Paypal Pay
        public static readonly VendorEnums TRUEMONEY = new VendorEnums("truemoney"); //Vendor: True Money
        public static readonly VendorEnums ALIPAY_HK = new VendorEnums("alipay_hk"); //Vendor: Alipay HongKong
        public static readonly VendorEnums TNG = new VendorEnums("tng"); //Vendor: Tng
        public static readonly VendorEnums ALIPAY_CN = new VendorEnums("alipay_cn"); //Vendor: Alipay China
        public static readonly VendorEnums GCASH = new VendorEnums("gcash"); //Vendor: GCash
        public static readonly VendorEnums DANA = new VendorEnums("dana"); //Vendor: Dana
        public static readonly VendorEnums KAKAOPAY = new VendorEnums("kakaopay"); //Vendor: KaKao Pay
        public static readonly VendorEnums BKASH = new VendorEnums("bkash"); //Vendor: BKash
        public static readonly VendorEnums EASYPAISA = new VendorEnums("easypaisa"); //Vendor: Easypaisa

        public static IEnumerable<VendorEnums> Values
        {
            get
            {
                yield return ALIPAY;
                yield return WECHATPAY;
                yield return UNIONPAY;
                yield return CREDITCARD;
                yield return VENMO;
                yield return PAYPAL;
                yield return TRUEMONEY;
                yield return ALIPAY_HK;
                yield return TNG;
                yield return ALIPAY_CN;
                yield return GCASH;
                yield return DANA;
                yield return KAKAOPAY;
                yield return BKASH;
                yield return EASYPAISA;
            }
        }

        //Get and private set method for VendorEnums value;
        public string Value { get; private set; }

        VendorEnums(string value) =>
            (Value) = (value);

        //Validation method to determine if input is valid
        public static bool containValidate(string value)
        {
            bool flag = false;
            foreach (VendorEnums en in VendorEnums.Values)
            {
                if (en.Value.Equals(value))
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }
    }
}
