USE [Questionnaire]
GO
INSERT [dbo].[Accounts] ([AccountID], [Account], [PWD], [UserLevel], [IsEnable], [CreateDate]) VALUES (N'9dd376d3-2fa0-4e45-b64d-957f59b55bf1', N'aaa', N'aaa', 1, 1, CAST(N'2022-04-12T02:11:46.310' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [Account], [PWD], [UserLevel], [IsEnable], [CreateDate]) VALUES (N'40fef38c-1db0-4b86-900b-bcbdeb7c7d9b', N'Admin', N'12345678', 10, 1, CAST(N'2022-04-12T02:05:56.523' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Contents] ON 

INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'cbb9b6e2-f03e-4913-ba55-5c4c288db90c', 1, N'動漫角色人氣票選', N'人氣票選來囉！紅遍全世界的的鬼滅、航海王以及多啦A夢裡，你最喜歡的角色是？', CAST(N'2022-04-15T00:00:00.000' AS DateTime), CAST(N'2022-04-30T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'ead61633-c431-4e59-8c27-99cba1ac3fe0', 3, N'最靈驗的心理測驗在這裡！', N'在一座巨大的公園內，與三種動物不期而遇的你會選擇哪一種呢? 以及在這樣的環境下，有著些那些色彩映入眼簾?', CAST(N'2022-01-11T00:00:00.000' AS DateTime), CAST(N'2022-02-22T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'35a770f0-a4de-4908-832e-a3dd1079e939', 5, N'校園菁英選拔賽', N'一邊是各個可愛小巧的美少女們，一邊是愛撒嬌的貓貓，另一邊是各國聯軍環肥燕瘦的帥哥哥們，究竟誰能擄獲大眾的心呢！讓我們好好期待！', CAST(N'2022-04-16T00:00:00.000' AS DateTime), CAST(N'2022-05-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'f8b835d2-2026-449f-ac74-eac3bd9104e7', 2, N'飲品聯合國 - 購買傾向大調查', N'聊天、小憩的好去處，你最常在時尚的咖啡廳、健康無負擔的果汁店以及大人專屬的夜生活酒吧購買哪樣飲品呢?', CAST(N'2022-05-05T00:00:00.000' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Contents] OFF
GO
SET IDENTITY_INSERT [dbo].[QuesTypes] ON 

INSERT [dbo].[QuesTypes] ([QuesTypeID], [QuesType]) VALUES (1, N'文字')
INSERT [dbo].[QuesTypes] ([QuesTypeID], [QuesType]) VALUES (2, N'單選方塊')
INSERT [dbo].[QuesTypes] ([QuesTypeID], [QuesType]) VALUES (3, N'複選方塊')
SET IDENTITY_INSERT [dbo].[QuesTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[QuesDetails] ON 

INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (2, N'cbb9b6e2-f03e-4913-ba55-5c4c288db90c', N'世界風靡的鬼滅中，你最喜歡的角色是？', N'', 1, 1)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (4, N'cbb9b6e2-f03e-4913-ba55-5c4c288db90c', N'<航海王>裡面你最喜歡的角色是?', N'', 1, 1)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (5, N'cbb9b6e2-f03e-4913-ba55-5c4c288db90c', N'歷久不衰的哆啦A夢，主要角色中你最喜歡的是?', N'多拉A夢;大雄;靜香;小夫;胖虎', 2, 1)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (8, N'f8b835d2-2026-449f-ac74-eac3bd9104e7', N'最常在星巴克購買的飲品是?', N'咖啡;星冰樂;茶;果汁', 2, 0)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (9, N'f8b835d2-2026-449f-ac74-eac3bd9104e7', N'酒鋪推廣中，喜歡哪種類型的酒呢? (可複選)', N'清酒;啤酒;葡萄酒;白酒;郎姆酒;白蘭地;威士忌;伏特加', 3, 1)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (13, N'f8b835d2-2026-449f-ac74-eac3bd9104e7', N'日本知名的青森蘋果，你喜歡哪些種類呢? (可複選)', N'王林;富士;金星;世界一;信濃金;陸奧', 3, 1)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (16, N'ead61633-c431-4e59-8c27-99cba1ac3fe0', N'以下三種動物，你最喜歡哪一種?', N'狗狗;貓咪;兔子', 2, 0)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (17, N'ead61633-c431-4e59-8c27-99cba1ac3fe0', N'喜歡的顏色有哪些? (可複選)', N'藍色;紅色;綠色;黃色;紫色;粉色;橘色;黑色;白色', 3, 1)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (21, N'ead61633-c431-4e59-8c27-99cba1ac3fe0', N'最喜歡在公園玩的遊樂器材是?', N'', 1, 1)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (22, N'35a770f0-a4de-4908-832e-a3dd1079e939', N'投給你心目中的女神！', N'Flora;Sandra;Momo;Aoi,Nina;Kiki', 2, 1)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (23, N'35a770f0-a4de-4908-832e-a3dd1079e939', N'貓咖最暖喵店員', N'', 1, 1)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable]) VALUES (24, N'35a770f0-a4de-4908-832e-a3dd1079e939', N'校園十大帥哥讓你挑！(一人兩票)', N'Rin;Sam;Ryo;Tim;William;Yuka;George;Leo;Kent;Jun', 3, 1)
SET IDENTITY_INSERT [dbo].[QuesDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[CommonQues] ON 

INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (1, N'<海賊王>裡面你最喜歡的角色是?', 1, NULL, 1)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (2, N'以下三種動物，你最喜歡?', 2, N'狗狗;貓咪;兔子', 0)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (3, N'喜歡的顏色有哪些? (可複選)', 3, N'藍色;紅色;綠色;黃色;紫色', 1)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (4, N'世界風靡的鬼滅裡，你最喜歡的角色是？', 1, NULL, 1)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (5, N'最常在星巴克購買的飲品是?', 2, N'咖啡;星冰樂;茶;果汁', 0)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (6, N'日本知名的青森蘋果釀出來的果汁，你喜歡哪種呢? (可複選)', 3, N'王林;富士;金星;世界一;信濃金;陸奧', 1)
SET IDENTITY_INSERT [dbo].[CommonQues] OFF
GO
