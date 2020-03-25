using System;
using System.Collections.Generic;
using System.Text;
using CornNuggets.Entities;

namespace CornNuggets
{
    public class SecretConfig
    {
        public string GetConnString()
        {
            return "Server=tcp:2020-training-stacey.database.windows.net,1433;Initial Catalog=CornNuggets;Persist Security Info=False;User ID=stacey;Password=Umbrella123();MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}
