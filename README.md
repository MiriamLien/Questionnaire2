## Questionnaire2 動態問卷(管理)系統
#### 基本功能
- 前台可以填寫、搜尋問卷以及觀看統計數據
- 登入後台後可以設計、管理問卷(編輯和刪除)以及觀看統計數據
- 後台可以觀看所有使用者作答的詳細內容，並匯出成表單(CSV檔)
- 後台可以設計、管理常用問題(編輯和刪除)，並套用至設計問題內
<br />

#### 資料庫(MSSQL)
- 結構與描述 `結構.sql`
- 資料 `資料.sql`
- 備份 `Questionnaire.bak`
<br />

#### 環境依賴
ASP.NET Framwork 4.7.2
<br />
<br />

#### 起始頁面
`listPage.aspx`
<br />
<br />

#### 目錄結構描述
前台
>`Index.Master` 前台主版
>
>`listPage.aspx` 問卷列表頁面
>
>`mainPage.aspx` 填寫問卷頁面
>
>`checkPage.aspx` 確認填寫內容頁面
>
>`statisticPage.aspx` 統計頁面
>
>`Login.aspx` (前往後台)登入頁面
<br />

後台 BackAdmin <br />
>`Admin.Master` 後台主版
>
>`listPageA.aspx` 問卷管理列表頁面
>
>`mainPageA_Add.aspx` 新增問卷、問題頁面
>
>`mainPageA.aspx` 編輯問卷、問題以及觀看填寫詳細內容和統計頁面
>
>`CommonQuesPageA.aspx` 常用問題管理頁面
<br />

Models
>`AccountModel.cs` 帳號Model
>
>`QuesContentsModel.cs` 問卷Model
>
>`QuesDetailModel.cs` 問題Model
>
>`QuesTypeModel.cs` 問題種類Model
>
>`QuesAndTypeModel.cs` 問題(含問題種類)Model
>
>`UserInfoModel.cs` 填寫個人資訊Model
>
>`UserQuesDetailModel.cs` 填寫答案資訊Model
>
>`UserInfoAndQuesModel.cs` 個人資訊及問題答案Model
>
>`StatisticModel.cs` 統計Model
>
>`CQModel.cs` 常用問題Model
>
>`CQAndTypeModel.cs` 常用問題(含問題種類)Model
<br />

Managers (與資料庫溝通的方法)
>`AccountManager.cs` 帳號管理
>
>`QuesContentsManager.cs` 問卷管理
>
>`QuesDetailManager.cs` 問題管理
>
>`QuesTypeManager.cs` 問題種類管理
>
>`UserInfoManager.cs` 填寫個人資訊管理
>
>`UserQuesDetailManager.cs` 填寫答案管理
>
>`StatisticManager.cs` 統計管理
>
>`CQManager.cs` 常用問題管理
<br />

Helpers
>`Logger.cs` 記錄錯誤訊息
<br />

#### 後台登入帳密
- 帳號: Admin
- 密碼: 12345678
