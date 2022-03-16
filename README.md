# SupermarketManagement
.NET5.0 Blazor + EF 实现超市商品管理系统
-主要分以下三个模块
  --类别管理
  --商品管理
  --交易记录查询
![image](https://user-images.githubusercontent.com/49175954/158535345-370ec11e-646a-47b5-a1a3-2de061e89139.png)

-登录注册使用已搭建基架项目中的标识，访问权限分admin和cashier
注册流程
--先注册
--去数据库WebApp_Accounts中的dbo.AspneUser拿当前新账号id
--去dbo.AspneUserClaims里加上包含上述id的新行，ClaimType填Position，ClaimValue填Admin/Cashier
--ClaimValue的值不同对应访问页面的权限也不同
