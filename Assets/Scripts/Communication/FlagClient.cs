using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;
using System.Text;
using System.Threading.Tasks;

public class FlagClient : MonoBehaviour {
    // Start is called before the first frame update
    #region Network Settings //----------追記
    public string ip;
    public int port;
	#endregion //----------追記
    // Start is called before the first frame update

    void Awake() {
        IpGetter ipGetter = new IpGetter();
        string myIP = ipGetter.GetIp();

        if (myIP == HostList.phone1.ip) {
            ip = HostList.phone2.ip;
            port = HostList.phone1.port_flag;
        }
        else {
            ip = HostList.phone1.ip;
            port = HostList.phone2.port_flag;
        }
        // Debug.Log("client IP : " + ip + "   port : " + port);

        OSCHandler.Instance.clientInit("Akaoni", ip,port);//ipには接続先のipアドレスの文字列を入れる。
    }

    static public async void StartRealSense(){
        for (int i = 0; i < 20; i++) {
            OSCHandler.Instance.SendMessageToClient("Akaoni","/RSstart","OK");//本来True
            await Task.Delay(15);
        }
    }

    static public void SpawnSend(Vector3 point){
        List<float> pointList = new List<float>();
        pointList.Add(point.x);
        pointList.Add(point.y);
        pointList.Add(point.z);
        OSCHandler.Instance.SendMessageToClient("Akaoni","/Spawn",pointList);
    }

    static public async void ReturnPflag(){
        for (int i = 0; i < 20; i++) {
            OSCHandler.Instance.SendMessageToClient("Akaoni","/Pflag","OK");//本来True
            await Task.Delay(15);
        }
    }
    static public async void ReturnSflag(){
        for (int i = 0; i < 20; i++) {
            OSCHandler.Instance.SendMessageToClient("Akaoni","/Sflag","OK");//本来True
            await Task.Delay(15);
        }
    }
}
