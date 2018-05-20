using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Helpers
{
    class Constants
    {
        public const string PROFILE_SEARCH = "http://localhost:59994/api/SearchResult?ZUMO-API-VERSION=2.0.0&ownUserId={0}&searchType={1}&resultCount={2}";
        public const string OWNUSERID = "AD31EC52-5A07-A176-4195-8526FCB919EF";
        public const string SEARCHTYPE = "Peer";
        public const int RESULTCOUNT = 5;
    }
}
