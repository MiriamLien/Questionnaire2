USE [Questionnaire]
GO
INSERT [dbo].[Accounts] ([AccountID], [Account], [PWD], [UserLevel], [IsEnable], [CreateDate]) VALUES (N'9dd376d3-2fa0-4e45-b64d-957f59b55bf1', N'aaa', N'aaa', 1, 1, CAST(N'2022-04-12T02:11:46.310' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [Account], [PWD], [UserLevel], [IsEnable], [CreateDate]) VALUES (N'40fef38c-1db0-4b86-900b-bcbdeb7c7d9b', N'Admin', N'12345678', 10, 1, CAST(N'2022-04-12T02:05:56.523' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Contents] ON 

INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'241be2a3-bb55-491f-a41c-20f941fd9424', 25, N'zzz', N'zzzzzzzzz', CAST(N'2022-02-06T00:00:00.000' AS DateTime), CAST(N'2022-04-06T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'b6518e87-26a1-4d97-9b25-331e980c0984', 39, N'kk', N'kkkkkk+', CAST(N'2022-05-19T00:00:00.000' AS DateTime), CAST(N'2022-07-02T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'6e082693-705a-46d5-b54e-43e186e8f887', 31, N'「Podcast 個人頻道訂閱意圖」研究問卷', N'親愛的受訪者您好：
這份問卷主要探討『Podcast 個人頻道訂閱意圖之研究』，以Podcast為研究對象，希望了解使用者收聽Podcast過程中的互動和使用的動機，以及軟體的易用、有用性，是否會影響您的使用態度，進而影響訂閱意圖，希望能對於Podcast做更深入的探討。感謝您的協助。', CAST(N'2022-04-01T00:00:00.000' AS DateTime), CAST(N'2022-06-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'cbb9b6e2-f03e-4913-ba55-5c4c288db90c', 1, N'動漫角色人氣票選', N'人氣票選來囉！紅遍全世界的的鬼滅、航海王以及多啦A夢裡，你最喜歡的角色是？', CAST(N'2022-04-15T00:00:00.000' AS DateTime), CAST(N'2022-04-30T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'ead61633-c431-4e59-8c27-99cba1ac3fe0', 3, N'最靈驗的心理測驗在這裡！', N'在一座巨大的公園內，與三種動物不期而遇的你會選擇哪一種呢? 以及在這樣的環境下，會希望有著哪些色彩映入眼簾?', CAST(N'2022-05-11T00:00:00.000' AS DateTime), CAST(N'2022-06-22T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'35a770f0-a4de-4908-832e-a3dd1079e939', 5, N'校園菁英選拔賽', N'一邊是各個可愛小巧的美少女們，一邊是愛撒嬌的貓貓，另一邊是各國聯軍環肥燕瘦的帥哥哥們，究竟誰能擄獲大眾的心呢！讓我們好好期待！', CAST(N'2022-04-16T00:00:00.000' AS DateTime), CAST(N'2022-05-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', 38, N'aaa', N'aaaaaaa', CAST(N'2022-05-01T00:00:00.000' AS DateTime), CAST(N'2022-06-11T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'20dfbacd-0031-4cf5-96d4-d3e13b03a9b2', 26, N'111+', N'111111+', CAST(N'2022-04-21T00:00:00.000' AS DateTime), CAST(N'2022-06-03T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'f8b835d2-2026-449f-ac74-eac3bd9104e7', 2, N'飲品聯合國 - 購買傾向大調查', N'聊天、小憩的好去處，你最常在時尚的咖啡廳、健康無負擔的果汁店以及大人專屬的夜生活酒吧購買哪樣飲品呢?', CAST(N'2022-05-05T00:00:00.000' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Contents] ([ID], [TitleID], [Title], [Body], [StartDate], [EndDate], [IsEnable]) VALUES (N'aff2a2bb-ea6a-4f73-bb12-fa7d417df027', 37, N'ee', N'eeeeeee', CAST(N'2022-03-27T00:00:00.000' AS DateTime), CAST(N'2022-04-09T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Contents] OFF
GO
INSERT [dbo].[UserInfos] ([UserID], [AccountID], [ID], [CreateDate], [Name], [Phone], [Age], [Email]) VALUES (N'3879c4c6-127a-4224-a9d0-35d46249d46b', NULL, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', CAST(N'2022-05-09T23:29:51.017' AS DateTime), N'qqq', N'0900000000', N'17', N'qqq@gmail.com')
INSERT [dbo].[UserInfos] ([UserID], [AccountID], [ID], [CreateDate], [Name], [Phone], [Age], [Email]) VALUES (N'e00766db-a4d2-4707-8bb5-40452ad89bf2', NULL, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', CAST(N'2022-05-08T15:55:20.540' AS DateTime), N'aaa', N'0900000000', N'10', N'aaa@gmail.com')
INSERT [dbo].[UserInfos] ([UserID], [AccountID], [ID], [CreateDate], [Name], [Phone], [Age], [Email]) VALUES (N'45a11c8f-d46a-4c3c-9d8a-4f6e182c0a78', NULL, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', CAST(N'2022-05-07T01:45:19.497' AS DateTime), N'aaa', N'0900000000', N'10', N'aaa@gmail.com')
INSERT [dbo].[UserInfos] ([UserID], [AccountID], [ID], [CreateDate], [Name], [Phone], [Age], [Email]) VALUES (N'ad6ddcd0-37bf-4df4-ae4f-64b03b9bb98a', NULL, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', CAST(N'2022-05-07T04:58:46.577' AS DateTime), N'aaa', N'0900000000', N'16', N'aaa@gmail.com')
INSERT [dbo].[UserInfos] ([UserID], [AccountID], [ID], [CreateDate], [Name], [Phone], [Age], [Email]) VALUES (N'5c963890-a452-4419-98fa-ebbe5677bcdc', NULL, N'6e082693-705a-46d5-b54e-43e186e8f887', CAST(N'2022-05-07T05:27:52.540' AS DateTime), N'www', N'0900000000', N'25', N'www@gmail.com')
INSERT [dbo].[UserInfos] ([UserID], [AccountID], [ID], [CreateDate], [Name], [Phone], [Age], [Email]) VALUES (N'e5afdaa7-1f9a-45a3-ae89-eda01efe21b5', NULL, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', CAST(N'2022-05-07T05:25:08.860' AS DateTime), N'aaa', N'0900000000', N'10', N'aaa@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[QuesTypes] ON 

INSERT [dbo].[QuesTypes] ([QuesTypeID], [QuesType]) VALUES (1, N'文字')
INSERT [dbo].[QuesTypes] ([QuesTypeID], [QuesType]) VALUES (2, N'單選方塊')
INSERT [dbo].[QuesTypes] ([QuesTypeID], [QuesType]) VALUES (3, N'複選方塊')
SET IDENTITY_INSERT [dbo].[QuesTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[QuesDetails] ON 

INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (2, N'cbb9b6e2-f03e-4913-ba55-5c4c288db90c', N'世界風靡的鬼滅中，你最喜歡的角色是？', NULL, 1, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (4, N'cbb9b6e2-f03e-4913-ba55-5c4c288db90c', N'<航海王>裡面你最喜歡的角色是?', NULL, 1, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (5, N'cbb9b6e2-f03e-4913-ba55-5c4c288db90c', N'歷久不衰的哆啦A夢，主要角色中你最喜歡的是?', N'多拉A夢;大雄;靜香;小夫;胖虎', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (8, N'f8b835d2-2026-449f-ac74-eac3bd9104e7', N'最常在星巴克購買的飲品是?', N'咖啡;星冰樂;茶;果汁', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (9, N'f8b835d2-2026-449f-ac74-eac3bd9104e7', N'酒鋪推廣中，喜歡哪種類型的酒呢? (可複選)', N'清酒;啤酒;葡萄酒;白酒;郎姆酒;白蘭地;威士忌;伏特加', 3, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (13, N'f8b835d2-2026-449f-ac74-eac3bd9104e7', N'日本知名的青森蘋果，你喜歡哪些種類呢? (可複選)', N'王林;富士;金星;世界一;信濃金;陸奧', 3, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (16, N'ead61633-c431-4e59-8c27-99cba1ac3fe0', N'以下三種動物，你最喜歡哪一種?', N'狗狗;貓咪;兔子', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (21, N'ead61633-c431-4e59-8c27-99cba1ac3fe0', N'最喜歡在公園玩的遊樂器材是?', NULL, 1, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (22, N'35a770f0-a4de-4908-832e-a3dd1079e939', N'投給你心目中的女神！請選擇以下一位', N'Flora;Sandra;Momo;Aoi;Nina;Kiki', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (23, N'35a770f0-a4de-4908-832e-a3dd1079e939', N'貓咖最暖喵店員！請寫下你最喜歡的牠的名字', NULL, 1, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (24, N'35a770f0-a4de-4908-832e-a3dd1079e939', N'校園十大帥哥讓你挑！', N'Rin;Ryo;Tim;William;Yuka;George;Leo;Jun', 3, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (40, N'241be2a3-bb55-491f-a41c-20f941fd9424', N'喜歡的顏色有哪些? (可複選)', N'藍色;紅色;綠色;黃色;紫色;粉色;橘色;黑色;白色;', 3, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (41, N'241be2a3-bb55-491f-a41c-20f941fd9424', N'<海賊王>裡面你最喜歡的角色是?', N'', 1, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (44, N'241be2a3-bb55-491f-a41c-20f941fd9424', N'werewr', N'werwer;wer;wer;wer', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (49, N'241be2a3-bb55-491f-a41c-20f941fd9424', N'以下三種動物，你最喜歡?', N'狗狗;貓咪;兔子', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (52, N'20dfbacd-0031-4cf5-96d4-d3e13b03a9b2', N'喜歡的顏色有哪些? (可複選)', N'藍色;紅色;綠色;黃色;紫色;粉色;橘色;黑色;白色', 3, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (53, N'20dfbacd-0031-4cf5-96d4-d3e13b03a9b2', N'日本知名的青森蘋果釀出來的果汁，你喜歡哪種呢? (可複選)', N'王林;富士;金星;世界一;信濃金;陸奧', 3, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (54, N'20dfbacd-0031-4cf5-96d4-d3e13b03a9b2', N'<海賊王>裡面你最喜歡的角色是?', N'', 1, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (55, N'20dfbacd-0031-4cf5-96d4-d3e13b03a9b2', N'111', N'', 1, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (58, N'6e082693-705a-46d5-b54e-43e186e8f887', N'請問您是否有收聽過Podcast的經驗？', N'是;否', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (59, N'6e082693-705a-46d5-b54e-43e186e8f887', N'請問您最常使用何種APP收聽？', N'Castbox;Firstory;Apple Podcasts;KKbox;Spotify;TuneIn Radio;Google Podcast', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (60, N'6e082693-705a-46d5-b54e-43e186e8f887', N'請問您收聽Podcast的頻率為何(以月計算)？', N'1-5次;6-10次;11-15次;16-20次;20次以上', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (61, N'6e082693-705a-46d5-b54e-43e186e8f887', N'請問您每次收聽Podcast的時間?', N'30分鐘(含)以下;31分鐘-1小時;1小時-2小時;2小時以上', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (62, N'6e082693-705a-46d5-b54e-43e186e8f887', N'請問您通常透過何種裝置收聽(可複選)？', N'手機;平板;電腦;其他', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (63, N'6e082693-705a-46d5-b54e-43e186e8f887', N'請問您收聽的主題類型(可複選)？', N'投資類;時事類;政治類;親子類;時尚類;教育類;語言學習類;其他', 3, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (64, N'aff2a2bb-ea6a-4f73-bb12-fa7d417df027', N'世界風靡的鬼滅裡，你最喜歡的角色是？', N'', 1, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (65, N'aff2a2bb-ea6a-4f73-bb12-fa7d417df027', N'ddd', N'dd;ddd;ddddd', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (66, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'日本知名的青森蘋果釀出來的果汁，你喜歡哪種呢? (可複選)', N'王林;富士;金星;世界一;信濃金;陸奧', 3, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (67, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'ddd', N'd1;ddd1;ddd2;ddd3;dd2', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (68, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'aaa', N'', 1, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (69, N'b6518e87-26a1-4d97-9b25-331e980c0984', N'kk', N'kk;kkk;kkkkk', 2, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (70, N'b6518e87-26a1-4d97-9b25-331e980c0984', N'日本知名的青森蘋果釀出來的果汁，你喜歡哪種呢? (可複選)', N'王林;富士;金星;世界一;信濃金;陸奧', 3, 1, NULL)
INSERT [dbo].[QuesDetails] ([QuesID], [ID], [QuesTitle], [QuesChoices], [QuesTypeID], [IsEnable], [Count]) VALUES (71, N'b6518e87-26a1-4d97-9b25-331e980c0984', N'以下三種動物，你最喜歡?', N'狗狗;貓咪;兔子', 2, 1, NULL)
SET IDENTITY_INSERT [dbo].[QuesDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[UserQuesDetails] ON 

INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (1, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'45a11c8f-d46a-4c3c-9d8a-4f6e182c0a78', 66, N'金星;世界一;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (2, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'45a11c8f-d46a-4c3c-9d8a-4f6e182c0a78', 67, N'ddd2;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (3, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'45a11c8f-d46a-4c3c-9d8a-4f6e182c0a78', 68, N'1;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (4, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'ad6ddcd0-37bf-4df4-ae4f-64b03b9bb98a', 66, N'富士;金星;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (5, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'ad6ddcd0-37bf-4df4-ae4f-64b03b9bb98a', 67, N'ddd1;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (6, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'ad6ddcd0-37bf-4df4-ae4f-64b03b9bb98a', 68, N'1;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (7, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'e5afdaa7-1f9a-45a3-ae89-eda01efe21b5', 66, N'富士;世界一;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (8, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'e5afdaa7-1f9a-45a3-ae89-eda01efe21b5', 67, N'dd2;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (9, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'e5afdaa7-1f9a-45a3-ae89-eda01efe21b5', 68, N'1;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (10, N'6e082693-705a-46d5-b54e-43e186e8f887', N'5c963890-a452-4419-98fa-ebbe5677bcdc', 58, N'是;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (11, N'6e082693-705a-46d5-b54e-43e186e8f887', N'5c963890-a452-4419-98fa-ebbe5677bcdc', 59, N'KKbox;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (12, N'6e082693-705a-46d5-b54e-43e186e8f887', N'5c963890-a452-4419-98fa-ebbe5677bcdc', 60, N'11-15次;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (13, N'6e082693-705a-46d5-b54e-43e186e8f887', N'5c963890-a452-4419-98fa-ebbe5677bcdc', 61, N'2小時以上;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (14, N'6e082693-705a-46d5-b54e-43e186e8f887', N'5c963890-a452-4419-98fa-ebbe5677bcdc', 62, N'手機;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (15, N'6e082693-705a-46d5-b54e-43e186e8f887', N'5c963890-a452-4419-98fa-ebbe5677bcdc', 63, N'教育類;語言學習類;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (16, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'e00766db-a4d2-4707-8bb5-40452ad89bf2', 66, N'王林;富士;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (17, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'e00766db-a4d2-4707-8bb5-40452ad89bf2', 67, N'd1;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (18, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'e00766db-a4d2-4707-8bb5-40452ad89bf2', 68, N'1;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (19, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'3879c4c6-127a-4224-a9d0-35d46249d46b', 66, N'金星;信濃金;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (20, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'3879c4c6-127a-4224-a9d0-35d46249d46b', 67, N'ddd2;', NULL)
INSERT [dbo].[UserQuesDetails] ([AnsID], [ID], [UserID], [QuesID], [Answer], [AccountID]) VALUES (21, N'c1fc8d5d-b45c-4467-91bb-d0ca4d7613ec', N'3879c4c6-127a-4224-a9d0-35d46249d46b', 68, N'1;', NULL)
SET IDENTITY_INSERT [dbo].[UserQuesDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[CommonQues] ON 

INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (1, N'<海賊王>裡面你最喜歡的角色是???', 1, NULL, 1)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (2, N'以下三種動物，你最喜歡?', 2, N'狗狗;貓咪;兔子', 1)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (3, N'喜歡的顏色有哪些? (可複選)', 3, N'藍色;紅色;綠色;黃色;紫色;粉色;橘色;黑色;白色', 1)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (4, N'世界風靡的鬼滅裡，你最喜歡的角色是？', 1, NULL, 1)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (5, N'最常在星巴克購買的飲品是?', 2, N'咖啡;星冰樂;茶;果汁', 1)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (6, N'日本知名的青森蘋果釀出來的果汁，你喜歡哪種呢? (可複選)', 3, N'王林;富士;金星;世界一;信濃金;陸奧', 1)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (15, N'ddd', 2, N'd1;ddd1;ddd2;ddd3;dd2', 1)
INSERT [dbo].[CommonQues] ([CQID], [CQTitle], [QuesTypeID], [CQChoices], [CQIsEnable]) VALUES (16, N'aaa+', 2, N'aa;aaa;aaaaa', 1)
SET IDENTITY_INSERT [dbo].[CommonQues] OFF
GO
