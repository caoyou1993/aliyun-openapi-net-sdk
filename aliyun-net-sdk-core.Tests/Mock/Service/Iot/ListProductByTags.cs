using System;
using System.Collections.Generic;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Transform;
using Aliyun.Acs.Core.Utils;

namespace Aliyun.Acs.Core.Tests.Mock.Service.Iot
{
    public class ListProductByTagsRequest : RpcAcsRequest<ListProductByTagsResponse>
    {
        public ListProductByTagsRequest() : base("Iot", "2018-01-20", "ListProductByTags", "iot", "openAPI") { }

        private List<ProductTag> productTags;

        private string iotInstanceId;

        private int? pageSize;

        private int? currentPage;

        private string accessKeyId;

        public List<ProductTag> ProductTags
        {
            get
            {
                return productTags;
            }

            set
            {
                productTags = value;
                for (int i = 0; i < productTags.Count; i++)
                {
                    DictionaryUtil.Add(QueryParameters, "ProductTag." + (i + 1) + ".TagValue", productTags[i].TagValue);
                    DictionaryUtil.Add(QueryParameters, "ProductTag." + (i + 1) + ".TagKey", productTags[i].TagKey);
                }
            }
        }

        public string IotInstanceId
        {
            get
            {
                return iotInstanceId;
            }
            set
            {
                iotInstanceId = value;
                DictionaryUtil.Add(QueryParameters, "IotInstanceId", value);
            }
        }

        public int? PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value;
                DictionaryUtil.Add(QueryParameters, "PageSize", value.ToString());
            }
        }

        public int? CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                DictionaryUtil.Add(QueryParameters, "CurrentPage", value.ToString());
            }
        }

        public string AccessKeyId
        {
            get
            {
                return accessKeyId;
            }
            set
            {
                accessKeyId = value;
                DictionaryUtil.Add(QueryParameters, "AccessKeyId", value);
            }
        }

        public class ProductTag
        {

            private string tagValue;

            private string tagKey;

            public string TagValue
            {
                get
                {
                    return tagValue;
                }
                set
                {
                    tagValue = value;
                }
            }

            public string TagKey
            {
                get
                {
                    return tagKey;
                }
                set
                {
                    tagKey = value;
                }
            }
        }

        public override ListProductByTagsResponse GetResponse(Core.Transform.UnmarshallerContext unmarshallerContext)
        {
            return ListProductByTagsResponseUnmarshaller.Unmarshall(unmarshallerContext);
        }
    }

    public class ListProductByTagsResponse : AcsResponse
    {

        private string requestId;

        private bool? success;

        private string errorMessage;

        private string code;

        private List<ListProductByTags_ProductInfo> productInfos;

        public new string RequestId
        {
            get
            {
                return requestId;
            }
            set
            {
                requestId = value;
            }
        }

        public bool? Success
        {
            get
            {
                return success;
            }
            set
            {
                success = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
            }
        }

        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        public List<ListProductByTags_ProductInfo> ProductInfos
        {
            get
            {
                return productInfos;
            }
            set
            {
                productInfos = value;
            }
        }

        public class ListProductByTags_ProductInfo
        {

            private string productName;

            private string productKey;

            private long? createTime;

            private string description;

            private int? nodeType;

            public string ProductName
            {
                get
                {
                    return productName;
                }
                set
                {
                    productName = value;
                }
            }

            public string ProductKey
            {
                get
                {
                    return productKey;
                }
                set
                {
                    productKey = value;
                }
            }

            public long? CreateTime
            {
                get
                {
                    return createTime;
                }
                set
                {
                    createTime = value;
                }
            }

            public string Description
            {
                get
                {
                    return description;
                }
                set
                {
                    description = value;
                }
            }

            public int? NodeType
            {
                get
                {
                    return nodeType;
                }
                set
                {
                    nodeType = value;
                }
            }
        }
    }

    public class ListProductByTagsResponseUnmarshaller
    {
        public static ListProductByTagsResponse Unmarshall(UnmarshallerContext context)
        {
            ListProductByTagsResponse listProductByTagsResponse = new ListProductByTagsResponse();

            listProductByTagsResponse.HttpResponse = context.HttpResponse;
            listProductByTagsResponse.RequestId = context.StringValue("ListProductByTags.RequestId");
            listProductByTagsResponse.Success = context.BooleanValue("ListProductByTags.Success");
            listProductByTagsResponse.ErrorMessage = context.StringValue("ListProductByTags.ErrorMessage");
            listProductByTagsResponse.Code = context.StringValue("ListProductByTags.Code");

            List<ListProductByTagsResponse.ListProductByTags_ProductInfo> listProductByTagsResponse_productInfos = new List<ListProductByTagsResponse.ListProductByTags_ProductInfo>();
            for (int i = 0; i < context.Length("ListProductByTags.ProductInfos.Length"); i++)
            {
                ListProductByTagsResponse.ListProductByTags_ProductInfo productInfo = new ListProductByTagsResponse.ListProductByTags_ProductInfo();
                productInfo.ProductName = context.StringValue("ListProductByTags.ProductInfos[" + i + "].ProductName");
                productInfo.ProductKey = context.StringValue("ListProductByTags.ProductInfos[" + i + "].ProductKey");
                productInfo.CreateTime = context.LongValue("ListProductByTags.ProductInfos[" + i + "].CreateTime");
                productInfo.Description = context.StringValue("ListProductByTags.ProductInfos[" + i + "].Description");
                productInfo.NodeType = context.IntegerValue("ListProductByTags.ProductInfos[" + i + "].NodeType");

                listProductByTagsResponse_productInfos.Add(productInfo);
            }
            listProductByTagsResponse.ProductInfos = listProductByTagsResponse_productInfos;

            return listProductByTagsResponse;
        }
    }
}
