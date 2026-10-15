-- 1. Thêm dữ liệu cho bảng Category
INSERT INTO [dbo].[Category] ([IDCate], [NameCate]) VALUES ('Soccer', N'Môn Bóng Đá');
INSERT INTO [dbo].[Category] ([IDCate], [NameCate]) VALUES ('Watersports', N'Thể Thao Dưới Nước');

-- 2. Thêm dữ liệu mẫu cho bảng Products
INSERT INTO [dbo].[Products] ([NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) 
VALUES (N'Kayak', N'Thuyền kayak thể thao', 'Watersports', 275.00, '~/Content/images/add.png');

INSERT INTO [dbo].[Products] ([NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) 
VALUES (N'Lifejacket', N'Áo phao cứu sinh', 'Watersports', 48.95, '~/Content/images/add.png');

INSERT INTO [dbo].[Products] ([NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) 
VALUES (N'Soccer Ball', N'Bóng đá tiêu chuẩn', 'Soccer', 19.50, '~/Content/images/add.png');