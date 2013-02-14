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
            if (id == "")
                return false;
            return true;
        }

        public void WriteRegistry(string id, string pw)
        {
            RegistryKey reg = Registry.LocalMachine.CreateSubKey("SoftWare").CreateSubKey("robot_carpedm20");
            reg.SetValue("ID", id);
            reg.SetValue("PW", pw);
        }
    }
}
