// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace System.Security.Cryptography
{
    internal partial class RandomNumberGeneratorImplementation
    {
        private static unsafe void GetBytes(byte* pbBuffer, int count)
        {
            Debug.Assert(count > 0);

            Interop.BCrypt.NTSTATUS status = Interop.BCrypt.BCryptGenRandom(IntPtr.Zero, pbBuffer, count, Interop.BCrypt.BCRYPT_USE_SYSTEM_PREFERRED_RNG);
            if (status != Interop.BCrypt.NTSTATUS.STATUS_SUCCESS)
                throw Interop.BCrypt.CreateCryptographicException(status);
        }
    }
}
