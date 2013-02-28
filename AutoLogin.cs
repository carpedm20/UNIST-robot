using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace robot
{
    class AutoLogin
    {
        public AutoLogin()
        {

        }

        public bool ReadRegistry(ref string id, ref string pw)
        {
            RegistryKey reg = Registry.LocalMachine.CreateSubKey("SoftWare").CreateSubKey("robot_carpedm20");
            id = reg.GetValue("ID", "").ToString();
            pw = reg.GetValue("PW", "").ToString();

            if (id == "" || id == "" && pw == "")
                return false;
            else
                return true;
        }

        public void WriteRegistry(string id, string pw)
        {
            RegistryKey reg = Registry.LocalMachine.CreateSubKey("SoftWare").CreateSubKey("robot_carpedm20");
            reg.SetValue("ID", id);
            reg.SetValue("PW", pw);
        }

        public bool NateReadRegistry(ref string id, ref string pw, ref string nate)
        {
            RegistryKey reg = Registry.LocalMachine.CreateSubKey("SoftWare").CreateSubKey("robot_carpedm20");
            id = reg.GetValue("ID", "").ToString();
            pw = reg.GetValue("PW", "").ToString();

            if (id == "" && pw == "")
                return false;
            else
                return true;
        }

        public void NateWriteRegistry(string id, string pw, string nate)
        {
            RegistryKey reg = Registry.LocalMachine.CreateSubKey("SoftWare").CreateSubKey("robot_carpedm20");
            reg.SetValue("ID", id);
            reg.SetValue("PW", pw);
        }
    }
}
