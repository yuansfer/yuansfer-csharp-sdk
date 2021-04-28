# Yuansfer C# SDK

[Yuansfer API](https://docs.yuansfer.com/)


## Requirements

- .NET Core >=2.0 or .NET Standard >=2.0

## IDE

- Microsoft Visual Studio 2017

## Installation
Package Manager Console command
``` Nuget Package Manager
PM > Install-Package yuansfer-payment -Version 1.0.2
```
Or Visual Studio
``` Visual Studio:
1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on Manage NuGet Packages...
4. Click on the Browse tab and search for "yuansfer-payment".
5. Click on the yuansfer-payment package, select the appropriate version in the right-tab and click Install.
```

## Usage

Please see [examples](https://github.com/yuansfer/yuansfer-csharp-sdk/tree/master/Test/tests)

### 1. Init
```c#
YuanpayConfig config = new YuanpayConfig(); //Initialize Yuansfer Configuration
config.env = EnvironmentEnums.SANDBOX.Value; //Set Yuansfer to SandBox Environment, Possible Value: SANDBOX, PRODUCTION
config.merchantNo = "200043"; //Set Yuansfer MerchantNo
config.storeNo = "300014"; //Set Yuansfer StoreNo
config.token = "5cbfb079f15b150122261c8537086d77a"; //Set Yuansfer Token

YuanpayClient client = new YuanpayV3Client(config); //Initialize Yuansfer Client with above configuration              
```



### 2. Online API
```c#
JArray goods = new JArray();
JObject item = new JObject();
item.Add("goods_name","name1");
item.Add("quantity","1");
goods.Add(item); //Add product items to JSON Object with above format
OnlineSecurepayRequest request = new OnlineSecurepayRequest(); //Initialize Yuansfer SecurePay request object
/**
* Assign required values to request body
**/
request.amount = "1.00";
request.currency = "USD";
request.settleCurrency = "USD";
request.vendor = "alipay";
request.terminal = "ONLINE";
request.reference = DateTime.Now.ToString();
request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";
request.description = "testDescription";
request.note = "testNote";
item.Add("goods_name","name1");
item.Add("quantity", "1");
goods.Add(item);
request.goodsInfo = goods.ToString(); //Convert JSON object into JSON string

OnlineSecurepayResponse response = client.execute(request); //Make SecurePay request with above request body
Console.Write(JObject.FromObject(response)); //Debug purpose
```

### 3. Offline API
```c#
InstoreCreateTranQrcodeRequest request = new InstoreCreateTranQrcodeRequest(); //Initialize Yuansfer Instore Create Tran Qr Code request object
/**
* Assign required values to request body
**/
request.amount = "1.11";
request.currency = "USD";
request.settleCurrency = "USD";
request.vendor = "alipay";
request.reference = DateTime.Now.ToString();
request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";
request.needQrcode = "true";
request.timeout = 120;

InstoreCreateTranQrcodeResponse response = client.execute(request); //Make Instore Create Tran Qr Code request with above request body
Console.Write(JObject.FromObject(response)); //Debug purpose
```

### 4. Mobile API
```c#
MobilePrepayRequest request = new MobilePrepayRequest(); //Initialize Yuansfer Mobile PrePay request object
/**
* Assign required values to request body
**/
request.amount = "0.11";
request.currency = "USD";
request.settleCurrency = "USD";
request.vendor = "alipay";
request.terminal = "APP";
request.reference = DateTime.Now.ToString();
request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";
request.description = "Test for description";
request.note = "Test for note";

MobilePrepayResponse response = client.execute(request); //Make Mobile PrePay request with above request body
Console.Write(JObject.FromObject(response)); //Debug purpose
```

### 5. Data API
```c#
RefundRequest request = new RefundRequest(); //Initialize Yuansfer Refund request object
/**
* Assign required values to request body
**/
request.refundAmount = "1.11";
request.currency = "USD";
request.settleCurrency = "USD";
request.reference = DateTime.Now.ToString();
        
RefundResponse response = client.execute(request); //Make Refund request with above request body
Console.Write(JObject.FromObject(response)); //Debug purpose
```
