﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProlizHesService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HESListesi", Namespace="http://tempuri.org/")]
    public partial class HESListesi : object
    {
        
        private int recCountField;
        
        private bool SucessField;
        
        private string ErrorField;
        
        private System.Collections.Generic.List<ProlizHesService.HES> hesListesiField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int recCount
        {
            get
            {
                return this.recCountField;
            }
            set
            {
                this.recCountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public bool Sucess
        {
            get
            {
                return this.SucessField;
            }
            set
            {
                this.SucessField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Error
        {
            get
            {
                return this.ErrorField;
            }
            set
            {
                this.ErrorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public System.Collections.Generic.List<ProlizHesService.HES> hesListesi
        {
            get
            {
                return this.hesListesiField;
            }
            set
            {
                this.hesListesiField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HES", Namespace="http://tempuri.org/")]
    public partial class HES : object
    {
        
        private string TIPField;
        
        private string S_NOField;
        
        private string TCKIMLIKNOField;
        
        private string HES_KODField;
        
        private string HES_TARIHField;
        
        private string RISK_DURUMField;
        
        private string ASI_DURUMField;
        
        private string ASI_TARIHField;
        
        private string SORGU_TARField;
        
        private string SBE_ASI_STATField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TIP
        {
            get
            {
                return this.TIPField;
            }
            set
            {
                this.TIPField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string S_NO
        {
            get
            {
                return this.S_NOField;
            }
            set
            {
                this.S_NOField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string TCKIMLIKNO
        {
            get
            {
                return this.TCKIMLIKNOField;
            }
            set
            {
                this.TCKIMLIKNOField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string HES_KOD
        {
            get
            {
                return this.HES_KODField;
            }
            set
            {
                this.HES_KODField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string HES_TARIH
        {
            get
            {
                return this.HES_TARIHField;
            }
            set
            {
                this.HES_TARIHField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string RISK_DURUM
        {
            get
            {
                return this.RISK_DURUMField;
            }
            set
            {
                this.RISK_DURUMField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string ASI_DURUM
        {
            get
            {
                return this.ASI_DURUMField;
            }
            set
            {
                this.ASI_DURUMField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string ASI_TARIH
        {
            get
            {
                return this.ASI_TARIHField;
            }
            set
            {
                this.ASI_TARIHField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string SORGU_TAR
        {
            get
            {
                return this.SORGU_TARField;
            }
            set
            {
                this.SORGU_TARField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string SBE_ASI_STAT
        {
            get
            {
                return this.SBE_ASI_STATField;
            }
            set
            {
                this.SBE_ASI_STATField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProlizHesService.proliz_obs_hes_minerSoap")]
    public interface proliz_obs_hes_minerSoap
    {
        
        // CODEGEN: Generating message contract since element name userName from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HESListesiSBE", ReplyAction="*")]
        ProlizHesService.HESListesiSBEResponse HESListesiSBE(ProlizHesService.HESListesiSBERequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HESListesiSBE", ReplyAction="*")]
        System.Threading.Tasks.Task<ProlizHesService.HESListesiSBEResponse> HESListesiSBEAsync(ProlizHesService.HESListesiSBERequest request);
        
        // CODEGEN: Generating message contract since element name userName from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HESListesiYOKSIS", ReplyAction="*")]
        ProlizHesService.HESListesiYOKSISResponse HESListesiYOKSIS(ProlizHesService.HESListesiYOKSISRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HESListesiYOKSIS", ReplyAction="*")]
        System.Threading.Tasks.Task<ProlizHesService.HESListesiYOKSISResponse> HESListesiYOKSISAsync(ProlizHesService.HESListesiYOKSISRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HESListesiSBERequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HESListesiSBE", Namespace="http://tempuri.org/", Order=0)]
        public ProlizHesService.HESListesiSBERequestBody Body;
        
        public HESListesiSBERequest()
        {
        }
        
        public HESListesiSBERequest(ProlizHesService.HESListesiSBERequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HESListesiSBERequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string password;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string sadeceRiskli;
        
        public HESListesiSBERequestBody()
        {
        }
        
        public HESListesiSBERequestBody(string userName, string password, string sadeceRiskli)
        {
            this.userName = userName;
            this.password = password;
            this.sadeceRiskli = sadeceRiskli;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HESListesiSBEResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HESListesiSBEResponse", Namespace="http://tempuri.org/", Order=0)]
        public ProlizHesService.HESListesiSBEResponseBody Body;
        
        public HESListesiSBEResponse()
        {
        }
        
        public HESListesiSBEResponse(ProlizHesService.HESListesiSBEResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HESListesiSBEResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<ProlizHesService.HESListesi> HESListesiSBEResult;
        
        public HESListesiSBEResponseBody()
        {
        }
        
        public HESListesiSBEResponseBody(System.Collections.Generic.List<ProlizHesService.HESListesi> HESListesiSBEResult)
        {
            this.HESListesiSBEResult = HESListesiSBEResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HESListesiYOKSISRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HESListesiYOKSIS", Namespace="http://tempuri.org/", Order=0)]
        public ProlizHesService.HESListesiYOKSISRequestBody Body;
        
        public HESListesiYOKSISRequest()
        {
        }
        
        public HESListesiYOKSISRequest(ProlizHesService.HESListesiYOKSISRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HESListesiYOKSISRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string password;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string sadeceRiskli;
        
        public HESListesiYOKSISRequestBody()
        {
        }
        
        public HESListesiYOKSISRequestBody(string userName, string password, string sadeceRiskli)
        {
            this.userName = userName;
            this.password = password;
            this.sadeceRiskli = sadeceRiskli;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HESListesiYOKSISResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HESListesiYOKSISResponse", Namespace="http://tempuri.org/", Order=0)]
        public ProlizHesService.HESListesiYOKSISResponseBody Body;
        
        public HESListesiYOKSISResponse()
        {
        }
        
        public HESListesiYOKSISResponse(ProlizHesService.HESListesiYOKSISResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HESListesiYOKSISResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<ProlizHesService.HESListesi> HESListesiYOKSISResult;
        
        public HESListesiYOKSISResponseBody()
        {
        }
        
        public HESListesiYOKSISResponseBody(System.Collections.Generic.List<ProlizHesService.HESListesi> HESListesiYOKSISResult)
        {
            this.HESListesiYOKSISResult = HESListesiYOKSISResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface proliz_obs_hes_minerSoapChannel : ProlizHesService.proliz_obs_hes_minerSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class proliz_obs_hes_minerSoapClient : System.ServiceModel.ClientBase<ProlizHesService.proliz_obs_hes_minerSoap>, ProlizHesService.proliz_obs_hes_minerSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public proliz_obs_hes_minerSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(proliz_obs_hes_minerSoapClient.GetBindingForEndpoint(endpointConfiguration), proliz_obs_hes_minerSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public proliz_obs_hes_minerSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(proliz_obs_hes_minerSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public proliz_obs_hes_minerSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(proliz_obs_hes_minerSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public proliz_obs_hes_minerSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ProlizHesService.HESListesiSBEResponse ProlizHesService.proliz_obs_hes_minerSoap.HESListesiSBE(ProlizHesService.HESListesiSBERequest request)
        {
            return base.Channel.HESListesiSBE(request);
        }
        
        public System.Collections.Generic.List<ProlizHesService.HESListesi> HESListesiSBE(string userName, string password, string sadeceRiskli)
        {
            ProlizHesService.HESListesiSBERequest inValue = new ProlizHesService.HESListesiSBERequest();
            inValue.Body = new ProlizHesService.HESListesiSBERequestBody();
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            inValue.Body.sadeceRiskli = sadeceRiskli;
            ProlizHesService.HESListesiSBEResponse retVal = ((ProlizHesService.proliz_obs_hes_minerSoap)(this)).HESListesiSBE(inValue);
            return retVal.Body.HESListesiSBEResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ProlizHesService.HESListesiSBEResponse> ProlizHesService.proliz_obs_hes_minerSoap.HESListesiSBEAsync(ProlizHesService.HESListesiSBERequest request)
        {
            return base.Channel.HESListesiSBEAsync(request);
        }
        
        public System.Threading.Tasks.Task<ProlizHesService.HESListesiSBEResponse> HESListesiSBEAsync(string userName, string password, string sadeceRiskli)
        {
            ProlizHesService.HESListesiSBERequest inValue = new ProlizHesService.HESListesiSBERequest();
            inValue.Body = new ProlizHesService.HESListesiSBERequestBody();
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            inValue.Body.sadeceRiskli = sadeceRiskli;
            return ((ProlizHesService.proliz_obs_hes_minerSoap)(this)).HESListesiSBEAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ProlizHesService.HESListesiYOKSISResponse ProlizHesService.proliz_obs_hes_minerSoap.HESListesiYOKSIS(ProlizHesService.HESListesiYOKSISRequest request)
        {
            return base.Channel.HESListesiYOKSIS(request);
        }
        
        public System.Collections.Generic.List<ProlizHesService.HESListesi> HESListesiYOKSIS(string userName, string password, string sadeceRiskli)
        {
            ProlizHesService.HESListesiYOKSISRequest inValue = new ProlizHesService.HESListesiYOKSISRequest();
            inValue.Body = new ProlizHesService.HESListesiYOKSISRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            inValue.Body.sadeceRiskli = sadeceRiskli;
            ProlizHesService.HESListesiYOKSISResponse retVal = ((ProlizHesService.proliz_obs_hes_minerSoap)(this)).HESListesiYOKSIS(inValue);
            return retVal.Body.HESListesiYOKSISResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ProlizHesService.HESListesiYOKSISResponse> ProlizHesService.proliz_obs_hes_minerSoap.HESListesiYOKSISAsync(ProlizHesService.HESListesiYOKSISRequest request)
        {
            return base.Channel.HESListesiYOKSISAsync(request);
        }
        
        public System.Threading.Tasks.Task<ProlizHesService.HESListesiYOKSISResponse> HESListesiYOKSISAsync(string userName, string password, string sadeceRiskli)
        {
            ProlizHesService.HESListesiYOKSISRequest inValue = new ProlizHesService.HESListesiYOKSISRequest();
            inValue.Body = new ProlizHesService.HESListesiYOKSISRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            inValue.Body.sadeceRiskli = sadeceRiskli;
            return ((ProlizHesService.proliz_obs_hes_minerSoap)(this)).HESListesiYOKSISAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.proliz_obs_hes_minerSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.proliz_obs_hes_minerSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.proliz_obs_hes_minerSoap))
            {
                return new System.ServiceModel.EndpointAddress("https://obs.halic.edu.tr/proliz_obs_hes_miner/proliz_obs_hes_miner.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.proliz_obs_hes_minerSoap12))
            {
                return new System.ServiceModel.EndpointAddress("https://obs.halic.edu.tr/proliz_obs_hes_miner/proliz_obs_hes_miner.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            proliz_obs_hes_minerSoap,
            
            proliz_obs_hes_minerSoap12,
        }
    }
}