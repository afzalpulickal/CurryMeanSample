using CurrymeanAuthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CurrymeanAuthService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICurryMeanAuthn" in both code and config file together.
    [ServiceContract]
    public interface ICurryMeanAuthn
    {
        [OperationContract]

        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "getAuth/{id}/{password}"
            )]
        Employee JSONData(string id, string password);
        [OperationContract]

        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "GetDetails/{userName}/{password}"
            )]
        List<Employee> GetDetails(string userName, string password);


        [OperationContract]

        [WebInvoke(Method = "POST",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "NewUser"
            )]
        bool NewUser(Employee arr);


        [OperationContract]

        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "getData/"
    )]
        List<Tree> getData();


    }
}
