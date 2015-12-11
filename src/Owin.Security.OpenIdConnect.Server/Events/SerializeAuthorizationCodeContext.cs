/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OpenIdConnect.Server
 * for more information concerning the license and the contributors participating to this project.
 */

using System.Collections.Generic;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;

namespace Owin.Security.OpenIdConnect.Server {
    /// <summary>
    /// Provides context information used when issuing an authorization code.
    /// </summary>
    public sealed class SerializeAuthorizationCodeContext : BaseContext<OpenIdConnectServerOptions> {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializeAuthorizationCodeContext"/> class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="ticket"></param>
        internal SerializeAuthorizationCodeContext(
            IOwinContext context,
            OpenIdConnectServerOptions options,
            OpenIdConnectMessage request,
            OpenIdConnectMessage response,
            AuthenticationTicket ticket)
            : base(context, options) {
            Request = request;
            Response = response;
            AuthenticationTicket = ticket;
        }

        /// <summary>
        /// Gets the authorization request.
        /// </summary>
        public new OpenIdConnectMessage Request { get; }

        /// <summary>
        /// Gets the authorization response.
        /// </summary>
        public new OpenIdConnectMessage Response { get; }

        /// <summary>
        /// Gets the authentication ticket.
        /// </summary>
        public AuthenticationTicket AuthenticationTicket { get; }

        /// <summary>
        /// Gets the list of presenters.
        /// </summary>
        public IList<string> Presenters { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the data format used to serialize the authentication ticket.
        /// </summary>
        public ISecureDataFormat<AuthenticationTicket> DataFormat { get; set; }

        /// <summary>
        /// Gets or sets the authorization code returned to the client application.
        /// </summary>
        public string AuthorizationCode { get; set; }
    }
}