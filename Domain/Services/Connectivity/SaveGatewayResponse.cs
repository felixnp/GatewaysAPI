using gatewayapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Domain.Services.Connectivity
{
    public class SaveGatewayResponse : BaseResponse
    {
        public Gateway Gateway { get; private set; }

        private SaveGatewayResponse(bool success, string message, Gateway gateway) : base(success, message)
        {
            Gateway = gateway;
        }

        /// Creates a success response.
        /// <param name="gateway">Saved gateway.</param>
        /// <returns>Response.</returns>
        public SaveGatewayResponse(Gateway gateway) : this(true, string.Empty, gateway)
        { }

        /// Creates am error response.
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveGatewayResponse(string message) : this(false, message, null)
        { }
		
    }
}
