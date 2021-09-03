﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcademyF.Week7.Prova7.ClientWCF.CommerceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customer", Namespace="http://schemas.datacontract.org/2004/07/AcademyF.Week7.Prova7.Core.Entities")]
    [System.SerializableAttribute()]
    public partial class Customer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerCode {
            get {
                return this.CustomerCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerCodeField, value) != true)) {
                    this.CustomerCodeField = value;
                    this.RaisePropertyChanged("CustomerCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CommerceReference.ICommerceService")]
    public interface ICommerceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommerceService/FetchAllCustomers", ReplyAction="http://tempuri.org/ICommerceService/FetchAllCustomersResponse")]
        System.Collections.Generic.List<AcademyF.Week7.Prova7.ClientWCF.CommerceReference.Customer> FetchAllCustomers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommerceService/GetCustomerById", ReplyAction="http://tempuri.org/ICommerceService/GetCustomerByIdResponse")]
        AcademyF.Week7.Prova7.ClientWCF.CommerceReference.Customer GetCustomerById(int idCustomer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommerceService/CreateCustomer", ReplyAction="http://tempuri.org/ICommerceService/CreateCustomerResponse")]
        bool CreateCustomer(AcademyF.Week7.Prova7.ClientWCF.CommerceReference.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommerceService/UpdateCustomer", ReplyAction="http://tempuri.org/ICommerceService/UpdateCustomerResponse")]
        bool UpdateCustomer(AcademyF.Week7.Prova7.ClientWCF.CommerceReference.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommerceService/DeleteCustomerById", ReplyAction="http://tempuri.org/ICommerceService/DeleteCustomerByIdResponse")]
        bool DeleteCustomerById(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICommerceServiceChannel : AcademyF.Week7.Prova7.ClientWCF.CommerceReference.ICommerceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CommerceServiceClient : System.ServiceModel.ClientBase<AcademyF.Week7.Prova7.ClientWCF.CommerceReference.ICommerceService>, AcademyF.Week7.Prova7.ClientWCF.CommerceReference.ICommerceService {
        
        public CommerceServiceClient() {
        }
        
        public CommerceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CommerceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommerceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommerceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<AcademyF.Week7.Prova7.ClientWCF.CommerceReference.Customer> FetchAllCustomers() {
            return base.Channel.FetchAllCustomers();
        }
        
        public AcademyF.Week7.Prova7.ClientWCF.CommerceReference.Customer GetCustomerById(int idCustomer) {
            return base.Channel.GetCustomerById(idCustomer);
        }
        
        public bool CreateCustomer(AcademyF.Week7.Prova7.ClientWCF.CommerceReference.Customer customer) {
            return base.Channel.CreateCustomer(customer);
        }
        
        public bool UpdateCustomer(AcademyF.Week7.Prova7.ClientWCF.CommerceReference.Customer customer) {
            return base.Channel.UpdateCustomer(customer);
        }
        
        public bool DeleteCustomerById(int id) {
            return base.Channel.DeleteCustomerById(id);
        }
    }
}
