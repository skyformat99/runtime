// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

/*============================================================
**
**
**
** Purpose: Notes a class which knows how to return formatting information
**
**
============================================================*/

namespace System
{
    public interface IFormatProvider
    {
        // Interface does not need to be marked with the serializable attribute
        object? GetFormat(Type? formatType);
    }
}
