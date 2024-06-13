using System.Collections.Generic;
using System.ServiceModel;

namespace TankProject
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Start(string value);

        [OperationContract]
        List<string> GetPoints();

        [OperationContract]
        int GetSize();

        [OperationContract]
        string MoveUP(string value);

        [OperationContract]
        string MoveDOWN(string value);

        [OperationContract]
        string MoveLeft(string value);

        [OperationContract]
        string MoveRight(string value);
    }
}
