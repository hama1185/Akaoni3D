using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class HostList {
    static public Host phone1 = new Host("192.168.11.22", 8000, 8001, 8002);
    static public Host phone2 = new Host("192.168.11.30", 8001, 8000, 8002);

    public class Host {
        public string ip {get; set;}
        public int port_status {get; set;}
        public int port_flag {get; set;}
        public int port_realsense {get; set;}

        public Host(string _ip, int port1, int port2, int port3) {
            ip = _ip;
            port_status = port1;
            port_flag = port2;
            port_realsense = port3;
        }
    }
}