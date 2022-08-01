using System;
using System.Collections.Generic;
using System.Text;

namespace MuayThaiApp.Tools
{
    public class KeysHelper
    {
        #region Patron de Diseño
        private static KeysHelper _instance;
        private static readonly object _instanceLock = new object();
        public static KeysHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        if (_instance == null)
                            _instance = new KeysHelper();
                    }
                }
                return _instance;
            }
        }
        #endregion
        public string MuayThaiApiUrl
        {
            get
            {
                return @"http://ingbame.somee.com/api";
            }
        }
    }
}
