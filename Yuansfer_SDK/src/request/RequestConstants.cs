using System;
using System.Collections.Generic;
using System.Text;

/**
 *  Constant Request Variable
 **/ 
namespace Yuansfer_SDK.src.request
{
    public static class RequestConstants
    {
        /*
	     * Gateway
	     */
        public const string SANDBOX_PREFIX = "https://mapi.yuansfer.yunkeguan.com";
        public const string PRODUCT_PREFIX = "https://mapi.yuansfer.com";

        /*
         * online api suffix
         */
        public const string ONLINE_SECUREPAY = "/online/v3/secure-pay";
        public const string UPDATE_RECURRING = "/creditpay/v3/update-recurring";
        public const string RECURRING_APPLYTOKEN = "/auto-debit/v3/apply-token";
        public const string RECURRING_CONSULT = "/auto-debit/v3/consult";
        public const string RECURRING_PAY = "/auto-debit/v3/pay";
        public const string RECURRING_REVOKE = "/auto-debit/v3/revoke";
        public const string BRAIN_PAYMENT = "/creditpay/v3/process";

        /*
         * instore api suffix
         */
        public const string INSTORE_ADD = "/app-instore/v3/add";
        public const string INSTORE_PAY = "/app-instore/v3/pay";
        public const string INSTORE_TRAN_QRCODE = "/app-instore/v3/create-trans-qrcode";
        public const string INSTORE_CASHIER_ADD = "/app-instore/v3/cashier-add";
        public const string INSTORE_AUTH_CAPTURE = "/app-instore/v3/auth-capture";
        public const string INSTORE_AUTH_UNFREEZE = "/app-instore/v3/auth-unfreeze";

        /*
         * payout api suffix
         */
        public const string PAYOUT_PAY = "/v3/payouts/pay";
        public const string PAYOUT_CREATE_ACCOUNT = "/v1/customers/account/create";

        /*
         * payout api suffix
         */
        public const string CUSTOMER_CREATE_ACCOUNT = "/v1/customers/create";
        public const string CUSTOMER_RETRIEVE_ACCOUNT = "/v1/customers/retrieve";
        public const string CUSTOMER_UPDATE_ACCOUNT = "/v1/customers/update";

        /*
         * mobile api suffix
         */
        public const string MOBILE_PREPAY = "/micropay/v3/prepay";
        public const string EXPRESS_PAY = "/micropay/v3/express-pay";

        /*
         * data-search
         */
        public const string REFUND = "/app-data-search/v3/refund";
        public const string REVERSE = "/app-data-search/v3/cancel";
        public const string TRAN_QUERY = "/app-data-search/v3/tran-query";
        public const string TRANS_LIST = "/app-data-search/v3/trans-list";
        public const string SETTLE_LIST = "/app-data-search/v3/settle-list";
        public const string WITHDRAWAL_LIST = "/app-data-search/v3/withdrawal-list";
        public const string DATA_STATUS = "/app-data-search/v3/data-status";

        /*
         * Pre auth
         */
        public const string AUTH_VOUCHER_CREATE = "/app-auth/v3/voucher-create";
        public const string AUTH_FREEAE = "/app-auth/v3/auth-freeze";
        public const string AUTH_UNFREEZE = "/app-auth/v3/auth-unfreeze";
        public const string AUTH_CAPTURE = "/app-auth/v3/auth-capture";
        public const string AUTH_DETAIL_QUERY = "/app-auth/v3/auth-detail-query";

        /*
         * Third party auth
         */
        public const string THIRDPART_ACQUIRE_CREATE = "/app-thirdpart/v3/acquire-create";
    }
}
