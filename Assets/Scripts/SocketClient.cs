using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;

public class SocketClient : MonoBehaviour
{
    private Socket tcpClient;
    private string serverIP = "192.168.2.100";//���ip���Լ�����ip
    private int serverPort = 5000;

    // Start is called before the first frame update
    void Start()
    {
        //1.����һ��Socket
        tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //2.������������
        IPAddress ipaddress = IPAddress.Parse(serverIP);
        EndPoint endPoint = new IPEndPoint(ipaddress, serverPort);
        tcpClient.Connect(endPoint);
        Debug.Log("�������������");

        //3.����/������Ϣ
        byte[] data = new byte[1024];
        int length = tcpClient.Receive(data);
        var message = Encoding.UTF8.GetString(data, 0, length);
        Debug.Log("�ͻ��˽��յ���������������Ϣ:" + message);


        //������Ϣ
        string message2 = "Client Say To Server Hello";
        tcpClient.Send(Encoding.UTF8.GetBytes(message2));
        Debug.Log("�ͻ����������������Ϣ" + message2);



    }

    // Update is called once per frame
    void Update()
    {

    }
}
