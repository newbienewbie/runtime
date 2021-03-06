// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Security.Authentication;

namespace System.Net
{
    [Flags]
    public enum SecurityProtocolType
    {
        SystemDefault = 0,
#pragma warning disable CS0618
        Ssl3 = SslProtocols.Ssl3,
#pragma warning restore CS0618
        Tls = SslProtocols.Tls,
        Tls11 = SslProtocols.Tls11,
        Tls12 = SslProtocols.Tls12,
        Tls13 = SslProtocols.Tls13,
    }
}
