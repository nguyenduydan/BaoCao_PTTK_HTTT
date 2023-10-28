using Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhoHang.Views.Import_Product
{
    public class ImportProduct
    {
        public ImportProduct() { }

        public List<ChildrenFeature> Show()
        {
            List<ChildrenFeature> childrenFeatures = new List<ChildrenFeature>();
            ChildrenFeature add = new ChildrenFeature("/Import_Product/Add", "Thêm hàng hóa", "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"39\" height=\"39\" viewBox=\"0 0 39 40\" fill=\"none\">\r\n<path d=\"M12.0999 19.5H26.8999\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n<path d=\"M19.5 26.9V12.1\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n<path d=\"M13.95 38H25.05C34.3 38 38 34.3 38 25.05V13.95C38 4.7 34.3 1 25.05 1H13.95C4.7 1 1 4.7 1 13.95V25.05C1 34.3 4.7 38 13.95 38Z\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n</svg>");
            ChildrenFeature update = new ChildrenFeature("/Import_Product/Update", "Cập nhật đơn hàng", "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"34\" height=\"36\" viewBox=\"0 0 34 36\" fill=\"none\">\r\n<path d=\"M8.78378 5.74414H4.45946C2.54885 5.74414 1 7.16017 1 8.90693V31.0464C1 32.7933 2.54885 34.2092 4.45946 34.2092H14.8378\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\"/>\r\n<path d=\"M20.8918 5.74414H25.2162C27.1268 5.74414 28.6756 7.16017 28.6756 8.90693V23.1395\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\"/>\r\n<path d=\"M7.91888 9.53953V6.53488C7.91888 6.09819 8.3061 5.74418 8.78375 5.74418C9.2614 5.74418 9.65591 5.39001 9.73773 4.95978C9.99401 3.612 10.9874 1 14.8378 1C18.6882 1 19.6816 3.612 19.9379 4.95978C20.0197 5.39001 20.4143 5.74418 20.8919 5.74418C21.3694 5.74418 21.7567 6.09819 21.7567 6.53488V9.53953C21.7567 10.0636 21.2921 10.4884 20.7189 10.4884H8.95672C8.38354 10.4884 7.91888 10.0636 7.91888 9.53953Z\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\"/>\r\n<path d=\"M20.8918 31.8372L24.3513 35L33 27.093\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n</svg>");
            childrenFeatures.Add(add);
            childrenFeatures.Add(update);
            return childrenFeatures;

        }
    }
}