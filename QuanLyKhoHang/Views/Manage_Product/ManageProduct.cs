using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Manage;

namespace QuanLyKhoHang.Views.Manage_Product
{
    public class ManageProduct
    {
        public ManageProduct() { }

        public List<ChildrenFeature> Show() {
            List<ChildrenFeature> childrenFeatures = new List<ChildrenFeature>();
            ChildrenFeature classify = new ChildrenFeature("/Manage_Product/Classify", "Phân loại", "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"42\" height=\"43\" viewBox=\"0 0 42 43\" fill=\"none\">\r\n<path d=\"M22.7808 8.76007H7.22022C3.80009 8.76007 1 11.5602 1 14.9803V37.7012C1 40.6014 3.08008 41.8414 5.62018 40.4213L13.4805 36.0412C14.3205 35.5812 15.6806 35.5812 16.5006 36.0412L24.3609 40.4213C26.901 41.8414 28.9811 40.6014 28.9811 37.7012V14.9803C29.0011 11.5602 26.201 8.76007 22.7808 8.76007Z\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n<path d=\"M29.0011 14.9803V37.7012C29.0011 40.6014 26.921 41.8214 24.3809 40.4213L16.5206 36.0412C15.6806 35.5812 14.3205 35.5812 13.4805 36.0412L5.62018 40.4213C3.08008 41.8214 1 40.6014 1 37.7012V14.9803C1 11.5602 3.80009 8.76007 7.22022 8.76007H22.7808C26.201 8.76007 29.0011 11.5602 29.0011 14.9803Z\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n<path d=\"M41.0013 7.22022V29.9411C41.0013 32.8412 38.9213 34.0613 36.3812 32.6612L29.0009 28.5411V14.9805C29.0009 11.5604 26.2008 8.7603 22.7806 8.7603H13.0002V7.22022C13.0002 3.80009 15.8003 1 19.2205 1H34.7811C38.2012 1 41.0013 3.80009 41.0013 7.22022Z\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n</svg>");
            ChildrenFeature search = new ChildrenFeature("/Manage_Product/Search", "Tra cứu", "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"42\" height=\"41\" viewBox=\"0 0 42 41\" fill=\"none\">\r\n  <path d=\"M2.51257 11.5582L19.6504 21.4759L36.6717 11.6163\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n  <path d=\"M19.6504 39.0604V21.4567\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n  <path d=\"M23.6692 38.8859C22.563 39.5069 21.1073 39.8175 19.6517 39.8175C18.196 39.8175 16.7404 39.5069 15.6341 38.8859L5.26988 33.1409C2.92144 31.8405 1 28.5799 1 25.9015\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n  <path d=\"M38.3034 22.0196V14.916C38.3034 12.2376 36.3819 8.97699 34.0335 7.67661L23.6692 1.93161C21.4567 0.689462 17.8467 0.689462 15.6341 1.93161L5.26988 7.67661C2.92144 8.97699 1 12.2376 1 14.916\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n  <path d=\"M33.6246 38.6528C37.0547 38.6528 39.8353 35.8721 39.8353 32.442C39.8353 29.0119 37.0547 26.2312 33.6246 26.2312C30.1945 26.2312 27.4138 29.0119 27.4138 32.442C27.4138 35.8721 30.1945 38.6528 33.6246 38.6528Z\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n  <path d=\"M40.9999 39.8173L39.0591 37.8764\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n</svg>");
            ChildrenFeature inventory = new ChildrenFeature("/Manage_Product/CheckProduct", "Hàng tồn", "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"38\" height=\"38\" viewBox=\"0 0 38 38\" fill=\"none\">\r\n<path d=\"M19.666 13.3838H29.116\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n<path d=\"M8.88379 13.3838L10.2338 14.7338L14.2838 10.6838\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n<path d=\"M19.666 25.9839H29.116\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n<path d=\"M8.88379 25.9838L10.2338 27.3338L14.2838 23.2838\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n<path d=\"M13.6 37H24.4C33.4 37 37 33.4 37 24.4V13.6C37 4.6 33.4 1 24.4 1H13.6C4.6 1 1 4.6 1 13.6V24.4C1 33.4 4.6 37 13.6 37Z\" stroke=\"#787486\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>\r\n</svg>");
            childrenFeatures.Add(classify);
            childrenFeatures.Add(search);
            childrenFeatures.Add(inventory);
            return childrenFeatures;

        }
    }
}