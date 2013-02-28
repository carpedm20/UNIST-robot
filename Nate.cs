using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace robot
{
    class Nate
    {
        // http://xo.nate.com/Notfound.sk?redirect=http://club.cyworld.com/uniallstar&cpurl=www_ndr.nate.com%2flogin&viewnid=null&viewcid=null&flag=Y&e_url=http://www.nate.com/&mode=

        AutoLogin autoLogin;

        string id;
        string passwd;
        string nate;

        public Nate()
        {
            autoLogin = new AutoLogin();
        }

        public void getNate()
        {
            autoLogin.NateReadRegistry(ref this.id, ref this.passwd, ref this.nate);
        }
    }
}