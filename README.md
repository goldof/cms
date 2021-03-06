SiteServer CMS
=============

SiteServer CMS 是.NET平台CMS系统的创始者，能够以最低的成本、最少的人力投入在最短的时间内架设一个功能齐全、性能优异、规模庞大并易于维护的网站平台。

![SiteServer CMS](http://www.siteserver.cn/assets/github-banner.png)

<a href="http://developer.siteserver.cn/" target="_blank">开发者中心</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="http://stl.siteserver.cn/"  target="_blank">STL 语言</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="http://docs.siteserver.cn/"  target="_blank">文 档</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="http://blog.siteserver.cn/"  target="_blank">博 客</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="http://bbs.siteserver.cn/"  target="_blank">论 坛</a>

## SiteServer CMS 源码结构

```
│  siteserver.sln                 Visual Studio 项目文件
│
├─BaiRong.Core                    基础类库
├─SiteServer.BackgroundPages      ASP.NET 页面源文件
├─SiteServer.CMS                  CMS 源文件
├─SiteServer.Plugin               插件源文件
├─SiteServer.Web                  API 源文件及aspx页面
├─siteserver                      SiteServer 控制台程序
└─ref                             引用第三方DLL
```

## 2018产品开发路线图

2018年，SiteServer CMS 产品将在每个月底发布新的稳定版本，我们将在每次迭代中对核心功能、文档支持、功能插件以及网站模板四个方面进行持续改进，详情请参考 [路线图](https://github.com/siteserver/cms/wiki/%E8%B7%AF%E7%BA%BF%E5%9B%BE)。

## Feedback

提交反馈意见请使用Github [Issues](https://github.com/siteserver/cms/issues) 功能。

## License

[GNU GENERAL PUBLIC LICENSE 3.0](LICENSE)

Copyright (C) 2003-2017 北京百容千域软件技术开发有限公司

## Status

项目正式发布的稳定版本存放在 `master` 分支，当前的开发版本存放在 `dev` 分支

分支  | AppVeyor
------  | ------
master | [![Build status](https://ci.appveyor.com/api/projects/status/plx37i94y9gsqkru/branch/master?svg=true)](https://ci.appveyor.com/project/starlying/cms/branch/master)
dev | [![Build status](https://ci.appveyor.com/api/projects/status/plx37i94y9gsqkru/branch/dev?svg=true)](https://ci.appveyor.com/project/starlying/cms/branch/dev)