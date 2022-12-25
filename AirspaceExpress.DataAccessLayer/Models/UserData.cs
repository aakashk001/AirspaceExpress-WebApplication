using System;
using System.Collections.Generic;

namespace AirspaceExpress.DataAccessLayer.Models
{
    public partial class UserData
    {
        public decimal UserId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public decimal? WalletAmount { get; set; }
    }
}
