// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Security.Cryptography
{
    public partial class PasswordDeriveBytes : DeriveBytes
    {
        public byte[] CryptDeriveKey(string? algname, string? alghashname, int keySize, byte[] rgbIV)
        {
            throw new PlatformNotSupportedException(SR.Format(SR.Cryptography_CAPI_Required, nameof(CryptDeriveKey)));
        }
    }
}
