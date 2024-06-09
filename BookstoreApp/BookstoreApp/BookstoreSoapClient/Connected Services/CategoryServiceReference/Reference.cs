﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CategoryServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Category", Namespace="http://schemas.datacontract.org/2004/07/Domain.Entities")]
    public partial class Category : object
    {
        
        private CategoryServiceReference.Book[] BooksField;
        
        private int IdField;
        
        private string NameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CategoryServiceReference.Book[] Books
        {
            get
            {
                return this.BooksField;
            }
            set
            {
                this.BooksField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Book", Namespace="http://schemas.datacontract.org/2004/07/Domain.Entities")]
    public partial class Book : object
    {
        
        private string AuthorField;
        
        private CategoryServiceReference.Category CategoryField;
        
        private int CategoryIdField;
        
        private string ISBNField;
        
        private int IdField;
        
        private CategoryServiceReference.OrderBook[] OrderBooksField;
        
        private decimal PriceField;
        
        private string TitleField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Author
        {
            get
            {
                return this.AuthorField;
            }
            set
            {
                this.AuthorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CategoryServiceReference.Category Category
        {
            get
            {
                return this.CategoryField;
            }
            set
            {
                this.CategoryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CategoryId
        {
            get
            {
                return this.CategoryIdField;
            }
            set
            {
                this.CategoryIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ISBN
        {
            get
            {
                return this.ISBNField;
            }
            set
            {
                this.ISBNField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CategoryServiceReference.OrderBook[] OrderBooks
        {
            get
            {
                return this.OrderBooksField;
            }
            set
            {
                this.OrderBooksField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price
        {
            get
            {
                return this.PriceField;
            }
            set
            {
                this.PriceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title
        {
            get
            {
                return this.TitleField;
            }
            set
            {
                this.TitleField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderBook", Namespace="http://schemas.datacontract.org/2004/07/Domain.Entities")]
    public partial class OrderBook : object
    {
        
        private CategoryServiceReference.Book BookField;
        
        private int BookIdField;
        
        private CategoryServiceReference.Order OrderField;
        
        private int OrderIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CategoryServiceReference.Book Book
        {
            get
            {
                return this.BookField;
            }
            set
            {
                this.BookField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BookId
        {
            get
            {
                return this.BookIdField;
            }
            set
            {
                this.BookIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CategoryServiceReference.Order Order
        {
            get
            {
                return this.OrderField;
            }
            set
            {
                this.OrderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderId
        {
            get
            {
                return this.OrderIdField;
            }
            set
            {
                this.OrderIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/Domain.Entities")]
    public partial class Order : object
    {
        
        private CategoryServiceReference.Customer CustomerField;
        
        private int CustomerIdField;
        
        private int IdField;
        
        private CategoryServiceReference.OrderBook[] OrderBooksField;
        
        private System.DateTime OrderDateField;
        
        private decimal TotalAmountField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CategoryServiceReference.Customer Customer
        {
            get
            {
                return this.CustomerField;
            }
            set
            {
                this.CustomerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CustomerId
        {
            get
            {
                return this.CustomerIdField;
            }
            set
            {
                this.CustomerIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CategoryServiceReference.OrderBook[] OrderBooks
        {
            get
            {
                return this.OrderBooksField;
            }
            set
            {
                this.OrderBooksField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime OrderDate
        {
            get
            {
                return this.OrderDateField;
            }
            set
            {
                this.OrderDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TotalAmount
        {
            get
            {
                return this.TotalAmountField;
            }
            set
            {
                this.TotalAmountField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customer", Namespace="http://schemas.datacontract.org/2004/07/Domain.Entities")]
    public partial class Customer : object
    {
        
        private string EmailField;
        
        private string FirstNameField;
        
        private int IdField;
        
        private string LastNameField;
        
        private CategoryServiceReference.Order[] OrdersField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                this.EmailField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName
        {
            get
            {
                return this.FirstNameField;
            }
            set
            {
                this.FirstNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName
        {
            get
            {
                return this.LastNameField;
            }
            set
            {
                this.LastNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CategoryServiceReference.Order[] Orders
        {
            get
            {
                return this.OrdersField;
            }
            set
            {
                this.OrdersField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CategoryServiceReference.ICategorySoapService")]
    public interface ICategorySoapService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategorySoapService/GetCategories", ReplyAction="http://tempuri.org/ICategorySoapService/GetCategoriesResponse")]
        System.Threading.Tasks.Task<CategoryServiceReference.Category[]> GetCategoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategorySoapService/GetCategory", ReplyAction="http://tempuri.org/ICategorySoapService/GetCategoryResponse")]
        System.Threading.Tasks.Task<CategoryServiceReference.Category> GetCategoryAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategorySoapService/CategoryExists", ReplyAction="http://tempuri.org/ICategorySoapService/CategoryExistsResponse")]
        System.Threading.Tasks.Task<bool> CategoryExistsAsync(int categoryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategorySoapService/CreateCategory", ReplyAction="http://tempuri.org/ICategorySoapService/CreateCategoryResponse")]
        System.Threading.Tasks.Task<bool> CreateCategoryAsync(CategoryServiceReference.Category category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategorySoapService/UpdateCategory", ReplyAction="http://tempuri.org/ICategorySoapService/UpdateCategoryResponse")]
        System.Threading.Tasks.Task<bool> UpdateCategoryAsync(CategoryServiceReference.Category category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategorySoapService/DeleteCategory", ReplyAction="http://tempuri.org/ICategorySoapService/DeleteCategoryResponse")]
        System.Threading.Tasks.Task<bool> DeleteCategoryAsync(int categoryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategorySoapService/Save", ReplyAction="http://tempuri.org/ICategorySoapService/SaveResponse")]
        System.Threading.Tasks.Task<bool> SaveAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface ICategorySoapServiceChannel : CategoryServiceReference.ICategorySoapService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class CategorySoapServiceClient : System.ServiceModel.ClientBase<CategoryServiceReference.ICategorySoapService>, CategoryServiceReference.ICategorySoapService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CategorySoapServiceClient() : 
                base(CategorySoapServiceClient.GetDefaultBinding(), CategorySoapServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ICategorySoapService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategorySoapServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(CategorySoapServiceClient.GetBindingForEndpoint(endpointConfiguration), CategorySoapServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategorySoapServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CategorySoapServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategorySoapServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CategorySoapServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategorySoapServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<CategoryServiceReference.Category[]> GetCategoriesAsync()
        {
            return base.Channel.GetCategoriesAsync();
        }
        
        public System.Threading.Tasks.Task<CategoryServiceReference.Category> GetCategoryAsync(int id)
        {
            return base.Channel.GetCategoryAsync(id);
        }
        
        public System.Threading.Tasks.Task<bool> CategoryExistsAsync(int categoryId)
        {
            return base.Channel.CategoryExistsAsync(categoryId);
        }
        
        public System.Threading.Tasks.Task<bool> CreateCategoryAsync(CategoryServiceReference.Category category)
        {
            return base.Channel.CreateCategoryAsync(category);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateCategoryAsync(CategoryServiceReference.Category category)
        {
            return base.Channel.UpdateCategoryAsync(category);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteCategoryAsync(int categoryId)
        {
            return base.Channel.DeleteCategoryAsync(categoryId);
        }
        
        public System.Threading.Tasks.Task<bool> SaveAsync()
        {
            return base.Channel.SaveAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICategorySoapService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICategorySoapService))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:7159/CategorySoapService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return CategorySoapServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ICategorySoapService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return CategorySoapServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ICategorySoapService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ICategorySoapService,
        }
    }
}