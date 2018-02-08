﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUI.weatherServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="weatherServiceReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/WeatherForcast", ReplyAction="http://tempuri.org/IService1/WeatherForcastResponse")]
        string[] WeatherForcast(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/WeatherForcast", ReplyAction="http://tempuri.org/IService1/WeatherForcastResponse")]
        System.Threading.Tasks.Task<string[]> WeatherForcastAsync(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetIndex", ReplyAction="http://tempuri.org/IService1/GetIndexResponse")]
        string GetIndex(string lat, string lng);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetIndex", ReplyAction="http://tempuri.org/IService1/GetIndexResponse")]
        System.Threading.Tasks.Task<string> GetIndexAsync(string lat, string lng);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/checkfunction", ReplyAction="http://tempuri.org/IService1/checkfunctionResponse")]
        string checkfunction(string lat, string lng, System.Collections.Generic.Dictionary<string, string> map);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/checkfunction", ReplyAction="http://tempuri.org/IService1/checkfunctionResponse")]
        System.Threading.Tasks.Task<string> checkfunctionAsync(string lat, string lng, System.Collections.Generic.Dictionary<string, string> map);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/password", ReplyAction="http://tempuri.org/IService1/passwordResponse")]
        string password(string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/password", ReplyAction="http://tempuri.org/IService1/passwordResponse")]
        System.Threading.Tasks.Task<string> passwordAsync(string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/confirmpassword", ReplyAction="http://tempuri.org/IService1/confirmpasswordResponse")]
        bool confirmpassword(string pass1, string pass2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/confirmpassword", ReplyAction="http://tempuri.org/IService1/confirmpasswordResponse")]
        System.Threading.Tasks.Task<bool> confirmpasswordAsync(string pass1, string pass2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/validate", ReplyAction="http://tempuri.org/IService1/validateResponse")]
        bool validate(string firstname, string lastname, string city, string state, string mobile, string age, string emailid, string password, string confirmpassword, string cc_num, string cc_name, string cvv, string sq1, string sq2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/validate", ReplyAction="http://tempuri.org/IService1/validateResponse")]
        System.Threading.Tasks.Task<bool> validateAsync(string firstname, string lastname, string city, string state, string mobile, string age, string emailid, string password, string confirmpassword, string cc_num, string cc_name, string cvv, string sq1, string sq2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/signin", ReplyAction="http://tempuri.org/IService1/signinResponse")]
        bool signin(string emailid, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/signin", ReplyAction="http://tempuri.org/IService1/signinResponse")]
        System.Threading.Tasks.Task<bool> signinAsync(string emailid, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/uniqueemailid", ReplyAction="http://tempuri.org/IService1/uniqueemailidResponse")]
        string uniqueemailid(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/uniqueemailid", ReplyAction="http://tempuri.org/IService1/uniqueemailidResponse")]
        System.Threading.Tasks.Task<string> uniqueemailidAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/regex", ReplyAction="http://tempuri.org/IService1/regexResponse")]
        bool regex(string input, string type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/regex", ReplyAction="http://tempuri.org/IService1/regexResponse")]
        System.Threading.Tasks.Task<bool> regexAsync(string input, string type);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : GUI.weatherServiceReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<GUI.weatherServiceReference.IService1>, GUI.weatherServiceReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] WeatherForcast(string zipcode) {
            return base.Channel.WeatherForcast(zipcode);
        }
        
        public System.Threading.Tasks.Task<string[]> WeatherForcastAsync(string zipcode) {
            return base.Channel.WeatherForcastAsync(zipcode);
        }
        
        public string GetIndex(string lat, string lng) {
            return base.Channel.GetIndex(lat, lng);
        }
        
        public System.Threading.Tasks.Task<string> GetIndexAsync(string lat, string lng) {
            return base.Channel.GetIndexAsync(lat, lng);
        }
        
        public string checkfunction(string lat, string lng, System.Collections.Generic.Dictionary<string, string> map) {
            return base.Channel.checkfunction(lat, lng, map);
        }
        
        public System.Threading.Tasks.Task<string> checkfunctionAsync(string lat, string lng, System.Collections.Generic.Dictionary<string, string> map) {
            return base.Channel.checkfunctionAsync(lat, lng, map);
        }
        
        public string password(string pass) {
            return base.Channel.password(pass);
        }
        
        public System.Threading.Tasks.Task<string> passwordAsync(string pass) {
            return base.Channel.passwordAsync(pass);
        }
        
        public bool confirmpassword(string pass1, string pass2) {
            return base.Channel.confirmpassword(pass1, pass2);
        }
        
        public System.Threading.Tasks.Task<bool> confirmpasswordAsync(string pass1, string pass2) {
            return base.Channel.confirmpasswordAsync(pass1, pass2);
        }
        
        public bool validate(string firstname, string lastname, string city, string state, string mobile, string age, string emailid, string password, string confirmpassword, string cc_num, string cc_name, string cvv, string sq1, string sq2) {
            return base.Channel.validate(firstname, lastname, city, state, mobile, age, emailid, password, confirmpassword, cc_num, cc_name, cvv, sq1, sq2);
        }
        
        public System.Threading.Tasks.Task<bool> validateAsync(string firstname, string lastname, string city, string state, string mobile, string age, string emailid, string password, string confirmpassword, string cc_num, string cc_name, string cvv, string sq1, string sq2) {
            return base.Channel.validateAsync(firstname, lastname, city, state, mobile, age, emailid, password, confirmpassword, cc_num, cc_name, cvv, sq1, sq2);
        }
        
        public bool signin(string emailid, string pass) {
            return base.Channel.signin(emailid, pass);
        }
        
        public System.Threading.Tasks.Task<bool> signinAsync(string emailid, string pass) {
            return base.Channel.signinAsync(emailid, pass);
        }
        
        public string uniqueemailid(string email) {
            return base.Channel.uniqueemailid(email);
        }
        
        public System.Threading.Tasks.Task<string> uniqueemailidAsync(string email) {
            return base.Channel.uniqueemailidAsync(email);
        }
        
        public bool regex(string input, string type) {
            return base.Channel.regex(input, type);
        }
        
        public System.Threading.Tasks.Task<bool> regexAsync(string input, string type) {
            return base.Channel.regexAsync(input, type);
        }
    }
}